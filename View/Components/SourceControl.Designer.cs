namespace View.Components
{
    partial class SourceControl
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
            this.srcName = new System.Windows.Forms.Label();
            this.controlHideTimer = new System.Windows.Forms.Timer(this.components);
            this.hidePlayerPanel = new System.Windows.Forms.Panel();
            this.nameHideTimer = new System.Windows.Forms.Timer(this.components);
            this.topPanel = new View.Components.TopPanel();
            this.SuspendLayout();
            // 
            // srcName
            // 
            this.srcName.AutoSize = true;
            this.srcName.BackColor = System.Drawing.Color.Black;
            this.srcName.ForeColor = System.Drawing.Color.White;
            this.srcName.Location = new System.Drawing.Point(46, 18);
            this.srcName.Name = "srcName";
            this.srcName.Size = new System.Drawing.Size(59, 13);
            this.srcName.TabIndex = 0;
            this.srcName.Text = "nameLabel";
            // 
            // controlHideTimer
            // 
            this.controlHideTimer.Interval = 5000;
            // 
            // hidePlayerPanel
            // 
            this.hidePlayerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hidePlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hidePlayerPanel.Location = new System.Drawing.Point(0, 0);
            this.hidePlayerPanel.Name = "hidePlayerPanel";
            this.hidePlayerPanel.Size = new System.Drawing.Size(150, 150);
            this.hidePlayerPanel.TabIndex = 0;
            // 
            // nameHideTimer
            // 
            this.nameHideTimer.Interval = 5000;
            // 
            // topPanel
            // 
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(150, 150);
            this.topPanel.TabIndex = 1;
            // 
            // SourceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.srcName);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.hidePlayerPanel);
            this.Name = "SourceControl";
            this.Resize += new System.EventHandler(this.SourceControl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label srcName;
        private System.Windows.Forms.Timer controlHideTimer;
        private TopPanel topPanel;
        private System.Windows.Forms.Timer nameHideTimer;
        private System.Windows.Forms.Panel hidePlayerPanel;
    }
}
