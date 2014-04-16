namespace burnInMonitor
{
    partial class RecreateSetup
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecreateSetup));
            this.label = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(7, 10);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(394, 169);
            this.label.TabIndex = 0;
            this.label.Text = resources.GetString("label.Text");
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(325, 510);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.TabStop = false;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.button_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(9, 190);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(390, 305);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.Click += new System.EventHandler(this.richTextBox1_Click);
            // 
            // buttonCopy
            // 
            this.buttonCopy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.buttonCopy.Location = new System.Drawing.Point(70, 500);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(55, 20);
            this.buttonCopy.TabIndex = 0;
            this.buttonCopy.TabStop = false;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F);
            this.buttonSelectAll.Location = new System.Drawing.Point(10, 500);
            this.buttonSelectAll.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(55, 20);
            this.buttonSelectAll.TabIndex = 0;
            this.buttonSelectAll.TabStop = false;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = true;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // RecreateSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 543);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RecreateSetup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recreate Setup File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonSelectAll;
    }
}