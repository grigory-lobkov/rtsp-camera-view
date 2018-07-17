namespace View.Components
{
    partial class SourceGridControl
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
            this.components = new System.ComponentModel.Container();
            this.WatchDogTimer = new System.Windows.Forms.Timer(this.components);
            this.EmailOnLostSignalTitle = new System.Windows.Forms.Label();
            this.EmailOnLostSignalSubject = new System.Windows.Forms.Label();
            this.EmailOnRestoreSignalSubject = new System.Windows.Forms.Label();
            this.EmailOnRestoreSignalTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WatchDogTimer
            // 
            this.WatchDogTimer.Interval = 50000;
            // 
            // EmailOnLostSignalTitle
            // 
            this.EmailOnLostSignalTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EmailOnLostSignalTitle.AutoSize = true;
            this.EmailOnLostSignalTitle.Location = new System.Drawing.Point(3, 251);
            this.EmailOnLostSignalTitle.Name = "EmailOnLostSignalTitle";
            this.EmailOnLostSignalTitle.Size = new System.Drawing.Size(91, 13);
            this.EmailOnLostSignalTitle.TabIndex = 0;
            this.EmailOnLostSignalTitle.Text = "{name} LOST link";
            this.EmailOnLostSignalTitle.Visible = false;
            // 
            // EmailOnLostSignalSubject
            // 
            this.EmailOnLostSignalSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EmailOnLostSignalSubject.AutoSize = true;
            this.EmailOnLostSignalSubject.Location = new System.Drawing.Point(3, 273);
            this.EmailOnLostSignalSubject.Name = "EmailOnLostSignalSubject";
            this.EmailOnLostSignalSubject.Size = new System.Drawing.Size(114, 104);
            this.EmailOnLostSignalSubject.TabIndex = 1;
            this.EmailOnLostSignalSubject.Text = "Signal of {name} is lost\r\n\r\nBad stream url:\r\n{bad}\r\n\r\nGood stream url:\r\n{good}\r\n\r" +
    "\n";
            this.EmailOnLostSignalSubject.Visible = false;
            // 
            // EmailOnRestoreSignalSubject
            // 
            this.EmailOnRestoreSignalSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EmailOnRestoreSignalSubject.AutoSize = true;
            this.EmailOnRestoreSignalSubject.Location = new System.Drawing.Point(157, 273);
            this.EmailOnRestoreSignalSubject.Name = "EmailOnRestoreSignalSubject";
            this.EmailOnRestoreSignalSubject.Size = new System.Drawing.Size(146, 104);
            this.EmailOnRestoreSignalSubject.TabIndex = 3;
            this.EmailOnRestoreSignalSubject.Text = "Signal of {name} is recovered\r\n\r\nBad stream url:\r\n{bad}\r\n\r\nGood stream url:\r\n{goo" +
    "d}\r\n\r\n";
            this.EmailOnRestoreSignalSubject.Visible = false;
            // 
            // EmailOnRestoreSignalTitle
            // 
            this.EmailOnRestoreSignalTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EmailOnRestoreSignalTitle.AutoSize = true;
            this.EmailOnRestoreSignalTitle.Location = new System.Drawing.Point(157, 251);
            this.EmailOnRestoreSignalTitle.Name = "EmailOnRestoreSignalTitle";
            this.EmailOnRestoreSignalTitle.Size = new System.Drawing.Size(111, 13);
            this.EmailOnRestoreSignalTitle.TabIndex = 2;
            this.EmailOnRestoreSignalTitle.Text = "{name} recovered link";
            this.EmailOnRestoreSignalTitle.Visible = false;
            // 
            // SourceGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Controls.Add(this.EmailOnRestoreSignalSubject);
            this.Controls.Add(this.EmailOnRestoreSignalTitle);
            this.Controls.Add(this.EmailOnLostSignalSubject);
            this.Controls.Add(this.EmailOnLostSignalTitle);
            this.Name = "SourceGridControl";
            this.Size = new System.Drawing.Size(470, 377);
            this.Resize += new System.EventHandler(this.SourceGridControl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer WatchDogTimer;
        private System.Windows.Forms.Label EmailOnLostSignalTitle;
        private System.Windows.Forms.Label EmailOnLostSignalSubject;
        private System.Windows.Forms.Label EmailOnRestoreSignalSubject;
        private System.Windows.Forms.Label EmailOnRestoreSignalTitle;
    }
}
