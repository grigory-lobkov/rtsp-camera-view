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
            this.SuspendLayout();
            // 
            // WatchDogTimer
            // 
            this.WatchDogTimer.Interval = 50000;
            // 
            // SourceGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Name = "SourceGridControl";
            this.Size = new System.Drawing.Size(451, 435);
            this.Resize += new System.EventHandler(this.SourceGridControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer WatchDogTimer;
    }
}
