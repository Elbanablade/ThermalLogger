using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace burnInMonitor
{
    public partial class ChooseBoards : Form
    {
        public string ___checkedBoards;
        public string checkedBoards
        {
            get
            {
                return ___checkedBoards;
            }
            set
            {
                ___checkedBoards = value;
            }
        }

        public ChooseBoards()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            if (MainForm.globalboards != null) getprevresults();
            AcceptButton = buttonOK;
            CancelButton = buttonCancel;

            buttonOK.Enabled = false;
        }

        private void sendresults(object sender, EventArgs e)
        {
            for (int i = 0; i <= 17; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    checkedBoards += (i + 1).ToString() + ", ";
                }
            }
        }

        public void getprevresults()
        {
            string[] ischecked = MainForm.globalboards.TrimEnd().TrimEnd(',').Split(',');
            for (int i = 0; i < ischecked.Length; i++)
            {
                    ischecked[i] = (Int32.Parse(ischecked[i].Trim()) - 1).ToString();
                    checkedListBox1.SetItemCheckState(Int32.Parse(ischecked[i].Trim()), CheckState.Checked);
            }
        }

        private void checkedListBox1_ItemCheck(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int j = 0; j <= 17; j++)
            {
                checkedListBox1.SetItemCheckState(j, CheckState.Checked);
            }
            buttonOK.Focus();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            for (int j = 0; j <= 17; j++)
            {
                checkedListBox1.SetItemCheckState(j, CheckState.Unchecked);
            }
            buttonCancel.Focus();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            sendresults(sender, e);
            DialogResult = DialogResult.OK;
            Form.ActiveForm.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Form.ActiveForm.Close();
        }

        private void buttonEven_Click(object sender, EventArgs e)
        {
            buttonClearAll_Click(sender, e);
            int[] even = { 1, 3, 5, 7, 9, 11, 13, 15, 17 };
            foreach (int i in even)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Checked);
            }
            buttonOK.Focus();
        }

        private void buttonOdd_Click(object sender, EventArgs e)
        {
            buttonClearAll_Click(sender, e);
            int[] odd = { 0, 2, 4, 6, 8, 10, 12, 14, 16 };
            foreach (int i in odd)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Checked);
            }
            buttonOK.Focus();
        }
    }
}
