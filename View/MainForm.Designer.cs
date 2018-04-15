namespace View
{
    partial class MainForm
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
            this.controlPanel = new System.Windows.Forms.TabControl();
            this.sourcesPage = new System.Windows.Forms.TabPage();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.splitter = new System.Windows.Forms.Splitter();
            this.splitLabel = new System.Windows.Forms.Label();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.controlPanel.Controls.Add(this.sourcesPage);
            this.controlPanel.Controls.Add(this.settingsPage);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Padding = new System.Drawing.Point(10, 3);
            this.controlPanel.SelectedIndex = 0;
            this.controlPanel.Size = new System.Drawing.Size(238, 444);
            this.controlPanel.TabIndex = 1;
            this.controlPanel.SelectedIndexChanged += new System.EventHandler(this.controlPanel_SelectedIndexChanged);
            // 
            // sourcesPage
            // 
            this.sourcesPage.Location = new System.Drawing.Point(4, 25);
            this.sourcesPage.Margin = new System.Windows.Forms.Padding(0);
            this.sourcesPage.Name = "sourcesPage";
            this.sourcesPage.Size = new System.Drawing.Size(230, 415);
            this.sourcesPage.TabIndex = 0;
            this.sourcesPage.Text = "Sources";
            this.sourcesPage.UseVisualStyleBackColor = true;
            // 
            // settingsPage
            // 
            this.settingsPage.Location = new System.Drawing.Point(4, 25);
            this.settingsPage.Margin = new System.Windows.Forms.Padding(0);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Size = new System.Drawing.Size(230, 415);
            this.settingsPage.TabIndex = 1;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter.Location = new System.Drawing.Point(238, 0);
            this.splitter.MinSize = 100;
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(5, 444);
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            // 
            // splitLabel
            // 
            this.splitLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.splitLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.splitLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.splitLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.splitLabel.Location = new System.Drawing.Point(253, 215);
            this.splitLabel.Margin = new System.Windows.Forms.Padding(0);
            this.splitLabel.Name = "splitLabel";
            this.splitLabel.Size = new System.Drawing.Size(6, 36);
            this.splitLabel.TabIndex = 3;
            this.splitLabel.Text = ">>";
            this.splitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(825, 444);
            this.Controls.Add(this.splitLabel);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.controlPanel);
            this.Name = "MainForm";
            this.Text = "RTSP IP-camera Viewer";
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl controlPanel;
        private System.Windows.Forms.TabPage sourcesPage;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Label splitLabel;
    }
}