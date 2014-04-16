namespace burnInMonitor
{
    partial class ChooseBoards
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.buttonSelectAll = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEven = new System.Windows.Forms.Button();
            this.buttonOdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.ColumnWidth = 90;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18"});
            this.checkedListBox1.Location = new System.Drawing.Point(25, 80);
            this.checkedListBox1.Margin = new System.Windows.Forms.Padding(0);
            this.checkedListBox1.MultiColumn = true;
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(185, 154);
            this.checkedListBox1.TabIndex = 0;
            this.checkedListBox1.TabStop = false;
            this.checkedListBox1.ThreeDCheckBoxes = true;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClearAll.Location = new System.Drawing.Point(155, 55);
            this.buttonClearAll.Margin = new System.Windows.Forms.Padding(0);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(55, 20);
            this.buttonClearAll.TabIndex = 0;
            this.buttonClearAll.TabStop = false;
            this.buttonClearAll.Text = "Clear All";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // buttonSelectAll
            // 
            this.buttonSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectAll.Location = new System.Drawing.Point(90, 55);
            this.buttonSelectAll.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSelectAll.Name = "buttonSelectAll";
            this.buttonSelectAll.Size = new System.Drawing.Size(55, 20);
            this.buttonSelectAll.TabIndex = 0;
            this.buttonSelectAll.TabStop = false;
            this.buttonSelectAll.Text = "Select All";
            this.buttonSelectAll.UseVisualStyleBackColor = false;
            this.buttonSelectAll.Click += new System.EventHandler(this.buttonSelectAll_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(25, 250);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 25);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(125, 250);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(85, 25);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Use the check boxes to select the boards\r\non which to perform burn-in monitoring." +
    "";
            // 
            // buttonEven
            // 
            this.buttonEven.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonEven.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.buttonEven.Location = new System.Drawing.Point(25, 40);
            this.buttonEven.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEven.Name = "buttonEven";
            this.buttonEven.Size = new System.Drawing.Size(35, 18);
            this.buttonEven.TabIndex = 0;
            this.buttonEven.TabStop = false;
            this.buttonEven.Text = "Even";
            this.buttonEven.UseVisualStyleBackColor = false;
            this.buttonEven.Click += new System.EventHandler(this.buttonEven_Click);
            // 
            // buttonOdd
            // 
            this.buttonOdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonOdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.buttonOdd.Location = new System.Drawing.Point(25, 60);
            this.buttonOdd.Margin = new System.Windows.Forms.Padding(0);
            this.buttonOdd.Name = "buttonOdd";
            this.buttonOdd.Size = new System.Drawing.Size(35, 18);
            this.buttonOdd.TabIndex = 0;
            this.buttonOdd.TabStop = false;
            this.buttonOdd.Text = "Odd";
            this.buttonOdd.UseVisualStyleBackColor = false;
            this.buttonOdd.Click += new System.EventHandler(this.buttonOdd_Click);
            // 
            // ChooseBoards
            // 
            this.AcceptButton = this.buttonOK;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Dialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(234, 293);
            this.Controls.Add(this.buttonOdd);
            this.Controls.Add(this.buttonEven);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonSelectAll);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.checkedListBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseBoards";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose Boards to Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.Button buttonSelectAll;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEven;
        private System.Windows.Forms.Button buttonOdd;
    }
}