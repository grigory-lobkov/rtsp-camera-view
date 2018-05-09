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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.controlPanel = new System.Windows.Forms.TabControl();
            this.sourcesPage = new System.Windows.Forms.TabPage();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.splitter = new System.Windows.Forms.Splitter();
            this.splitLabel = new System.Windows.Forms.Label();
            this.gridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fullScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitFullScreenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsAccesError = new System.Windows.Forms.Label();
            this.SettingsLoadError = new System.Windows.Forms.Label();
            this.SettingsSaveError = new System.Windows.Forms.Label();
            this.CreateGridCommonError = new System.Windows.Forms.Label();
            this.CreateGridNoLibError = new System.Windows.Forms.Label();
            this.CreateGridBadVerError = new System.Windows.Forms.Label();
            this.CreateGridEndError = new System.Windows.Forms.Label();
            this.hintRTSP2 = new System.Windows.Forms.Label();
            this.hintRTSP1 = new System.Windows.Forms.Label();
            this.hintDropCamera = new System.Windows.Forms.Label();
            this.hintAddCamera = new System.Windows.Forms.Label();
            this.hintOpenCtrl = new System.Windows.Forms.Label();
            this.showHintTimer = new System.Windows.Forms.Timer(this.components);
            this.hideHintTimer = new System.Windows.Forms.Timer(this.components);
            this.controlPanel.SuspendLayout();
            this.gridMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.sourcesPage);
            this.controlPanel.Controls.Add(this.settingsPage);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Padding = new System.Drawing.Point(10, 3);
            this.controlPanel.SelectedIndex = 0;
            this.controlPanel.Size = new System.Drawing.Size(285, 444);
            this.controlPanel.TabIndex = 1;
            this.controlPanel.SelectedIndexChanged += new System.EventHandler(this.ControlPanel_SelectedIndexChanged);
            // 
            // sourcesPage
            // 
            this.sourcesPage.Location = new System.Drawing.Point(4, 22);
            this.sourcesPage.Margin = new System.Windows.Forms.Padding(0);
            this.sourcesPage.Name = "sourcesPage";
            this.sourcesPage.Size = new System.Drawing.Size(277, 418);
            this.sourcesPage.TabIndex = 0;
            this.sourcesPage.Text = "Sources";
            this.sourcesPage.UseVisualStyleBackColor = true;
            // 
            // settingsPage
            // 
            this.settingsPage.Location = new System.Drawing.Point(4, 22);
            this.settingsPage.Margin = new System.Windows.Forms.Padding(0);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Size = new System.Drawing.Size(277, 418);
            this.settingsPage.TabIndex = 1;
            this.settingsPage.Text = "Settings";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // splitter
            // 
            this.splitter.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter.Location = new System.Drawing.Point(285, 0);
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
            this.splitLabel.Location = new System.Drawing.Point(293, 215);
            this.splitLabel.Margin = new System.Windows.Forms.Padding(0);
            this.splitLabel.Name = "splitLabel";
            this.splitLabel.Size = new System.Drawing.Size(6, 36);
            this.splitLabel.TabIndex = 3;
            this.splitLabel.Text = ">>";
            this.splitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridMenu
            // 
            this.gridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullScreenMenuItem,
            this.exitFullScreenMenuItem});
            this.gridMenu.Name = "contextMenuStrip1";
            this.gridMenu.Size = new System.Drawing.Size(152, 48);
            // 
            // fullScreenMenuItem
            // 
            this.fullScreenMenuItem.Name = "fullScreenMenuItem";
            this.fullScreenMenuItem.Size = new System.Drawing.Size(151, 22);
            this.fullScreenMenuItem.Text = "Full screen";
            // 
            // exitFullScreenMenuItem
            // 
            this.exitFullScreenMenuItem.Name = "exitFullScreenMenuItem";
            this.exitFullScreenMenuItem.Size = new System.Drawing.Size(151, 22);
            this.exitFullScreenMenuItem.Text = "Exit Full screen";
            // 
            // SettingsAccesError
            // 
            this.SettingsAccesError.AutoSize = true;
            this.SettingsAccesError.ForeColor = System.Drawing.Color.White;
            this.SettingsAccesError.Location = new System.Drawing.Point(296, 422);
            this.SettingsAccesError.Name = "SettingsAccesError";
            this.SettingsAccesError.Size = new System.Drawing.Size(262, 13);
            this.SettingsAccesError.TabIndex = 4;
            this.SettingsAccesError.Text = "Error accessing settings file, your work won\'t be saved";
            this.SettingsAccesError.Visible = false;
            // 
            // SettingsLoadError
            // 
            this.SettingsLoadError.AutoSize = true;
            this.SettingsLoadError.ForeColor = System.Drawing.Color.White;
            this.SettingsLoadError.Location = new System.Drawing.Point(296, 409);
            this.SettingsLoadError.Name = "SettingsLoadError";
            this.SettingsLoadError.Size = new System.Drawing.Size(121, 13);
            this.SettingsLoadError.TabIndex = 5;
            this.SettingsLoadError.Text = "Error loading settings file";
            this.SettingsLoadError.Visible = false;
            // 
            // SettingsSaveError
            // 
            this.SettingsSaveError.AutoSize = true;
            this.SettingsSaveError.ForeColor = System.Drawing.Color.White;
            this.SettingsSaveError.Location = new System.Drawing.Point(296, 396);
            this.SettingsSaveError.Name = "SettingsSaveError";
            this.SettingsSaveError.Size = new System.Drawing.Size(118, 13);
            this.SettingsSaveError.TabIndex = 6;
            this.SettingsSaveError.Text = "Error saving settings file";
            this.SettingsSaveError.Visible = false;
            // 
            // CreateGridCommonError
            // 
            this.CreateGridCommonError.AutoSize = true;
            this.CreateGridCommonError.ForeColor = System.Drawing.Color.White;
            this.CreateGridCommonError.Location = new System.Drawing.Point(296, 308);
            this.CreateGridCommonError.Name = "CreateGridCommonError";
            this.CreateGridCommonError.Size = new System.Drawing.Size(126, 13);
            this.CreateGridCommonError.TabIndex = 7;
            this.CreateGridCommonError.Text = "Error creating players grid";
            this.CreateGridCommonError.Visible = false;
            // 
            // CreateGridNoLibError
            // 
            this.CreateGridNoLibError.AutoSize = true;
            this.CreateGridNoLibError.ForeColor = System.Drawing.Color.White;
            this.CreateGridNoLibError.Location = new System.Drawing.Point(296, 321);
            this.CreateGridNoLibError.Name = "CreateGridNoLibError";
            this.CreateGridNoLibError.Size = new System.Drawing.Size(247, 13);
            this.CreateGridNoLibError.TabIndex = 8;
            this.CreateGridNoLibError.Text = "Can\'t find VLC and/or ActiveX Web-plugin installed";
            this.CreateGridNoLibError.Visible = false;
            // 
            // CreateGridBadVerError
            // 
            this.CreateGridBadVerError.AutoSize = true;
            this.CreateGridBadVerError.ForeColor = System.Drawing.Color.White;
            this.CreateGridBadVerError.Location = new System.Drawing.Point(296, 334);
            this.CreateGridBadVerError.Name = "CreateGridBadVerError";
            this.CreateGridBadVerError.Size = new System.Drawing.Size(194, 13);
            this.CreateGridBadVerError.TabIndex = 9;
            this.CreateGridBadVerError.Text = "Please, check your VLC version is 2.1.x";
            this.CreateGridBadVerError.Visible = false;
            // 
            // CreateGridEndError
            // 
            this.CreateGridEndError.ForeColor = System.Drawing.Color.White;
            this.CreateGridEndError.Location = new System.Drawing.Point(296, 347);
            this.CreateGridEndError.Name = "CreateGridEndError";
            this.CreateGridEndError.Size = new System.Drawing.Size(222, 13);
            this.CreateGridEndError.TabIndex = 10;
            this.CreateGridEndError.Text = resources.GetString("CreateGridEndError.Text");
            this.CreateGridEndError.Visible = false;
            // 
            // hintRTSP2
            // 
            this.hintRTSP2.AutoSize = true;
            this.hintRTSP2.BackColor = System.Drawing.SystemColors.Info;
            this.hintRTSP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintRTSP2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hintRTSP2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hintRTSP2.Location = new System.Drawing.Point(602, 180);
            this.hintRTSP2.Name = "hintRTSP2";
            this.hintRTSP2.Padding = new System.Windows.Forms.Padding(9, 7, 9, 8);
            this.hintRTSP2.Size = new System.Drawing.Size(217, 69);
            this.hintRTSP2.TabIndex = 12;
            this.hintRTSP2.Text = "Good RTSP connect string, which\r\nproduces high network load.\r\nTo show in big wind" +
    "ows.\r\nSwiching between RTSPs is automated.";
            this.hintRTSP2.Visible = false;
            // 
            // hintRTSP1
            // 
            this.hintRTSP1.AutoSize = true;
            this.hintRTSP1.BackColor = System.Drawing.SystemColors.Info;
            this.hintRTSP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintRTSP1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hintRTSP1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hintRTSP1.Location = new System.Drawing.Point(602, 126);
            this.hintRTSP1.Name = "hintRTSP1";
            this.hintRTSP1.Padding = new System.Windows.Forms.Padding(9, 6, 9, 7);
            this.hintRTSP1.Size = new System.Drawing.Size(182, 54);
            this.hintRTSP1.TabIndex = 13;
            this.hintRTSP1.Text = "Bad RTSP connect string, which\r\nproduces minimal network load.\r\nTo show in small " +
    "windows.";
            this.hintRTSP1.Visible = false;
            // 
            // hintDropCamera
            // 
            this.hintDropCamera.AutoSize = true;
            this.hintDropCamera.BackColor = System.Drawing.SystemColors.Info;
            this.hintDropCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintDropCamera.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hintDropCamera.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hintDropCamera.Location = new System.Drawing.Point(602, 87);
            this.hintDropCamera.Name = "hintDropCamera";
            this.hintDropCamera.Padding = new System.Windows.Forms.Padding(9, 5, 9, 6);
            this.hintDropCamera.Size = new System.Drawing.Size(186, 39);
            this.hintDropCamera.TabIndex = 11;
            this.hintDropCamera.Text = "Drag camera by mouse left-button\r\nand drop somewhere on grid here";
            this.hintDropCamera.Visible = false;
            // 
            // hintAddCamera
            // 
            this.hintAddCamera.AutoSize = true;
            this.hintAddCamera.BackColor = System.Drawing.SystemColors.Info;
            this.hintAddCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintAddCamera.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hintAddCamera.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hintAddCamera.Location = new System.Drawing.Point(602, 48);
            this.hintAddCamera.Name = "hintAddCamera";
            this.hintAddCamera.Padding = new System.Windows.Forms.Padding(9, 5, 9, 6);
            this.hintAddCamera.Size = new System.Drawing.Size(169, 39);
            this.hintAddCamera.TabIndex = 14;
            this.hintAddCamera.Text = "Right-click on this area to Add\r\nnew camera";
            this.hintAddCamera.Visible = false;
            // 
            // hintOpenCtrl
            // 
            this.hintOpenCtrl.AutoSize = true;
            this.hintOpenCtrl.BackColor = System.Drawing.SystemColors.Info;
            this.hintOpenCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintOpenCtrl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hintOpenCtrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.hintOpenCtrl.Location = new System.Drawing.Point(602, 9);
            this.hintOpenCtrl.Name = "hintOpenCtrl";
            this.hintOpenCtrl.Padding = new System.Windows.Forms.Padding(9, 5, 9, 6);
            this.hintOpenCtrl.Size = new System.Drawing.Size(179, 39);
            this.hintOpenCtrl.TabIndex = 15;
            this.hintOpenCtrl.Text = "Open control panel to Add/View\r\navailable cameras";
            this.hintOpenCtrl.Visible = false;
            // 
            // showHintTimer
            // 
            this.showHintTimer.Interval = 5000;
            this.showHintTimer.Tick += new System.EventHandler(this.ShowHintTimer_Tick);
            // 
            // hideHintTimer
            // 
            this.hideHintTimer.Interval = 30000;
            this.hideHintTimer.Tick += new System.EventHandler(this.HideHintTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(825, 444);
            this.Controls.Add(this.hintDropCamera);
            this.Controls.Add(this.hintRTSP2);
            this.Controls.Add(this.hintRTSP1);
            this.Controls.Add(this.hintAddCamera);
            this.Controls.Add(this.hintOpenCtrl);
            this.Controls.Add(this.CreateGridEndError);
            this.Controls.Add(this.CreateGridBadVerError);
            this.Controls.Add(this.CreateGridNoLibError);
            this.Controls.Add(this.CreateGridCommonError);
            this.Controls.Add(this.SettingsSaveError);
            this.Controls.Add(this.SettingsLoadError);
            this.Controls.Add(this.SettingsAccesError);
            this.Controls.Add(this.splitLabel);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.controlPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "RTSP IP-camera Viewer";
            this.controlPanel.ResumeLayout(false);
            this.gridMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl controlPanel;
        private System.Windows.Forms.TabPage sourcesPage;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.Label splitLabel;
        private System.Windows.Forms.ContextMenuStrip gridMenu;
        private System.Windows.Forms.ToolStripMenuItem fullScreenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitFullScreenMenuItem;
        private System.Windows.Forms.Label SettingsAccesError;
        private System.Windows.Forms.Label SettingsLoadError;
        private System.Windows.Forms.Label SettingsSaveError;
        private System.Windows.Forms.Label CreateGridCommonError;
        private System.Windows.Forms.Label CreateGridNoLibError;
        private System.Windows.Forms.Label CreateGridBadVerError;
        private System.Windows.Forms.Label CreateGridEndError;
        private System.Windows.Forms.Label hintRTSP2;
        private System.Windows.Forms.Label hintRTSP1;
        private System.Windows.Forms.Label hintDropCamera;
        private System.Windows.Forms.Label hintAddCamera;
        private System.Windows.Forms.Label hintOpenCtrl;
        private System.Windows.Forms.Timer showHintTimer;
        private System.Windows.Forms.Timer hideHintTimer;
    }
}