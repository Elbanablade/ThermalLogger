using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Net.Mail;
using Microsoft.VisualBasic;



namespace burnInMonitor
{
    public partial class MainForm : Form
    {
        public const int SERIAL_PORT_SPEED = 115200;

        public StatusBarPanel PanelTimeofDay = new StatusBarPanel();
        public Timer TimeofDay = new Timer();

        public StatusBarPanel PanelElapsed = new StatusBarPanel();
        public Timer Elapsed = new Timer();

        public StatusBarPanel PanelNextRead = new StatusBarPanel();
        public Timer NextRead = new Timer();

        public event Action<string> getComPort = null;
        public string onGetComPort(string s) { if (getComPort != null) { getComPort(s); } return s; }

        SerialPort _serialPort;

        FileStream tempFileStream;
        StreamReader tempStreamReader;

        public double pCurrentLimit = -1;
        public double nCurrentLimit = -1;
        public int useInterval = -1;
        public int useError = -1;

        public string firmwareId = null;
        public string time = null;
        public string boardNumber = null;
        public string partNumber = null;
        public string positiveCurrent = null;
        public string negativeCurrent = null;
        public string bit4 = null;
        public string active = null;
        int yellowBox = -1;
        int redBox = -1;

        public static string globalboards = null;

        public int diagBoard = 0;

        public int seconds = 0;
        public int minutes = 0;
        public int hours = 0;
        public int days = 0;

        public int readMin = 0;
        public int readSec = 0;

        public int row = 0;
        public int incriment = 0;
        public int totalRowsOfData = 0;

        public bool didIniLoad = false;
        public bool isdiag = false;
        public bool ismanual = false;
        public bool[] isPassingP = new bool[360];
        public bool[] isPassingN = new bool[360];
        public bool isDynamic = false;        

        #region Initial Setup

        Dictionary<short, string> position_to_rowcol = new Dictionary<short, string>();

        public MainForm()
        {
            InitializeComponent();
            BuildStatusBar();
            initPositionDecoder(); 
            initVisible();           
        }

        public void initPositionDecoder()
        {
            position_to_rowcol.Add(1, "A1");
            position_to_rowcol.Add(5, "A2");
            position_to_rowcol.Add(9, "A3");
            position_to_rowcol.Add(13, "A4");
            position_to_rowcol.Add(17, "A5");
            position_to_rowcol.Add(2, "B1");
            position_to_rowcol.Add(6, "B2");
            position_to_rowcol.Add(10, "B3");
            position_to_rowcol.Add(14, "B4");
            position_to_rowcol.Add(18, "B5");
            position_to_rowcol.Add(3, "C1");
            position_to_rowcol.Add(7, "C2");
            position_to_rowcol.Add(11, "C3");
            position_to_rowcol.Add(15, "C4");
            position_to_rowcol.Add(19, "C5");
            position_to_rowcol.Add(4, "D1");
            position_to_rowcol.Add(8, "D2");
            position_to_rowcol.Add(12, "D3");
            position_to_rowcol.Add(16, "D4");
            position_to_rowcol.Add(20, "D5");
        }

        public void BuildStatusBar()
        {
            TimeofDaySetup();
            StatusBar statusBar = new StatusBar();
            statusBar.SizingGrip = false;

            statusBar.ShowPanels = true;
            statusBar.Panels.AddRange((StatusBarPanel[])new StatusBarPanel[] { PanelTimeofDay, PanelElapsed, PanelNextRead });
            statusBar.Height = 36;

            PanelTimeofDay.Alignment = HorizontalAlignment.Right;
            PanelTimeofDay.Width = 106;

            PanelElapsed.Alignment = HorizontalAlignment.Right;
            PanelElapsed.Width = 118;

            PanelNextRead.Alignment = HorizontalAlignment.Right;
            PanelNextRead.Width = 100;

            Controls.Add(statusBar);
        }

        public void initVisible()
        {
            file.Enabled = true;
            setup.Enabled = true;
            help.Enabled = true;

            loadSetupFile.Enabled = false;
            chooseBoards.Enabled = false;
            saveToLogfile.Enabled = false;
            runDiagnostic.Enabled = false;
            quit.Enabled = true;

            enterCOM.Enabled = true;
            buttonCOM.Enabled = false;
            statusCOM.Visible = true;

            groupMainParameters.Visible = true;
            groupProgramSetup.Visible = false;
            groupBoards.Visible = false;

            enterPCurrent.Enabled = false;
            statusPCurrent.Visible = false;
            enterNCurrent.Enabled = false;
            statusNCurrent.Visible = false;
            enterInterval.Enabled = false;
            statusInterval.Visible = false;
            enterError.Enabled = false;
            statusError.Visible = false;
            buttonDiag.Enabled = false;

            buttonStart.Visible = false;
            buttonStart.Enabled = false;
            buttonStop.Visible = false;
            buttonStop.Enabled = false;
            buttonForce.Visible = false;

            runDiagnostic.Enabled = false;

            enterCOM.Focus();
        }

        #endregion

        #region Global Variables

        public string ___myPath;
        public string myPath
        {
            get
            {
                return ___myPath;
            }
            set
            {
                ___myPath = value;
            }
        }

        public string ___boardsToMonitor;
        public string boardsToMonitor
        {
            get
            {
                return ___boardsToMonitor;
            }
            set
            {
                ___boardsToMonitor = value;
            }
        }

        public bool ___logData;
        public bool logData
        {
            get
            {
                return ___logData;
            }
            set
            {
                ___logData = value;
            }
        }

        public bool ___reportErrors;
        public bool reportErrors
        {
            get
            {
                return ___reportErrors;
            }
            set
            {
                ___reportErrors = value;
            }
        }

