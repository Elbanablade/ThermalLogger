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
    public partial class CustomControlDynamic : UserControl
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
        string ___bit4
        {
            get
            {
                return this.bit4TextBox.Text;
            }
            set
            {
                this.bit4TextBox.Text = value;
            }
        }
        string ___active
        {
            get
            {
                return this.activeTextBox.Text;
            }
            set
            {
                this.activeTextBox.Text = value;
            }
        }

        public CustomControlDynamic()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
        }

        public CustomControlDynamic(string time, string boardNumber, string partNumber, string positiveCurrent, string negativeCurrent, string bit4, string active)
        {
            InitializeComponent();

            this.___time = time;
            this.___boardNumber = boardNumber;
            this.___partNumber = partNumber;
            this.___positiveCurrent = positiveCurrent;
            this.___negativeCurrent = negativeCurrent;
            this.___bit4 = bit4;
            this.___active = active;
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
