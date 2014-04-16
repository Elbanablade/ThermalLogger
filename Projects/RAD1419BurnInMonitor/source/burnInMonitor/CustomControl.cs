using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace burnInMonitor
{
    public partial class CustomControl : UserControl
    {
        string ___time
        {
            get
            {
                return this.timeTextBox.Text;
            }
            set
            {
                this.timeTextBox.Text = value;
            }
        }
        string ___boardNumber
        {
            get
            {
                return this.boardNumberTextBox.Text;
            }
            set
            {
                this.boardNumberTextBox.Text = value;
            }
        }
        string ___partNumber
        {
            get
            {
                return this.partNumberTextBox.Text;
            }
            set
            {
                this.partNumberTextBox.Text = value;
            }
        }
        string ___positiveCurrent
        {
            get
            {
                return this.posTextBox.Text;
            }
            set
            {
                this.posTextBox.Text = value;
            }
        }
        string ___negativeCurrent
        {
            get
            {
                return this.negTextBox.Text;
            }
            set
            {
                this.negTextBox.Text = value;
            }
        }

        public CustomControl()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        public CustomControl(string time, string boardNumber, string partNumber, string positiveCurrent, string negativeCurrent)
        {
            InitializeComponent();

            this.___time = time;
            this.___boardNumber = boardNumber;
            this.___partNumber = partNumber;
            this.___positiveCurrent = positiveCurrent;
            this.___negativeCurrent = negativeCurrent;
        }

        public void ChangeTheBackgroundOfPbox(Color newBackgroundColor)
        {
            this.pNotificationBox.BackColor = newBackgroundColor;
            this.pNotificationBox.Invalidate();
            this.pNotificationBox.Update();
            this.pNotificationBox.Enabled = false;
        }

        public void ChangeTheBackgroundOfNbox(Color newBackgroundColor)
        {
            this.nNotificationBox.BackColor = newBackgroundColor;
            this.nNotificationBox.Invalidate();
            this.nNotificationBox.Update();
            this.nNotificationBox.Enabled = false;
        }
    }
}