        public string ___errorFilePath;
        public string errorFilePath
        {
            get
            {
                return ___errorFilePath;
            }
            set
            {
                ___errorFilePath = value;
            }
        }

        public bool ___isPowerData;
        public bool isPowerData
        {
            get
            {
                return ___isPowerData;
            }
            set
            {
                ___isPowerData = value;
            }
        }

        public double ___powerReading;
        public double powerReading
        {
            get
            {
                return ___powerReading;
            }
            set
            {
                ___powerReading = value;
            }
        }

        #endregion

        #region Timers

        public void TimeofDaySetup()
        {
            TimeofDay.Enabled = true;
            TimeofDay.Interval = 1000;
            TimeofDay.Tick += TimeofDay_Tick;
        }

        public void TimeofDay_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            string s = t.ToLongTimeString();
            PanelTimeofDay.Text = s + " ";
        }

        public void ElapsedSetup()
        {
            Elapsed.Enabled = true;
            Elapsed.Interval = 1000;
            Elapsed.Tick += Elapsed_Tick;
        }

        public void Elapsed_Tick(object sender, EventArgs e)
        {
            if ((seconds >= 0) && (seconds <= 58)) seconds += 1;
            else
            {
                seconds = 0;
                if ((minutes >= 0) && (minutes <= 58)) minutes += 1;
                else
                {
                    minutes = 0;
                    if ((hours >= 0) && (hours <= 22)) hours += 1;
                    else
                    {
                        hours = 0;
                        days += 1;
                    }
                }
            }
            PanelElapsed.Text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hours, minutes, seconds) + " ";
            if (readSec < 1)
            {
                readSec = 59;
                if (readMin == 0) readMin = useInterval - 1;
                else readMin -= 1;
            }
            else readSec -= 1;
            PanelNextRead.Text = string.Format("{0:00}:{1:00}", readMin, readSec) + " ";
            if (PanelNextRead.Text == "00:00 ")
            {
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();
                Rollover(sender, e);
            }
        }

        public void NextReadSetup()
        {
            NextRead.Enabled = true;
            NextRead.Interval = useInterval * 60000;
        }

        #endregion

        #region Click Actions

        private void buttonCOM_Click(object sender, EventArgs e)
        {
            bool devicethere = false;
        
            try
            {
                _serialPort = new SerialPort(onGetComPort(enterCOM.SelectedItem.ToString()), SERIAL_PORT_SPEED, Parity.None, 8, StopBits.One);
                if(_serialPort.IsOpen == true) _serialPort.Close();
                _serialPort.Open();
                _serialPort.ReadTimeout = 500;
                _serialPort.WriteTimeout = 500;
                _serialPort.Write("*");
                firmwareId = _serialPort.ReadLine().Trim();
                if (firmwareId.Contains("RAD1419")) devicethere = true;
                _serialPort.Close();
                _serialPort.Dispose();

                if (devicethere == true)
                {
                        statusCOM.Text = enterCOM.Text + " selected";
                        labelDetected.Text = firmwareId + "\nfirmware detected";
                        labelDetected.ForeColor = System.Drawing.Color.Green;
                        labelDetected.Location = new System.Drawing.Point(10, 65);
                        if (firmwareId.Contains("Dynamic")) isDynamic = true;

                        groupProgramSetup.Visible = true;
                        groupProgramSetup.Enabled = true;
                        buttonLoadSetup.Focus();
                        saveToLogfile.Enabled = true;
                        loadSetupFile.Enabled = true;
                }

                    if (devicethere == false)
                    {
                        DialogResult resultgone = MessageBox.Show("A Seeeduino MEGA with 1419 burn-in firmware was not detected on port " + enterCOM.SelectedItem.ToString() + ".\r\n\r\nContinue anyway?", "Device Not Found", MessageBoxButtons.YesNo);
                        if (resultgone == DialogResult.Yes)
                        {
                            statusCOM.Text = enterCOM.Text + " selected";
                            labelDetected.Text = "Burn-in Seeeduino not detected";
                            labelDetected.ForeColor = System.Drawing.Color.Red;
                            labelDetected.Location = new System.Drawing.Point(11, 75);

                            groupProgramSetup.Visible = true;
                            groupProgramSetup.Enabled = true;
                            groupBoards.Enabled = false;
                            buttonStart.Enabled = false;
                            buttonStop.Enabled = false;
                            buttonLoadSetup.Focus();
                            saveToLogfile.Enabled = true;
                            loadSetupFile.Enabled = true;
                            chooseBoards.Enabled = false;
                            runDiagnostic.Enabled = false;
                            statusDiag.Text = "Enter\r\nBoard #";
                            buttonDiag.Enabled = false;
                            enterDiag.Text = null;
                        }
                        else if (resultgone == DialogResult.No)
                        {
                            _serialPort.Close();
                            _serialPort.Dispose();
                            groupProgramSetup.Enabled = false;
                            groupBoards.Enabled = false;
                            buttonStart.Enabled = false;
                            buttonStop.Enabled = false;
                            chooseBoards.Enabled = false;
                            saveToLogfile.Enabled = false;
                            loadSetupFile.Enabled = false;
                            statusCOM.Text = "Select COM Port";
                            labelDetected.Text = "";
                            enterCOM.Focus();
                        }
                    }
                }
            

            catch (TimeoutException)
            {
                DialogResult resultgone = MessageBox.Show("A Seeeduino MEGA with 1419 burn-in firmware was not detected on port " + enterCOM.SelectedItem.ToString() + ".\r\n\r\nContinue anyway?", "Device Not Found", MessageBoxButtons.YesNo);
                if (resultgone == DialogResult.Yes)
                {
                    statusCOM.Text = enterCOM.Text + " selected";
                    labelDetected.Text = "Burn-in Seeeduino not detected";
                    labelDetected.ForeColor = System.Drawing.Color.Red;
                    labelDetected.Location = new System.Drawing.Point(11, 75);

                    groupProgramSetup.Visible = true;
                    groupProgramSetup.Enabled = true;
                    statusPCurrent.Visible = false;
                    statusNCurrent.Visible = false;
                    statusError.Visible = false;
                    statusInterval.Visible = false;
                    enterPCurrent.Enabled = false;
                    enterNCurrent.Enabled = false;
                    enterError.Enabled = false;
                    enterInterval.Enabled = false;
                    enterPCurrent.Text = null;
                    enterNCurrent.Text = null;
                    enterInterval.Text = null;
                    enterError.Text = null;
                    groupBoards.Enabled = false;
                    buttonStart.Enabled = false;
                    buttonStop.Enabled = false;
                    buttonLoadSetup.Focus();
                    saveToLogfile.Enabled = true;
                    loadSetupFile.Enabled = true;
                    chooseBoards.Enabled = false;
                    runDiagnostic.Enabled = false;
                    statusDiag.Text = "Enter\r\nBoard #";
                    buttonDiag.Enabled = false;
                    enterDiag.Text = null;
                }

                else if (resultgone == DialogResult.No)
                {
                    _serialPort.Close();
                    _serialPort.Dispose();
                    groupProgramSetup.Enabled = false;
                    groupBoards.Enabled = false;
                    statusPCurrent.Visible = false;
                    statusNCurrent.Visible = false;
                    statusError.Visible = false;
                    statusInterval.Visible = false;
                    enterPCurrent.Enabled = false;
                    enterNCurrent.Enabled = false;
                    enterError.Enabled = false;
                    enterInterval.Enabled = false;
                    enterPCurrent.Text = null;
                    enterNCurrent.Text = null;
                    enterInterval.Text = null;
                    enterError.Text = null;
                    buttonStart.Enabled = false;
                    buttonStop.Enabled = false;
                    chooseBoards.Enabled = false;
                    saveToLogfile.Enabled = false;
                    loadSetupFile.Enabled = false;
                    statusCOM.Text = "Select COM Port";
                    labelDetected.Text = "";
                    enterCOM.Focus();
                }
            }
            catch (Exception)
            {
                _serialPort.Close();
                while (_serialPort.IsOpen == true) 
                _serialPort.Close();
                _serialPort.Dispose();  
            }

            row = 0;
            incriment = 0;
            row_data_structure.Clear();
        }

        private void buttonLoadSetup_Click(object sender, EventArgs e)
        {
            if (ismanual == true)
            {
                DialogResult dialog = MessageBox.Show("This will replace your manually entered values with the ones from the setup file.\r\n\r\nContinue?", "Override Manual Values?", MessageBoxButtons.OKCancel);
                if (dialog == DialogResult.OK)
                {
                    ismanual = false;
                    Cursor = Cursors.AppStarting;
                    System.Threading.Thread.Sleep(300);
                    Cursor = Cursors.Default;
                    loadIni(sender, e);
                    labelPCurrent.Visible = true;
                    enterPCurrent.Enabled = false;
                    enterNCurrent.Enabled = false;
                    enterInterval.Enabled = false;
                    enterError.Enabled = false;
                    groupBoards.Enabled = true;
                }
            }

            else if (ismanual == false)
            {
                ismanual = false;
                Cursor = Cursors.AppStarting;
                System.Threading.Thread.Sleep(300);
                Cursor = Cursors.Default;
                loadIni(sender, e);
                labelPCurrent.Visible = true;
                enterPCurrent.Enabled = false;
                enterNCurrent.Enabled = false;
                enterInterval.Enabled = false;
                enterError.Enabled = false;
                groupBoards.Enabled = true;
            }
        }

        private void buttonEnterManual_Click(object sender, EventArgs e)
        {
            ismanual = true;
            groupMainParameters.Enabled = true;
            enterPCurrent.Enabled = true;
            enterNCurrent.Enabled = false;
            enterInterval.Enabled = false;
            enterError.Enabled = false;
            statusPCurrent.Visible = true;
            enterPCurrent.Focus();
            groupBoards.Enabled = false;
            chooseBoards.Enabled = false;
            runDiagnostic.Enabled = false;
        }
        

        private void save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sl = new SaveFileDialog();
            sl.CreatePrompt = true;
            sl.InitialDirectory = @"%USERPROFILE%\Desktop";
            sl.FileName = "Burn_Logfile_" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Year.ToString();
            sl.Title = "Specify Save Directory for Logfiles...";
            sl.Filter = "CSV Files|*.csv";
            sl.FilterIndex = 1;
            sl.OverwritePrompt = false;            

            if (sl.ShowDialog() == DialogResult.OK)
            {
                myPath = sl.FileName;
                logData = true;
                checkSaveToFile.Checked = true;
                saveToLogfile.Checked = true;
                checkSaveToFile.Checked = true;

                FileStream fs = new FileStream(myPath, FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                string assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); 
                sw.WriteLine(DateTime.Now.ToString() + ",GUIVersion," + assemblyVersion);
                sw.WriteLine(DateTime.Now.ToString() + ",FWVersion," + firmwareId);
                sw.Close();
                fs.Close();

                string[] errorFileTemp = this.myPath.Split('.');
                this.errorFilePath = errorFileTemp[0] + "_ErrorLog.csv";
                fs = new FileStream(this.errorFilePath, FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(DateTime.Now.ToString() + ",GUIVersion," + assemblyVersion);
                sw.WriteLine(DateTime.Now.ToString() + ",FWVersion," + firmwareId);
                sw.Close();
                fs.Close();
            }

            else
            {
                logData = false;
                checkSaveToFile.Checked = false;
                saveToLogfile.Checked = false;
            }
        }

        private void diagnostic_Click(object sender, EventArgs e)
        {
            isdiag = true;
            label2.Visible = true;
            labelPanelBoard.Visible = true;
            labelPanelSocket.Visible = true;
            labelPanelPositive.Visible = true;
            labelPanelNegative.Visible = true;
            if (isDynamic == true) labelPanelBit4.Visible = true;
            if (isDynamic == true) labelPanelActive.Visible = true;
            totalRowsOfData = totalrows();

            try
            {
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                _serialPort.Open();
            }

            catch { }

            try
            {
                _serialPort.Write("+" + returnBoardNumber(diagBoard) + "-1");
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message + "\r\n\r\nDouble-check COM port selection.", "COM Port Error");
            }
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chooseBoards_Click(object sender, EventArgs e)
        {
            ChooseBoards tempform = new ChooseBoards();
            tempform.Closing += new CancelEventHandler(tempform_Closing);
            tempform.ShowDialog();
        }

        public void tempform_Closing(object sender, CancelEventArgs e)
        {
            ChooseBoards tempform = (ChooseBoards)sender;

            if (tempform.checkedBoards == null)
            {
                if (tempform.DialogResult == DialogResult.OK)
                {
                    globalboards = null;
                    buttonStart.Enabled = false;
                    statusChooseBoards.Text = "\r\nChoose boards to monitor.";
                    statusChooseBoards.TextAlign = HorizontalAlignment.Center;
                }
            }

            if (tempform.checkedBoards != null)
            {
                globalboards = tempform.checkedBoards;
                boardsToMonitor = globalboards.TrimEnd().TrimEnd(',');
                string[] list = boardsToMonitor.Split(',');
                statusChooseBoards.Text = "Monitoring boards:\r\n" + boardsToMonitor;
                statusChooseBoards.TextAlign = HorizontalAlignment.Left;
                if (list.Length == 18)
                {
                    statusChooseBoards.Text = "\r\nMonitoring boards: 1-18";
                    statusChooseBoards.TextAlign = HorizontalAlignment.Center;
                }
                buttonStart.Enabled = true;
            }
        }

        private void labelBoards_GotFocus(object sender, EventArgs e)
        {
            buttonChooseBoards.Focus();
        }

        private void textBoxMain_GotFocus(object sender, EventArgs e)
        {
            enterCOM.Focus();
            enterPCurrent.Focus();
            enterNCurrent.Focus();
            enterInterval.Focus();
            enterError.Focus();
            buttonChooseBoards.Focus();
            buttonStop.Focus();
        }

        private void about_Click(object sender, EventArgs e)
        {
            About helpbox = new About();
            helpbox.ShowDialog();
        }

        private void enterCOM_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonCOM.Enabled = true;
        }

        private void checkSaveToFile_Click(object sender, EventArgs e)
        {
            if (checkSaveToFile.Checked == true)
            {
                saveToLogfile.Checked = true;
                save_Click(sender, e);
            }
            if (checkSaveToFile.Checked == false)
            saveToLogfile.Checked = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            save_Click(sender, e);
        }

        private void buttonChooseBoards_Click(object sender, EventArgs e)
        {
            chooseBoards_Click(sender, e);
        }

        private void buttonDiag_Click(object sender, EventArgs e)
        {
            diagnostic_Click(sender, e);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            isdiag = false;
            label2.Visible = true;
            labelPanelBoard.Visible = true;
            labelPanelSocket.Visible = true;
            labelPanelPositive.Visible = true;
            labelPanelNegative.Visible = true;
            if (isDynamic == true) labelPanelBit4.Visible = true;            
            if (isDynamic == true) labelPanelActive.Visible = true;
            totalRowsOfData = totalrows();
            textBox1.Focus();

            if (_serialPort.IsOpen == false)
            {                
                _serialPort.Open();
            }

            try
            {
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
                buttonStop.Enabled = true;
            }

            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Invalid serial operation");
            }

            NextReadSetup();
            ElapsedSetup();
            buttonStart.Enabled = false;
            buttonStart.Text = "Started";
            buttonStop.Text = "Stop";
            buttonForce.Visible = true;

            menuStrip.Enabled = false;
            groupMainParameters.Enabled = false;
            groupDiag.Enabled = false;
            groupPortSelection.Enabled = false;
            groupBoards.Enabled = false;
            groupProgramSetup.Enabled = false;
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            _serialPort.Close();

            Cursor = Cursors.Default;
            Elapsed.Enabled = false;
            Elapsed.Tick -= Elapsed_Tick;

            seconds = 0; minutes = 0; hours = 0; days = 0;
            readMin = 0; readSec = 0;
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
            buttonStop.Text = "Stopped";
            buttonStart.Text = "Start";
            buttonForce.Visible = false;

            menuStrip.Enabled = true;
            groupPortSelection.Enabled = true;
            groupMainParameters.Enabled = true;
            groupDiag.Enabled = true;
            groupBoards.Enabled = true;
            groupProgramSetup.Enabled = true;

            buttonChooseBoards.Focus();

            PanelElapsed.Text = null;
            PanelNextRead.Text = null;
        }

        private void loadSetupFile_Click(object sender, EventArgs e)
        {
            buttonLoadSetup_Click(sender, e);
        }

        private void runDiagnostic_Click(object sender, EventArgs e)
        {
            buttonDiag_Click(sender, e);
        }

        private void restoreSetupFile_Click(object sender, EventArgs e)
        {
            RecreateSetup recreate = new RecreateSetup();
            recreate.ShowDialog();
        }

        #endregion

        #region Keypress Events

        private void CheckTextBoxForEnter(object sender, KeyPressEventArgs e, Action check)
        {
            if (e.KeyChar == (char)Keys.Return)
                check.DynamicInvoke(new object[] { });
        }

        private void enterP_Current_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextBoxForEnter(sender, e, (Action)delegate()
            {
                double tempVal;
                if (double.TryParse(((Control)sender).Text, out tempVal))
                {
                    pCurrentLimit = tempVal;
                    if (tempVal > 0)
                    {
                        enterNCurrent.Enabled = true;
                        statusPCurrent.Text = enterPCurrent.Text + " A\r\nconfirmed";
                        statusNCurrent.Visible = true;
                        enterNCurrent.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Invalid entry. Positive decimal number required.", "Invalid Entry");
                        enterPCurrent.Focus();
                        enterPCurrent.SelectionStart = 0;
                        enterPCurrent.SelectionLength = enterPCurrent.TextLength;
                    }
                }

                else
                {
                    MessageBox.Show("Invalid entry. Positive decimal number required.", "Invalid Entry");
                    enterPCurrent.Focus();
                    enterPCurrent.SelectionStart = 0;
                    enterPCurrent.SelectionLength = enterPCurrent.TextLength;
                }
            });
        }

        private void enterN_Current_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextBoxForEnter(sender, e, (Action)delegate()
            {
                double tempVal;
                if (double.TryParse(((Control)sender).Text, out tempVal))
                {
                    nCurrentLimit = tempVal;
                    if (tempVal > 0)
                    {
                        enterInterval.Enabled = true;
                        statusNCurrent.Text = enterNCurrent.Text + " A\r\nconfirmed";
                        statusInterval.Visible = true;
                        enterInterval.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Invalid entry. Positive decimal number requried.", "Invalid Entry");
                        enterNCurrent.Focus();
                        enterNCurrent.SelectionStart = 0;
                        enterNCurrent.SelectionLength = enterNCurrent.TextLength;
                    }
                }

                else
                {
                    MessageBox.Show("Invalid entry. Positive decimal number required.", "Invalid Entry");
                    enterNCurrent.Focus();
                    enterNCurrent.SelectionStart = 0;
                    enterNCurrent.SelectionLength = enterNCurrent.TextLength;
                }
            });
        }

        private void enterInterval_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextBoxForEnter(sender, e, (Action)delegate()
            {
                int tempVal;
                if (int.TryParse(((Control)sender).Text, out tempVal))
                {
                    useInterval = tempVal;
                    if (tempVal > 0)
                    {
                        enterError.Enabled = true;
                        if (enterInterval.Text == "1") statusInterval.Text = "1 min\r\nconfirmed";
                        else statusInterval.Text = enterInterval.Text + " mins\r\nconfirmed";
                        statusError.Visible = true;
                        enterError.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Invalid entry. Positive integer required.", "Invalid Entry");
                        enterInterval.Focus();
                        enterInterval.SelectionStart = 0;
                        enterInterval.SelectionLength = enterInterval.TextLength;
                    }
                }

                else
                {
                    MessageBox.Show("Invalid entry. Positive integer required.", "Invalid Entry");
                    enterInterval.Focus();
                    enterInterval.SelectionStart = 0;
                    enterInterval.SelectionLength = enterInterval.TextLength;
                }
            });
        }



        private void enterError_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextBoxForEnter(sender, e, (Action)delegate()
            {
                int tempVal;
                if (int.TryParse(((Control)sender).Text, out tempVal))
                {
                    useError = tempVal;
                    if (tempVal > 0)
                    {
                        checkSaveToFile.Enabled = true;
                        statusError.Text = enterError.Text + "% error\r\nconfirmed";
                        buttonChooseBoards.Enabled = true;

                        enterDiag.Enabled = true;
                        statusDiag.Visible = true;
                        chooseBoards.Enabled = true;
                        chooseBoards.Enabled = true;
                        groupBoards.Enabled = true;

                        saveToLogfile.Enabled = true;
                        groupBoards.Visible = true;
                        groupDiag.Visible = true;
                        buttonStart.Visible = true;
                        buttonStop.Visible = true;
                        buttonChooseBoards.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Invalid entry. Positive integer between 1 and 100 required.", "Invalid Entry");
                        enterError.Focus();
                        enterError.SelectionStart = 0;
                        enterError.SelectionLength = enterInterval.TextLength;
                    }
                }

                else
                {
                    MessageBox.Show("Invalid entry. Positive integer between 1 and 100 required.", "Invalid Entry");
                    enterError.Focus();
                    enterError.SelectionStart = 0;
                    enterError.SelectionLength = enterInterval.TextLength;
                }
            });
        }

        private void enterDiag_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckTextBoxForEnter(sender, e, (Action)delegate()
            {
                int tempVal;
                if (int.TryParse(((Control)sender).Text, out tempVal))
                {
                    diagBoard = tempVal;
                    bool isvaliddiag = false;
                    for (int i = 1; i <= 18; i++)
                    {
                        if (tempVal == i) isvaliddiag = true;
                    }

                    if (isvaliddiag == true)
                    {
                        buttonDiag.Enabled = true;
                        statusDiag.Text = "Board " + enterDiag.Text.Trim() + "\r\nconfirmed";
                        runDiagnostic.Enabled = true;
                        buttonDiag.Focus();
                    }

                    else
                    {
                        MessageBox.Show("Invalid board specified for diagnostic.\r\n\r\nSpecify a single board between 1 and 18.", "Invalid Entry");
                        enterDiag.Focus();
                        enterDiag.SelectionStart = 0;
                        enterDiag.SelectionLength = enterDiag.TextLength;
                        buttonDiag.Enabled = false;
                    }
                }

                else
                {
                    MessageBox.Show("Invalid board specified for diagnostic.\r\n\r\nSpecify a single board between 1 and 18.", "Invalid Entry");
                    enterDiag.Focus();
                    enterDiag.SelectionStart = 0;
                    enterDiag.SelectionLength = enterDiag.TextLength;
                    buttonDiag.Enabled = false;
                }
            });
        }

        #endregion

        #region File Operations

        public void writeToErrorFile(string time, string boardNumber, string partNumber, string positiveCurrent, string negativeCurrent, string bit4, string active)
        {
            FileStream fs = new FileStream(this.errorFilePath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(time + "," + boardNumber + "," + partNumber + "," + positiveCurrent + "," + negativeCurrent + "," + bit4 + "," + active);
            sw.Close();
            fs.Close();
        }

        private void loadIni(object sender, EventArgs e)
        {
            string exePath = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf("\\"));    // get the path string then remove the .exe"
            string iniFileName = exePath + "\\burnInSetup.ini";
            try
            {
                tempFileStream = new FileStream(iniFileName, FileMode.Open, FileAccess.Read);
                tempStreamReader = new StreamReader(tempFileStream);
                string[] setupfilevars = tempStreamReader.ReadToEnd().Split('\n');
                tempStreamReader.Close();
                tempFileStream.Close();

                foreach (string line in setupfilevars)
                {
                    string[] validLines = line.Split('=');
                    if (validLines[0] == "PositiveRailCurrent")
                    {
                        double.TryParse(validLines[1], out pCurrentLimit);
                        if (double.TryParse(validLines[1], out pCurrentLimit) == false) MessageBox.Show("Could not apply setup file: variable \"PositiveRailCurrent\" is invalid or missing.", "Setup File Error");

                        if (pCurrentLimit < 0)
                        {
                            MessageBox.Show("Could not apply setup file: variable \"PositiveRailCurrent\" must be a positive decimal number.", "Setup File Error");
                            pCurrentLimit = -1;
                            didIniLoad = false;
                        }
                    }
                }

                foreach (string line in setupfilevars)
                {
                    string[] validLines = line.Split('=');
                    if (validLines[0] == "NegativeRailCurrent")
                    {
                        double.TryParse(validLines[1], out nCurrentLimit);
                        if (double.TryParse(validLines[1], out nCurrentLimit) == false) MessageBox.Show("Could not apply setup file: variable \"NegativeRailCurrent\" is invalid or missing.", "Setup File Error");

                        if (nCurrentLimit < 0)
                        {
                            MessageBox.Show("Could not apply setup file: variable \"NegativeRailCurrent\" must be a positive decimal number.", "Setup File Error");
                            nCurrentLimit = -1;
                            didIniLoad = false;
                        }
                    }
                }

                foreach (string line in setupfilevars)
                {
                    string[] validLines = line.Split('=');
                    if (validLines[0] == "MinsBetweenReads")
                    {
                        try
                        {
                            useInterval = Int32.Parse(validLines[1]);
                            if (useInterval < 0)
                            {
                                MessageBox.Show("Could not apply setup file: variable \"MinsBetweenReads\" must be a positive integer.", "Setup File Error");
                                useInterval = -1;
                            }
                        }
                        catch (FormatException) { MessageBox.Show("Could not parse setup file: variable \"MinsBetweenReads\" is not a valid integer.", "Setup File Error"); }
                        catch (ArgumentNullException) { MessageBox.Show("Could not apply setup file: variable \"MinsBetweenReads\" was not found.", "Setup File Error"); }
                    }
                }

                foreach (string line in setupfilevars)
                {
                    string[] validLines = line.Split('=');
                    if (validLines[0] == "MainThreshold")
                    {
                        try
                        {
                            useError = Int32.Parse(validLines[1]);
                            if (useError < 0 || useError > 100)
                            {
                                MessageBox.Show("Could not apply setup file: variable \"MainThreshold\" must be an integer between 0 and 100.", "Setup File Error");
                                useError = -1;
                            }
                        }
                        catch (FormatException) { MessageBox.Show("Could not parse setup file: variable \"MainThreshold\" is not a valid integer.", "Setup File Error"); }
                        catch (ArgumentNullException) { MessageBox.Show("Could not apply setup file: variable \"MainThreshold\" was not found.", "Setup File Error"); }
                    }
                }

                foreach (string line in setupfilevars)
                {
                    string[] validLines = line.Split('=');
                    if (validLines[0] == "YellowBox")
                    {
                        try
                        {
                            yellowBox = Int32.Parse(validLines[1]);
                            if (yellowBox < 0 || yellowBox > 100)
                            {
                                MessageBox.Show("Could not apply setup file: variable \"YellowBox\" must be an integer between 0 and 100.", "Setup File Error");
                                yellowBox = -1;
                            }
                        }
                        catch (FormatException) { MessageBox.Show("Could not parse setup file: variable \"YellowBox\" is not a valid integer.", "Setup File Error"); }
                        catch (ArgumentNullException) { MessageBox.Show("Could not apply setup file: variable \"YellowBox\" was not found.", "Setup File Error"); }
                    }
                }

                foreach (string line in setupfilevars)
                {
                    string[] validLines = line.Split('=');
                    if (validLines[0] == "RedBox")
                    {
                        try
                        {
                            redBox = Int32.Parse(validLines[1]);
                            if (redBox < 0 || redBox > 100)
                            {
                                MessageBox.Show("Could not apply setup file: variable \"RedBox\" must be an integer between 0 and 100.", "Setup File Error");
                                redBox = -1;
                            }
                        }
                        catch (FormatException) { MessageBox.Show("Could not parse setup file: variable \"RedBox\" is not a valid integer.", "Setup File Error"); }
                        catch (ArgumentNullException) { MessageBox.Show("Could not apply setup file: variable \"RedBox\" was not found.", "Setup File Error"); }
                    }
                }
                if (pCurrentLimit != -1 && nCurrentLimit != -1 && useInterval != -1
                    && useError != -1 && yellowBox != -1 && redBox != -1)
                {

                    enterPCurrent.Text = pCurrentLimit.ToString();
                    statusPCurrent.Visible = true;
                    statusPCurrent.Text = enterPCurrent.Text + " A\r\nconfirmed";

                    enterNCurrent.Text = nCurrentLimit.ToString();
                    statusNCurrent.Visible = true;
                    statusNCurrent.Text = enterNCurrent.Text + " A\r\nconfirmed";

                    enterInterval.Text = useInterval.ToString();
                    statusInterval.Visible = true;
                    if (enterInterval.Text == "1") statusInterval.Text = "1 min\r\nconfirmed";
                    else statusInterval.Text = enterInterval.Text + " mins\r\nconfirmed";

                    enterError.Text = useError.ToString();
                    statusError.Visible = true;
                    statusError.Text = enterError.Text + "% error\r\nconfirmed";

                    groupBoards.Visible = true;
                    chooseBoards.Enabled = true;

                    buttonStart.Visible = true;
                    buttonStop.Visible = true;
                    buttonChooseBoards.Focus();
                }
                else MessageBox.Show("Could not apply setup file: one or more variables were not found. Click \"Help\" for more information.", "Setup File Error");
            }

            catch (Exception)
            {
                MessageBox.Show("Failed to load setup file. Ensure that it is present in the application directory. Click \"Help\" for more information.", "Setup File Error");
            }
        }

        #endregion

        #region Serial Connection
        
        Dictionary<int, CustomControlDynamic> row_data_structure = new Dictionary<int, CustomControlDynamic>();

        private void textc(RichTextBox box, string text, Color color)
        {
            box.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 7);
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.SelectionTabs = new int[] { 1 };

            box.AppendText(text);

            box.SelectionColor = box.ForeColor;

        }

    /*    private void textu(RichTextBox box, string text, float size, FontStyle style)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionFont = new Font("Lucida Console", size, style);
            box.SelectionColor = Color.Gray;
            box.SelectionTabs = new int[] { 1 };
            box.AppendText(text);
            box.SelectionFont = new Font("Microsoft Sans Serif", 5.25F, FontStyle.Regular);
            box.SelectionColor = box.ForeColor;
        }*/

        private void add_Data(string time, string boardNumber, string partNumber, string positiveCurrent, string negativeCurrent, string bit4, string active)
        {
            bool writeToErrFile = false;

            double errorPos;
            double errorNeg;

            double threshold = double.Parse(enterError.Text);
            double tempPosCurr = double.Parse(positiveCurrent);
            double tempNegCurr = double.Parse(negativeCurrent);

            errorPos = Math.Abs((1 - (tempPosCurr / pCurrentLimit)) * 100);
            errorNeg = Math.Abs((1 - (tempNegCurr / nCurrentLimit)) * 100);

            textBox1.AppendText(time + "\t\t  ");
            textBox1.AppendText(boardNumber + "\t");
            textBox1.AppendText(partNumber + "\t");

            if (errorPos >= (threshold + redBox) || (((threshold + yellowBox) <= errorPos) && (errorPos < (threshold + redBox))))
            {
                textc(textBox1, positiveCurrent + "\t    ", Color.Red);
                if (this.logData == true) writeToErrFile = true;                
            }

            else if ((threshold < errorPos) && (errorPos <= (threshold + yellowBox)))
            {
                textc(textBox1, positiveCurrent + "\t    ", Color.Red);
                if (this.logData == true) writeToErrFile = true; 
            }

            else if (errorPos <= threshold)
            {
                textc(textBox1, positiveCurrent + "\t    ", Color.Green);
            }

            if (errorNeg >= (threshold + redBox) || (((threshold + yellowBox) <= errorNeg) && (errorNeg < (threshold + redBox))))
            {
                textc(textBox1, negativeCurrent + "\t      ", Color.Red);
                if (this.logData == true) writeToErrFile = true;                
            }

            else if ((threshold < errorNeg) && (errorNeg <= (threshold + yellowBox)))
            {
                textc(textBox1, negativeCurrent + "\t      ", Color.Red);
                if (this.logData == true) writeToErrFile = true; 
            }

            else if (errorNeg <= threshold)
            {
                textc(textBox1, negativeCurrent + "\t      ", Color.Green);
            }

            if (isDynamic == true)
            {
                textBox1.AppendText(bit4 + "\t        " + active);                
            }

            textc(textBox1, "\r\n____________________________________________________________________________________________\r\n", Color.Gray);
            
            if (writeToErrFile)
                if (isDynamic)
                    writeToErrorFile(time, boardNumber, partNumber, positiveCurrent, negativeCurrent, bit4, active);
                else
                    writeToErrorFile(time, boardNumber, partNumber, positiveCurrent, negativeCurrent, null, null);

            row++;
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            _serialPort.BaudRate = SERIAL_PORT_SPEED;
            if (this.isPowerData == false)
            {
                try
                {
                    string data = _serialPort.ReadLine();
                    string[] data1 = data.Split(',');
                    data1[1] = position_to_rowcol[Convert.ToInt16(data1[1])];

                    if (this.logData == true)
                    {
                        FileStream fs = new FileStream(this.myPath, FileMode.Append, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine(DateTime.Now.ToString() + "," + String.Join(",",data1));
                        sw.Close();
                        fs.Close();
                    }

                    if (this.textBox1.InvokeRequired)
                    {
                        try
                        {
                            incriment++;
                            if (isDynamic)
                                this.Invoke((MethodInvoker)(() => add_Data(DateTime.Now.ToString(), data1[0], data1[1], data1[2], data1[3], data1[4], data1[5])));
                            else
                                this.Invoke((MethodInvoker)(() => add_Data(DateTime.Now.ToString(), data1[0], data1[1], data1[2], data1[3], null, null)));
                        }
                        catch { }
                    }
                    else
                    {
                        incriment++;
                        if (isDynamic)
                            add_Data(DateTime.Now.ToString(), data1[0], data1[1], data1[2], data1[3], data1[4], data1[5]);
                        else
                            add_Data(DateTime.Now.ToString(), data1[0], data1[1], data1[2], data1[3], null, null);
                    }
                }
                catch (Exception)
                {

                }
            }
            if (this.isPowerData == true)
            {
                try
                {
                    string data1 = hexString2Ascii(_serialPort.ReadLine());

                    string[] temp = data1.Split('V');

                    try
                    {
                        this.powerReading = Convert.ToDouble(temp[1]);
                        if (this.powerReading < 5)
                        {
                            MailMessage mail = new MailMessage();
                            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                            mail.From = new MailAddress("rad1419monitor@gmail.com");
                            mail.To.Add("rad1419monitor@gmail.com");
                            mail.Subject = "Burn-In Monitoring System Error";
                            mail.Body = "you have lost power";

                            SmtpServer.Port = 587;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("rad1419monitor", "cobalt60");
                            SmtpServer.EnableSsl = true;

                            SmtpServer.Send(mail);
                        }
                    }
                    catch { }
                }
                catch { }
            }
        }

        public void Rollover(object sender, EventArgs e)
        {
            boardsToMonitor = Regex.Replace(boardsToMonitor, " ", "");

            string[] data = this.boardsToMonitor.Split(',');
            if (data.Length > 16) textBox1.AppendText("\r\nCollecting, please wait...\r\n\r\n");
            this.isPowerData = false;
            row = 0;
            row_data_structure.Clear();

            readMin = 0;
            readSec = 0;

            if (this.reportErrors == true) NextRead.Enabled = true;



            try
            {
                // hack to workaround sync issues between in/out of the serial port.
                // the hack is:
                // if "too many" boards are selected (>10), do a 3 sec sleep between the first two boards, then do the rest.
                // only necessary if 17 or 18 boards are being monitored
                if (data.Length > 16)
                {

                    for (int i = 0; i <= 0; i++)
                    {
                        if (int.Parse(data[i]) > 9)
                        {
                            int temp = int.Parse(data[i]) + 55;
                            char c = (char)temp;
                            _serialPort.Write("+" + c.ToString() + "-1");
                        }
                        else
                            _serialPort.Write("+" + data[i] + "-1");

                    }

                    System.Threading.Thread.Sleep(2250);

                    for (int i = 1; i <= 1; i++)
                    {
                        if (int.Parse(data[i]) > 9)
                        {
                            int temp = int.Parse(data[i]) + 55;
                            char c = (char)temp;
                            _serialPort.Write("+" + c.ToString() + "-1");
                        }
                        else
                            _serialPort.Write("+" + data[i] + "-1");
                    }
                    
                    System.Threading.Thread.Sleep(2250);

                    for (int j = 2; j <= 17; j++)
                    {
                        try
                        {
                            if (int.Parse(data[j]) > 9)
                            {
                                int temp = int.Parse(data[j]) + 55;
                                char c = (char)temp;
                                _serialPort.Write("+" + c.ToString() + "-1");
                            }
                            else
                                _serialPort.Write("+" + data[j] + "-1");

                        }
                        catch { }
                    }
                }

                else
                {
                    foreach (string s in data)
                    {
                        if (int.Parse(s) > 9)
                        {
                            int temp = int.Parse(s) + 55;
                            char c = (char)temp;
                            _serialPort.Write("+" + c.ToString() + "-1");
                        }
                        else
                            _serialPort.Write("+" + s + "-1");
                    }
                }
            }

            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message + "\r\n\r\nDouble-check COM port selection.", "COM Port Error");
                buttonStop_Click(sender, e);
            }
        }

        #endregion

        private int totalrows()
        {
            if (isdiag == true)
                return 20;

            if (boardsToMonitor == null)
                return 0;

            else
            {
                string[] listofboards = boardsToMonitor.Split(',');
                return listofboards.Length * 20;
            }
        }

        public void comPortComboBox_DropDown(object sender, EventArgs e)
        {
            List<String> tList = new List<String>();

            enterCOM.Items.Clear();

            foreach (string s in SerialPort.GetPortNames())
            {
                tList.Add(s);
            }
            tList.Sort();
            enterCOM.Items.AddRange(tList.ToArray());
            enterCOM.SelectedIndex = 0;
        }

        public string hexString2Ascii(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2),
                    System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }

        public string returnBoardNumber(int numBoardsTemp)
        {
            string numberOfBoardsToArduino = "";

            if (numBoardsTemp > 9)
            {
                numBoardsTemp = numBoardsTemp + 55;
                char c = (char)numBoardsTemp;
                numberOfBoardsToArduino = c.ToString();
                return numberOfBoardsToArduino;
            }
            else
            {
                numberOfBoardsToArduino = numBoardsTemp.ToString();
                return numberOfBoardsToArduino;
            }

        }

        private void buttonForce_Click(object sender, EventArgs e)
        {
            _serialPort.DiscardInBuffer();
            _serialPort.DiscardOutBuffer();
            incriment = 0;
            Rollover(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create and display a modless about dialog box.
            AboutBox1 about = new AboutBox1();
            about.Show();

            // Draw a blue square on the form.
            /* NOTE: This is not a persistent object, it will no longer be
               * visible after the next call to OnPaint. To make it persistent, 
               * override the OnPaint method and draw the square there */
            Graphics g = about.CreateGraphics();
            g.FillRectangle(Brushes.Blue, 10, 10, 50, 50);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
    }
}