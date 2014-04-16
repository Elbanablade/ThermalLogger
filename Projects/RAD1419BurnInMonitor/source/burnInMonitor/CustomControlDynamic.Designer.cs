namespace burnInMonitor
{
    partial class CustomControlDynamic
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.nNotificationBox = new System.Windows.Forms.TextBox();
            this.pNotificationBox = new System.Windows.Forms.TextBox();
            this.negTextBox = new System.Windows.Forms.TextBox();
            this.posTextBox = new System.Windows.Forms.TextBox();
            this.partNumberTextBox = new System.Windows.Forms.TextBox();
            this.boardNumberTextBox = new System.Windows.Forms.TextBox();
            this.bit4TextBox = new System.Windows.Forms.TextBox();
            this.activeTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timeTextBox
            // 
            this.timeTextBox.Location = new System.Drawing.Point(1, -1);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.ReadOnly = true;
            this.timeTextBox.Size = new System.Drawing.Size(124, 20);
            this.timeTextBox.TabIndex = 0;
            this.timeTextBox.TabStop = false;
            // 
            // nNotificationBox
            // 
            this.nNotificationBox.BackColor = System.Drawing.SystemColors.Control;
            this.nNotificationBox.Enabled = false;
            this.nNotificationBox.Location = new System.Drawing.Point(320, -1);
            this.nNotificationBox.Name = "nNotificationBox";
            this.nNotificationBox.Size = new System.Drawing.Size(20, 20);
            this.nNotificationBox.TabIndex = 0;
            this.nNotificationBox.TabStop = false;
            // 
            // pNotificationBox
            // 
            this.pNotificationBox.BackColor = System.Drawing.SystemColors.Control;
            this.pNotificationBox.Enabled = false;
            this.pNotificationBox.Location = new System.Drawing.Point(240, -1);
            this.pNotificationBox.Name = "pNotificationBox";
            this.pNotificationBox.Size = new System.Drawing.Size(20, 20);
            this.pNotificationBox.TabIndex = 0;
            this.pNotificationBox.TabStop = false;
            // 
            // negTextBox
            // 
            this.negTextBox.Location = new System.Drawing.Point(270, -1);
            this.negTextBox.Name = "negTextBox";
            this.negTextBox.ReadOnly = true;
            this.negTextBox.Size = new System.Drawing.Size(50, 20);
            this.negTextBox.TabIndex = 0;
            this.negTextBox.TabStop = false;
            // 
            // posTextBox
            // 
            this.posTextBox.Location = new System.Drawing.Point(190, -1);
            this.posTextBox.Name = "posTextBox";
            this.posTextBox.ReadOnly = true;
            this.posTextBox.Size = new System.Drawing.Size(50, 20);
            this.posTextBox.TabIndex = 0;
            this.posTextBox.TabStop = false;
            // 
            // partNumberTextBox
            // 
            this.partNumberTextBox.Location = new System.Drawing.Point(157, -1);
            this.partNumberTextBox.Name = "partNumberTextBox";
            this.partNumberTextBox.ReadOnly = true;
            this.partNumberTextBox.Size = new System.Drawing.Size(25, 20);
            this.partNumberTextBox.TabIndex = 0;
            this.partNumberTextBox.TabStop = false;
            // 
            // boardNumberTextBox
            // 
            this.boardNumberTextBox.Location = new System.Drawing.Point(129, -1);
            this.boardNumberTextBox.Name = "boardNumberTextBox";
            this.boardNumberTextBox.ReadOnly = true;
            this.boardNumberTextBox.Size = new System.Drawing.Size(25, 20);
            this.boardNumberTextBox.TabIndex = 0;
            this.boardNumberTextBox.TabStop = false;
            // 
            // bit4TextBox
            // 
            this.bit4TextBox.Location = new System.Drawing.Point(350, -1);
            this.bit4TextBox.Name = "bit4TextBox";
            this.bit4TextBox.ReadOnly = true;
            this.bit4TextBox.Size = new System.Drawing.Size(50, 20);
            this.bit4TextBox.TabIndex = 1;
            this.bit4TextBox.TabStop = false;
            // 
            // activeTextBox
            // 
            this.activeTextBox.Location = new System.Drawing.Point(400, -1);
            this.activeTextBox.Name = "activeTextBox";
            this.activeTextBox.ReadOnly = true;
            this.activeTextBox.Size = new System.Drawing.Size(50, 20);
            this.activeTextBox.TabIndex = 2;
            this.activeTextBox.TabStop = false;
            // 
            // CustomControlDynamic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.activeTextBox);
            this.Controls.Add(this.bit4TextBox);
            this.Controls.Add(this.timeTextBox);
            this.Controls.Add(this.nNotificationBox);
            this.Controls.Add(this.boardNumberTextBox);
            this.Controls.Add(this.pNotificationBox);
            this.Controls.Add(this.partNumberTextBox);
            this.Controls.Add(this.negTextBox);
            this.Controls.Add(this.posTextBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CustomControlDynamic";
            this.Size = new System.Drawing.Size(450, 19);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox partNumberTextBox;
        private System.Windows.Forms.TextBox boardNumberTextBox;
        private System.Windows.Forms.TextBox negTextBox;
        private System.Windows.Forms.TextBox posTextBox;
        private System.Windows.Forms.TextBox nNotificationBox;
        private System.Windows.Forms.TextBox pNotificationBox;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.TextBox bit4TextBox;
        private System.Windows.Forms.TextBox activeTextBox;

    }
}
