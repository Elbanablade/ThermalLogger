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
    public partial class RecreateSetup : Form
    {
        public RecreateSetup()
        {
            InitializeComponent();
            richTextBox1.Focus();
            buttonCopy.Enabled = false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Form.ActiveForm.Close();
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            buttonCopy.Enabled = true;
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
            richTextBox1.Focus();
            richTextBox1.ScrollToCaret();
            buttonCopy.Enabled = true;
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }



      
    }
}
