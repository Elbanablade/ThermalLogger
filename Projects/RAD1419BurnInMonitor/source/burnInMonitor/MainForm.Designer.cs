namespace burnInMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (System.Exception) { }  
        }*/

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSetupFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToLogfile = new System.Windows.Forms.ToolStripMenuItem();
            this.quit = new System.Windows.Forms.ToolStripMenuItem();
            this.setup = new System.Windows.Forms.ToolStripMenuItem();
            this.chooseBoards = new System.Windows.Forms.ToolStripMenuItem();
            this.runDiagnostic = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreSetupFile = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enterCOM = new System.Windows.Forms.ComboBox();
            this.enterPCurrent = new System.Windows.Forms.TextBox();
            this.enterNCurrent = new System.Windows.Forms.TextBox();
            this.enterDiag = new System.Windows.Forms.TextBox();
            this.enterInterval = new System.Windows.Forms.TextBox();
            this.checkSaveToFile = new System.Windows.Forms.CheckBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.labelPCurrent = new System.Windows.Forms.Label();
            this.labelNCurrent = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelDiag = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.buttonCOM = new System.Windows.Forms.Button();
            this.labelPanelBoard = new System.Windows.Forms.Label();
            this.labelPanelSocket = new System.Windows.Forms.Label();
            this.labelPanelPositive = new System.Windows.Forms.Label();
            this.labelPanelNegative = new System.Windows.Forms.Label();
            this.statusCOM = new System.Windows.Forms.Label();
            this.statusPCurrent = new System.Windows.Forms.Label();
            this.statusNCurrent = new System.Windows.Forms.Label();
            this.statusError = new System.Windows.Forms.Label();
            this.statusDiag = new System.Windows.Forms.Label();
            this.statusInterval = new System.Windows.Forms.Label();
            this.buttonDiag = new System.Windows.Forms.Button();
            this.statusbarToday = new System.Windows.Forms.Label();
            this.statusbarElapsed = new System.Windows.Forms.Label();
            this.statusbarNextRead = new System.Windows.Forms.Label();
            this.groupMainParameters = new System.Windows.Forms.GroupBox();
            this.enterError = new System.Windows.Forms.TextBox();
            this.groupDiag = new System.Windows.Forms.GroupBox();
            this.groupPortSelection = new System.Windows.Forms.GroupBox();
            this.labelDetected = new System.Windows.Forms.Label();
            this.groupBoards = new System.Windows.Forms.GroupBox();
            this.statusChooseBoards = new System.Windows.Forms.TextBox();
            this.buttonChooseBoards = new System.Windows.Forms.Button();
            this.groupProgramSetup = new System.Windows.Forms.GroupBox();
            this.buttonEnterManual = new System.Windows.Forms.Button();
            this.buttonLoadSetup = new System.Windows.Forms.Button();
            this.buttonForce = new System.Windows.Forms.Button();
            this.labelPanelBit4 = new System.Windows.Forms.Label();
            this.labelPanelActive = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.menuStrip.SuspendLayout();
            this.groupMainParameters.SuspendLayout();
            this.groupDiag.SuspendLayout();
            this.groupPortSelection.SuspendLayout();
            this.groupBoards.SuspendLayout();
            this.groupProgramSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.setup,
            this.help});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(688, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSetupFile,
            this.saveToLogfile,
            this.quit});
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(35, 20);
            this.file.Text = "File";
            // 
            // loadSetupFile
            // 
            this.loadSetupFile.Name = "loadSetupFile";
            this.loadSetupFile.Size = new System.Drawing.Size(158, 22);
            this.loadSetupFile.Text = "Load Setup File";
            this.loadSetupFile.Click += new System.EventHandler(this.loadSetupFile_Click);
            // 
            // saveToLogfile
            // 
            this.saveToLogfile.Name = "saveToLogfile";
            this.saveToLogfile.Size = new System.Drawing.Size(158, 22);
            this.saveToLogfile.Text = "Save to Logfile";
            this.saveToLogfile.Click += new System.EventHandler(this.save_Click);
            // 
            // quit
            // 
            this.quit.Name = "quit";
            this.quit.Size = new System.Drawing.Size(158, 22);
            this.quit.Text = "Quit";
            this.quit.Click += new System.EventHandler(this.quit_Click);
            // 
            // setup
            // 
            this.setup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseBoards,
            this.runDiagnostic});
            this.setup.Name = "setup";
            this.setup.Size = new System.Drawing.Size(47, 20);
            this.setup.Text = "Setup";
            // 
            // chooseBoards
            // 
            this.chooseBoards.Name = "chooseBoards";
            this.chooseBoards.Size = new System.Drawing.Size(157, 22);
            this.chooseBoards.Text = "Choose Boards";
            this.chooseBoards.Click += new System.EventHandler(this.chooseBoards_Click);
            // 
            // runDiagnostic
            // 
            this.runDiagnostic.Name = "runDiagnostic";
            this.runDiagnostic.Size = new System.Drawing.Size(157, 22);
            this.runDiagnostic.Text = "Run Diagnostic";
            this.runDiagnostic.Click += new System.EventHandler(this.runDiagnostic_Click);
            // 
            // help
            // 
            this.help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restoreSetupFile,
            this.about,
            this.aboutToolStripMenuItem});
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(40, 20);
            this.help.Text = "Help";
            // 
            // restoreSetupFile
            // 
            this.restoreSetupFile.Name = "restoreSetupFile";
            this.restoreSetupFile.Size = new System.Drawing.Size(173, 22);
            this.restoreSetupFile.Text = "Restore Setup File";
            this.restoreSetupFile.Click += new System.EventHandler(this.restoreSetupFile_Click);
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(173, 22);
            this.about.Text = "Program Help";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // enterCOM
            // 
            this.enterCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enterCOM.FormattingEnabled = true;
            this.enterCOM.IntegralHeight = false;
            this.enterCOM.Location = new System.Drawing.Point(10, 20);
            this.enterCOM.Name = "enterCOM";
            this.enterCOM.Size = new System.Drawing.Size(100, 21);
            this.enterCOM.TabIndex = 0;
            this.enterCOM.TabStop = false;
            this.enterCOM.DropDown += new System.EventHandler(this.comPortComboBox_DropDown);
            this.enterCOM.SelectedIndexChanged += new System.EventHandler(this.enterCOM_SelectedIndexChanged);
            // 
            // enterPCurrent
            // 
            this.enterPCurrent.Location = new System.Drawing.Point(10, 40);
            this.enterPCurrent.MaxLength = 5;
            this.enterPCurrent.Name = "enterPCurrent";
            this.enterPCurrent.Size = new System.Drawing.Size(55, 20);
            this.enterPCurrent.TabIndex = 0;
            this.enterPCurrent.TabStop = false;
            this.enterPCurrent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enterP_Current_KeyPress);
            // 
            // enterNCurrent
            // 
            this.enterNCurrent.Location = new System.Drawing.Point(125, 40);
            this.enterNCurrent.MaxLength = 5;
            this.enterNCurrent.Name = "enterNCurrent";
            this.enterNCurrent.Size = new System.Drawing.Size(55, 20);
            this.enterNCurrent.TabIndex = 0;
            this.enterNCurrent.TabStop = false;
            this.enterNCurrent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enterN_Current_KeyPress);
            // 
            // enterDiag
            // 
            this.enterDiag.Location = new System.Drawing.Point(10, 25);
            this.enterDiag.MaxLength = 2;
            this.enterDiag.Name = "enterDiag";
            this.enterDiag.Size = new System.Drawing.Size(55, 20);
            this.enterDiag.TabIndex = 0;
            this.enterDiag.TabStop = false;
            this.enterDiag.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enterDiag_KeyPress);
            // 
            // enterInterval
            // 
            this.enterInterval.Location = new System.Drawing.Point(240, 40);
            this.enterInterval.MaxLength = 3;
            this.enterInterval.Name = "enterInterval";
            this.enterInterval.Size = new System.Drawing.Size(55, 20);
            this.enterInterval.TabIndex = 0;
            this.enterInterval.TabStop = false;
            this.enterInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enterInterval_KeyPress);
            // 
            // checkSaveToFile
            // 
            this.checkSaveToFile.AutoSize = true;
            this.checkSaveToFile.BackColor = System.Drawing.Color.Transparent;
            this.checkSaveToFile.Location = new System.Drawing.Point(23, 95);
            this.checkSaveToFile.Margin = new System.Windows.Forms.Padding(0);
            this.checkSaveToFile.Name = "checkSaveToFile";
            this.checkSaveToFile.Size = new System.Drawing.Size(101, 17);
            this.checkSaveToFile.TabIndex = 0;
            this.checkSaveToFile.TabStop = false;
            this.checkSaveToFile.Text = "Save To Logfile";
            this.checkSaveToFile.UseVisualStyleBackColor = false;
            this.checkSaveToFile.Click += new System.EventHandler(this.checkSaveToFile_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonStart.Location = new System.Drawing.Point(6, 449);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 25);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.TabStop = false;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.Transparent;
            this.buttonStop.Location = new System.Drawing.Point(94, 449);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 25);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.TabStop = false;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // labelPCurrent
            // 
            this.labelPCurrent.AutoSize = true;
            this.labelPCurrent.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelPCurrent.Location = new System.Drawing.Point(10, 25);
            this.labelPCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.labelPCurrent.Name = "labelPCurrent";
            this.labelPCurrent.Size = new System.Drawing.Size(47, 13);
            this.labelPCurrent.TabIndex = 0;
            this.labelPCurrent.Text = "+Current";
            // 
            // labelNCurrent
            // 
            this.labelNCurrent.AutoSize = true;
            this.labelNCurrent.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelNCurrent.Location = new System.Drawing.Point(125, 25);
            this.labelNCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.labelNCurrent.Name = "labelNCurrent";
            this.labelNCurrent.Size = new System.Drawing.Size(44, 13);
            this.labelNCurrent.TabIndex = 0;
            this.labelNCurrent.Text = "-Current";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelError.Location = new System.Drawing.Point(355, 25);
            this.labelError.Margin = new System.Windows.Forms.Padding(0);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(40, 13);
            this.labelError.TabIndex = 0;
            this.labelError.Text = "Error %";
            // 
            // labelDiag
            // 
            this.labelDiag.AutoSize = true;
            this.labelDiag.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelDiag.Location = new System.Drawing.Point(10, 10);
            this.labelDiag.Name = "labelDiag";
            this.labelDiag.Size = new System.Drawing.Size(57, 13);
            this.labelDiag.TabIndex = 0;
            this.labelDiag.Text = "Diagnostic";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.BackColor = System.Drawing.Color.Transparent;
            this.labelInterval.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelInterval.Location = new System.Drawing.Point(240, 10);
            this.labelInterval.Margin = new System.Windows.Forms.Padding(0);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(42, 26);
            this.labelInterval.TabIndex = 0;
            this.labelInterval.Text = "Read\r\nInterval";
            // 
            // buttonCOM
            // 
            this.buttonCOM.BackColor = System.Drawing.Color.Transparent;
            this.buttonCOM.Location = new System.Drawing.Point(120, 18);
            this.buttonCOM.Name = "buttonCOM";
            this.buttonCOM.Size = new System.Drawing.Size(50, 25);
            this.buttonCOM.TabIndex = 0;
            this.buttonCOM.TabStop = false;
            this.buttonCOM.Text = "Open";
            this.buttonCOM.UseVisualStyleBackColor = false;
            this.buttonCOM.Click += new System.EventHandler(this.buttonCOM_Click);
            // 
            // labelPanelBoard
            // 
            this.labelPanelBoard.AutoSize = true;
            this.labelPanelBoard.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.labelPanelBoard.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelPanelBoard.Location = new System.Drawing.Point(338, 120);
            this.labelPanelBoard.Name = "labelPanelBoard";
            this.labelPanelBoard.Size = new System.Drawing.Size(23, 13);
            this.labelPanelBoard.TabIndex = 0;
            this.labelPanelBoard.Text = "Brd";
            this.labelPanelBoard.Visible = false;
            // 
            // labelPanelSocket
            // 
            this.labelPanelSocket.AutoSize = true;
            this.labelPanelSocket.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.labelPanelSocket.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelPanelSocket.Location = new System.Drawing.Point(380, 120);
            this.labelPanelSocket.Name = "labelPanelSocket";
            this.labelPanelSocket.Size = new System.Drawing.Size(22, 13);
            this.labelPanelSocket.TabIndex = 0;
            this.labelPanelSocket.Text = "Skt";
            this.labelPanelSocket.Visible = false;
            // 
            // labelPanelPositive
            // 
            this.labelPanelPositive.AutoSize = true;
            this.labelPanelPositive.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.labelPanelPositive.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelPanelPositive.Location = new System.Drawing.Point(428, 120);
            this.labelPanelPositive.Name = "labelPanelPositive";
            this.labelPanelPositive.Size = new System.Drawing.Size(47, 13);
            this.labelPanelPositive.TabIndex = 0;
            this.labelPanelPositive.Text = "Positive ";
            this.labelPanelPositive.Visible = false;
            // 
            // labelPanelNegative
            // 
            this.labelPanelNegative.AutoSize = true;
            this.labelPanelNegative.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.labelPanelNegative.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelPanelNegative.Location = new System.Drawing.Point(487, 120);
            this.labelPanelNegative.Name = "labelPanelNegative";
            this.labelPanelNegative.Size = new System.Drawing.Size(49, 13);
            this.labelPanelNegative.TabIndex = 0;
            this.labelPanelNegative.Text = "Negative";
            this.labelPanelNegative.Visible = false;
            // 
            // statusCOM
            // 
            this.statusCOM.AutoSize = true;
            this.statusCOM.Location = new System.Drawing.Point(18, 45);
            this.statusCOM.Name = "statusCOM";
            this.statusCOM.Size = new System.Drawing.Size(85, 13);
            this.statusCOM.TabIndex = 0;
            this.statusCOM.Text = "Select COM port";
            this.statusCOM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusPCurrent
            // 
            this.statusPCurrent.AutoSize = true;
            this.statusPCurrent.Location = new System.Drawing.Point(10, 65);
            this.statusPCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.statusPCurrent.Name = "statusPCurrent";
            this.statusPCurrent.Size = new System.Drawing.Size(47, 26);
            this.statusPCurrent.TabIndex = 0;
            this.statusPCurrent.Text = "Enter\r\n+Current";
            // 
            // statusNCurrent
            // 
            this.statusNCurrent.AutoSize = true;
            this.statusNCurrent.Location = new System.Drawing.Point(125, 65);
            this.statusNCurrent.Margin = new System.Windows.Forms.Padding(0);
            this.statusNCurrent.Name = "statusNCurrent";
            this.statusNCurrent.Size = new System.Drawing.Size(44, 26);
            this.statusNCurrent.TabIndex = 0;
            this.statusNCurrent.Text = "Enter\r\n-Current";
            // 
            // statusError
            // 
            this.statusError.AutoSize = true;
            this.statusError.BackColor = System.Drawing.Color.Transparent;
            this.statusError.Location = new System.Drawing.Point(355, 65);
            this.statusError.Margin = new System.Windows.Forms.Padding(0);
            this.statusError.Name = "statusError";
            this.statusError.Size = new System.Drawing.Size(40, 26);
            this.statusError.TabIndex = 0;
            this.statusError.Text = "Enter\r\nError %";
            // 
            // statusDiag
            // 
            this.statusDiag.AutoSize = true;
            this.statusDiag.Location = new System.Drawing.Point(10, 48);
            this.statusDiag.Name = "statusDiag";
            this.statusDiag.Size = new System.Drawing.Size(45, 26);
            this.statusDiag.TabIndex = 0;
            this.statusDiag.Text = "Enter\r\nBoard #";
            // 
            // statusInterval
            // 
            this.statusInterval.AutoSize = true;
            this.statusInterval.BackColor = System.Drawing.Color.Transparent;
            this.statusInterval.Location = new System.Drawing.Point(240, 65);
            this.statusInterval.Margin = new System.Windows.Forms.Padding(0);
            this.statusInterval.Name = "statusInterval";
            this.statusInterval.Size = new System.Drawing.Size(42, 26);
            this.statusInterval.TabIndex = 0;
            this.statusInterval.Text = "Enter\r\nInterval";
            // 
            // buttonDiag
            // 
            this.buttonDiag.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonDiag.Location = new System.Drawing.Point(75, 25);
            this.buttonDiag.Name = "buttonDiag";
            this.buttonDiag.Size = new System.Drawing.Size(90, 35);
            this.buttonDiag.TabIndex = 0;
            this.buttonDiag.TabStop = false;
            this.buttonDiag.Text = "Run Diagnostic";
            this.buttonDiag.Click += new System.EventHandler(this.buttonDiag_Click);
            // 
            // statusbarToday
            // 
            this.statusbarToday.AutoSize = true;
            this.statusbarToday.BackColor = System.Drawing.Color.Transparent;
            this.statusbarToday.ForeColor = System.Drawing.Color.MediumBlue;
            this.statusbarToday.Location = new System.Drawing.Point(3, 672);
            this.statusbarToday.Name = "statusbarToday";
            this.statusbarToday.Size = new System.Drawing.Size(38, 26);
            this.statusbarToday.TabIndex = 0;
            this.statusbarToday.Text = "Time\r\nof Day";
            this.statusbarToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusbarElapsed
            // 
            this.statusbarElapsed.AutoSize = true;
            this.statusbarElapsed.BackColor = System.Drawing.Color.Transparent;
            this.statusbarElapsed.ForeColor = System.Drawing.Color.MediumBlue;
            this.statusbarElapsed.Location = new System.Drawing.Point(112, 672);
            this.statusbarElapsed.Name = "statusbarElapsed";
            this.statusbarElapsed.Size = new System.Drawing.Size(45, 26);
            this.statusbarElapsed.TabIndex = 0;
            this.statusbarElapsed.Text = "Time\r\nElapsed";
            this.statusbarElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusbarNextRead
            // 
            this.statusbarNextRead.AutoSize = true;
            this.statusbarNextRead.BackColor = System.Drawing.Color.Transparent;
            this.statusbarNextRead.ForeColor = System.Drawing.Color.MediumBlue;
            this.statusbarNextRead.Location = new System.Drawing.Point(227, 672);
            this.statusbarNextRead.Name = "statusbarNextRead";
            this.statusbarNextRead.Size = new System.Drawing.Size(58, 26);
            this.statusbarNextRead.TabIndex = 0;
            this.statusbarNextRead.Text = "Time Until\r\nNext Read";
            this.statusbarNextRead.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupMainParameters
            // 
            this.groupMainParameters.BackColor = System.Drawing.Color.Transparent;
            this.groupMainParameters.Controls.Add(this.enterError);
            this.groupMainParameters.Controls.Add(this.enterPCurrent);
            this.groupMainParameters.Controls.Add(this.enterNCurrent);
            this.groupMainParameters.Controls.Add(this.enterInterval);
            this.groupMainParameters.Controls.Add(this.labelError);
            this.groupMainParameters.Controls.Add(this.labelPCurrent);
            this.groupMainParameters.Controls.Add(this.statusError);
            this.groupMainParameters.Controls.Add(this.labelNCurrent);
            this.groupMainParameters.Controls.Add(this.statusPCurrent);
            this.groupMainParameters.Controls.Add(this.statusNCurrent);
            this.groupMainParameters.Controls.Add(this.statusInterval);
            this.groupMainParameters.Controls.Add(this.labelInterval);
            this.groupMainParameters.Location = new System.Drawing.Point(200, 24);
            this.groupMainParameters.Name = "groupMainParameters";
            this.groupMainParameters.Size = new System.Drawing.Size(485, 95);
            this.groupMainParameters.TabIndex = 0;
            this.groupMainParameters.TabStop = false;
            // 
            // enterError
            // 
            this.enterError.Location = new System.Drawing.Point(355, 40);
            this.enterError.MaxLength = 3;
            this.enterError.Name = "enterError";
            this.enterError.Size = new System.Drawing.Size(55, 20);
            this.enterError.TabIndex = 0;
            this.enterError.TabStop = false;
            this.enterError.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.enterError_KeyPress);
            // 
            // groupDiag
            // 
            this.groupDiag.BackColor = System.Drawing.Color.Transparent;
            this.groupDiag.Controls.Add(this.buttonDiag);
            this.groupDiag.Controls.Add(this.enterDiag);
            this.groupDiag.Controls.Add(this.statusDiag);
            this.groupDiag.Controls.Add(this.labelDiag);
            this.groupDiag.Location = new System.Drawing.Point(0, 102);
            this.groupDiag.Name = "groupDiag";
            this.groupDiag.Size = new System.Drawing.Size(180, 78);
            this.groupDiag.TabIndex = 0;
            this.groupDiag.TabStop = false;
            // 
            // groupPortSelection
            // 
            this.groupPortSelection.BackColor = System.Drawing.Color.Transparent;
            this.groupPortSelection.Controls.Add(this.labelDetected);
            this.groupPortSelection.Controls.Add(this.enterCOM);
            this.groupPortSelection.Controls.Add(this.buttonCOM);
            this.groupPortSelection.Controls.Add(this.statusCOM);
            this.groupPortSelection.Location = new System.Drawing.Point(8, 24);
            this.groupPortSelection.Name = "groupPortSelection";
            this.groupPortSelection.Size = new System.Drawing.Size(180, 95);
            this.groupPortSelection.TabIndex = 0;
            this.groupPortSelection.TabStop = false;
            this.groupPortSelection.Text = "Port Selection";
            // 
            // labelDetected
            // 
            this.labelDetected.AutoSize = true;
            this.labelDetected.Location = new System.Drawing.Point(20, 75);
            this.labelDetected.Name = "labelDetected";
            this.labelDetected.Size = new System.Drawing.Size(0, 13);
            this.labelDetected.TabIndex = 1;
            this.labelDetected.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBoards
            // 
            this.groupBoards.BackColor = System.Drawing.Color.Transparent;
            this.groupBoards.Controls.Add(this.groupDiag);
            this.groupBoards.Controls.Add(this.statusChooseBoards);
            this.groupBoards.Controls.Add(this.buttonChooseBoards);
            this.groupBoards.Location = new System.Drawing.Point(8, 256);
            this.groupBoards.Name = "groupBoards";
            this.groupBoards.Size = new System.Drawing.Size(180, 180);
            this.groupBoards.TabIndex = 0;
            this.groupBoards.TabStop = false;
            this.groupBoards.Text = "Board Selection";
            // 
            // statusChooseBoards
            // 
            this.statusChooseBoards.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusChooseBoards.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.statusChooseBoards.Location = new System.Drawing.Point(13, 60);
            this.statusChooseBoards.Multiline = true;
            this.statusChooseBoards.Name = "statusChooseBoards";
            this.statusChooseBoards.ReadOnly = true;
            this.statusChooseBoards.ShortcutsEnabled = false;
            this.statusChooseBoards.Size = new System.Drawing.Size(155, 45);
            this.statusChooseBoards.TabIndex = 0;
            this.statusChooseBoards.TabStop = false;
            this.statusChooseBoards.Text = "\r\nChoose Boards to Monitor";
            this.statusChooseBoards.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.statusChooseBoards.GotFocus += new System.EventHandler(this.labelBoards_GotFocus);
            // 
            // buttonChooseBoards
            // 
            this.buttonChooseBoards.BackColor = System.Drawing.Color.Transparent;
            this.buttonChooseBoards.Location = new System.Drawing.Point(55, 20);
            this.buttonChooseBoards.Name = "buttonChooseBoards";
            this.buttonChooseBoards.Size = new System.Drawing.Size(60, 35);
            this.buttonChooseBoards.TabIndex = 0;
            this.buttonChooseBoards.TabStop = false;
            this.buttonChooseBoards.Text = "Choose Boards";
            this.buttonChooseBoards.UseVisualStyleBackColor = false;
            this.buttonChooseBoards.Click += new System.EventHandler(this.buttonChooseBoards_Click);
            // 
            // groupProgramSetup
            // 
            this.groupProgramSetup.BackColor = System.Drawing.Color.Transparent;
            this.groupProgramSetup.Controls.Add(this.buttonEnterManual);
            this.groupProgramSetup.Controls.Add(this.buttonLoadSetup);
            this.groupProgramSetup.Controls.Add(this.checkSaveToFile);
            this.groupProgramSetup.Location = new System.Drawing.Point(8, 120);
            this.groupProgramSetup.Name = "groupProgramSetup";
            this.groupProgramSetup.Size = new System.Drawing.Size(180, 135);
            this.groupProgramSetup.TabIndex = 0;
            this.groupProgramSetup.TabStop = false;
            this.groupProgramSetup.Text = "Program Setup";
            // 
            // buttonEnterManual
            // 
            this.buttonEnterManual.BackColor = System.Drawing.Color.Transparent;
            this.buttonEnterManual.Location = new System.Drawing.Point(23, 50);
            this.buttonEnterManual.Name = "buttonEnterManual";
            this.buttonEnterManual.Size = new System.Drawing.Size(135, 25);
            this.buttonEnterManual.TabIndex = 0;
            this.buttonEnterManual.TabStop = false;
            this.buttonEnterManual.Text = "Enter Manual Parameters";
            this.buttonEnterManual.UseVisualStyleBackColor = false;
            this.buttonEnterManual.Click += new System.EventHandler(this.buttonEnterManual_Click);
            // 
            // buttonLoadSetup
            // 
            this.buttonLoadSetup.BackColor = System.Drawing.Color.Transparent;
            this.buttonLoadSetup.Location = new System.Drawing.Point(23, 20);
            this.buttonLoadSetup.Name = "buttonLoadSetup";
            this.buttonLoadSetup.Size = new System.Drawing.Size(135, 25);
            this.buttonLoadSetup.TabIndex = 0;
            this.buttonLoadSetup.TabStop = false;
            this.buttonLoadSetup.Text = "Load Setup Parameters";
            this.buttonLoadSetup.UseVisualStyleBackColor = false;
            this.buttonLoadSetup.Click += new System.EventHandler(this.buttonLoadSetup_Click);
            // 
            // buttonForce
            // 
            this.buttonForce.BackColor = System.Drawing.Color.Transparent;
            this.buttonForce.Location = new System.Drawing.Point(8, 480);
            this.buttonForce.Name = "buttonForce";
            this.buttonForce.Size = new System.Drawing.Size(75, 25);
            this.buttonForce.TabIndex = 48;
            this.buttonForce.Text = "Force Read";
            this.buttonForce.UseVisualStyleBackColor = false;
            this.buttonForce.Click += new System.EventHandler(this.buttonForce_Click);
            // 
            // labelPanelBit4
            // 
            this.labelPanelBit4.AutoSize = true;
            this.labelPanelBit4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.labelPanelBit4.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelPanelBit4.Location = new System.Drawing.Point(540, 120);
            this.labelPanelBit4.Name = "labelPanelBit4";
            this.labelPanelBit4.Size = new System.Drawing.Size(25, 13);
            this.labelPanelBit4.TabIndex = 49;
            this.labelPanelBit4.Text = "Bit4";
            this.labelPanelBit4.Visible = false;
            // 
            // labelPanelActive
            // 
            this.labelPanelActive.AutoSize = true;
            this.labelPanelActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.labelPanelActive.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelPanelActive.Location = new System.Drawing.Point(592, 120);
            this.labelPanelActive.Name = "labelPanelActive";
            this.labelPanelActive.Size = new System.Drawing.Size(36, 13);
            this.labelPanelActive.TabIndex = 50;
            this.labelPanelActive.Text = "Active";
            this.labelPanelActive.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(196, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Time";
            this.label2.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.AcceptsTab = true;
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(192, 136);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.textBox1.Size = new System.Drawing.Size(485, 528);
            this.textBox1.TabIndex = 0;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "";
            this.textBox1.WordWrap = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(600, 672);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 56;
            this.buttonClear.Text = "Clear Panel";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(688, 701);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelPanelActive);
            this.Controls.Add(this.labelPanelBit4);
            this.Controls.Add(this.labelPanelNegative);
            this.Controls.Add(this.labelPanelPositive);
            this.Controls.Add(this.labelPanelSocket);
            this.Controls.Add(this.labelPanelBoard);
            this.Controls.Add(this.buttonForce);
            this.Controls.Add(this.groupProgramSetup);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.groupBoards);
            this.Controls.Add(this.groupPortSelection);
            this.Controls.Add(this.groupMainParameters);
            this.Controls.Add(this.statusbarNextRead);
            this.Controls.Add(this.statusbarElapsed);
            this.Controls.Add(this.statusbarToday);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.textBox1);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "1419 Burn-In Monitor";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupMainParameters.ResumeLayout(false);
            this.groupMainParameters.PerformLayout();
            this.groupDiag.ResumeLayout(false);
            this.groupDiag.PerformLayout();
            this.groupPortSelection.ResumeLayout(false);
            this.groupPortSelection.PerformLayout();
            this.groupBoards.ResumeLayout(false);
            this.groupBoards.PerformLayout();
            this.groupProgramSetup.ResumeLayout(false);
            this.groupProgramSetup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem saveToLogfile;
        private System.Windows.Forms.ToolStripMenuItem quit;
        private System.Windows.Forms.ToolStripMenuItem setup;
        private System.Windows.Forms.ToolStripMenuItem chooseBoards;
        private System.Windows.Forms.ToolStripMenuItem help;
        private System.Windows.Forms.ToolStripMenuItem about;

        private System.Windows.Forms.ComboBox enterCOM;
        private System.Windows.Forms.TextBox enterPCurrent;
        private System.Windows.Forms.TextBox enterNCurrent;
        private System.Windows.Forms.TextBox enterDiag;
        private System.Windows.Forms.TextBox enterInterval;
        private System.Windows.Forms.CheckBox checkSaveToFile;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Label labelPCurrent;
        private System.Windows.Forms.Label labelNCurrent;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelDiag;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Button buttonCOM;
        private System.Windows.Forms.Label labelPanelBoard;
        private System.Windows.Forms.Label labelPanelSocket;
        private System.Windows.Forms.Label labelPanelPositive;
        private System.Windows.Forms.Label labelPanelNegative;

        private System.Windows.Forms.Label statusCOM;
        private System.Windows.Forms.Label statusPCurrent;
        private System.Windows.Forms.Label statusNCurrent;
        private System.Windows.Forms.Label statusError;
        private System.Windows.Forms.Label statusDiag;
        private System.Windows.Forms.Label statusInterval;
        private System.Windows.Forms.Button buttonDiag;
        private System.Windows.Forms.Label statusbarToday;
        private System.Windows.Forms.Label statusbarElapsed;
        private System.Windows.Forms.Label statusbarNextRead;
        private System.Windows.Forms.GroupBox groupMainParameters;
        private System.Windows.Forms.GroupBox groupDiag;
        private System.Windows.Forms.GroupBox groupPortSelection;
        private System.Windows.Forms.GroupBox groupBoards;
        private System.Windows.Forms.Button buttonChooseBoards;

        private System.Windows.Forms.TextBox statusChooseBoards;
        private System.Windows.Forms.TextBox enterError;
        private System.Windows.Forms.GroupBox groupProgramSetup;
        private System.Windows.Forms.Button buttonLoadSetup;
        private System.Windows.Forms.Button buttonEnterManual;
        private System.Windows.Forms.ToolStripMenuItem loadSetupFile;
        private System.Windows.Forms.ToolStripMenuItem runDiagnostic;
        private System.Windows.Forms.ToolStripMenuItem restoreSetupFile;
        private System.Windows.Forms.Label labelDetected;
        private System.Windows.Forms.Button buttonForce;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label labelPanelBit4;
        private System.Windows.Forms.Label labelPanelActive;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox textBox1;
        private System.Windows.Forms.Button buttonClear;
    }
}

