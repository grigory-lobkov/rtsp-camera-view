namespace View.Components
{
    partial class ModifySourceControl
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
            this.camNameInherit = new System.Windows.Forms.CheckBox();
            this.camNameShow = new System.Windows.Forms.CheckBox();
            this.camNameLabel = new System.Windows.Forms.Label();
            this.camName = new System.Windows.Forms.TextBox();
            this.delCamLabel = new System.Windows.Forms.Label();
            this.cancelCamButton = new System.Windows.Forms.Button();
            this.saveCamButton = new System.Windows.Forms.Button();
            this.camEditBtnsPanel = new System.Windows.Forms.Panel();
            this.createCamButton = new System.Windows.Forms.Button();
            this.cameraIcon = new System.Windows.Forms.ListView();
            this.aspectRatioLabel = new System.Windows.Forms.Label();
            this.aspectRatio = new System.Windows.Forms.TextBox();
            this.camEditIconLabel = new System.Windows.Forms.Label();
            this.rtspGood = new System.Windows.Forms.TextBox();
            this.rtspBad = new System.Windows.Forms.TextBox();
            this.camEditRtsp2Label = new System.Windows.Forms.Label();
            this.camEditRtsp1Label = new System.Windows.Forms.Label();
            this.camNameModify = new System.Windows.Forms.Label();
            this.cameraDeleteConfirm1 = new System.Windows.Forms.Label();
            this.cameraDeleteConfirm2 = new System.Windows.Forms.Label();
            this.rtspGoodOnlyInFullview = new System.Windows.Forms.CheckBox();
            this.camEditBtnsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // camNameInherit
            // 
            this.camNameInherit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.camNameInherit.AutoSize = true;
            this.camNameInherit.Checked = true;
            this.camNameInherit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.camNameInherit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.camNameInherit.Location = new System.Drawing.Point(84, 52);
            this.camNameInherit.Name = "camNameInherit";
            this.camNameInherit.Size = new System.Drawing.Size(85, 17);
            this.camNameInherit.TabIndex = 17;
            this.camNameInherit.TabStop = false;
            this.camNameInherit.Text = "inherit global";
            this.camNameInherit.UseVisualStyleBackColor = true;
            this.camNameInherit.CheckedChanged += new System.EventHandler(this.CamNameInherit_CheckedChanged);
            // 
            // camNameShow
            // 
            this.camNameShow.AutoSize = true;
            this.camNameShow.Checked = true;
            this.camNameShow.CheckState = System.Windows.Forms.CheckState.Checked;
            this.camNameShow.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.camNameShow.Location = new System.Drawing.Point(4, 52);
            this.camNameShow.Name = "camNameShow";
            this.camNameShow.Size = new System.Drawing.Size(51, 17);
            this.camNameShow.TabIndex = 15;
            this.camNameShow.TabStop = false;
            this.camNameShow.Text = "show";
            this.camNameShow.UseVisualStyleBackColor = true;
            this.camNameShow.CheckedChanged += new System.EventHandler(this.CamNameShow_CheckedChanged);
            // 
            // camNameLabel
            // 
            this.camNameLabel.AutoSize = true;
            this.camNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.camNameLabel.Location = new System.Drawing.Point(8, 5);
            this.camNameLabel.Name = "camNameLabel";
            this.camNameLabel.Size = new System.Drawing.Size(72, 13);
            this.camNameLabel.TabIndex = 9;
            this.camNameLabel.Text = "Camera name";
            // 
            // camName
            // 
            this.camName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.camName.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.camName.Location = new System.Drawing.Point(0, 29);
            this.camName.Name = "camName";
            this.camName.Size = new System.Drawing.Size(244, 20);
            this.camName.TabIndex = 14;
            this.camName.Text = "Place of mount, view area, e.t.c.";
            // 
            // delCamLabel
            // 
            this.delCamLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.delCamLabel.ForeColor = System.Drawing.Color.Red;
            this.delCamLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.delCamLabel.Location = new System.Drawing.Point(3, 60);
            this.delCamLabel.Name = "delCamLabel";
            this.delCamLabel.Size = new System.Drawing.Size(239, 19);
            this.delCamLabel.TabIndex = 22;
            this.delCamLabel.Text = "Delete camera";
            this.delCamLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.delCamLabel.Click += new System.EventHandler(this.DelCam_Click);
            this.delCamLabel.MouseEnter += new System.EventHandler(this.ButtonLabel_MouseEnter);
            this.delCamLabel.MouseLeave += new System.EventHandler(this.ButtonLabel_MouseLeave);
            // 
            // cancelCamButton
            // 
            this.cancelCamButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelCamButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelCamButton.Location = new System.Drawing.Point(133, 3);
            this.cancelCamButton.Name = "cancelCamButton";
            this.cancelCamButton.Size = new System.Drawing.Size(100, 30);
            this.cancelCamButton.TabIndex = 21;
            this.cancelCamButton.Text = "Cancel";
            this.cancelCamButton.UseVisualStyleBackColor = true;
            // 
            // saveCamButton
            // 
            this.saveCamButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.saveCamButton.Location = new System.Drawing.Point(11, 3);
            this.saveCamButton.Name = "saveCamButton";
            this.saveCamButton.Size = new System.Drawing.Size(100, 30);
            this.saveCamButton.TabIndex = 20;
            this.saveCamButton.Text = "Save";
            this.saveCamButton.UseVisualStyleBackColor = true;
            // 
            // camEditBtnsPanel
            // 
            this.camEditBtnsPanel.Controls.Add(this.createCamButton);
            this.camEditBtnsPanel.Controls.Add(this.delCamLabel);
            this.camEditBtnsPanel.Controls.Add(this.cancelCamButton);
            this.camEditBtnsPanel.Controls.Add(this.saveCamButton);
            this.camEditBtnsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.camEditBtnsPanel.Location = new System.Drawing.Point(0, 478);
            this.camEditBtnsPanel.Name = "camEditBtnsPanel";
            this.camEditBtnsPanel.Size = new System.Drawing.Size(245, 83);
            this.camEditBtnsPanel.TabIndex = 16;
            // 
            // createCamButton
            // 
            this.createCamButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.createCamButton.Location = new System.Drawing.Point(69, 27);
            this.createCamButton.Name = "createCamButton";
            this.createCamButton.Size = new System.Drawing.Size(100, 30);
            this.createCamButton.TabIndex = 23;
            this.createCamButton.Text = "Create";
            this.createCamButton.UseVisualStyleBackColor = true;
            // 
            // cameraIcon
            // 
            this.cameraIcon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cameraIcon.HideSelection = false;
            this.cameraIcon.Location = new System.Drawing.Point(0, 317);
            this.cameraIcon.Margin = new System.Windows.Forms.Padding(0);
            this.cameraIcon.MultiSelect = false;
            this.cameraIcon.Name = "cameraIcon";
            this.cameraIcon.Size = new System.Drawing.Size(244, 83);
            this.cameraIcon.TabIndex = 21;
            this.cameraIcon.TileSize = new System.Drawing.Size(60, 52);
            this.cameraIcon.UseCompatibleStateImageBehavior = false;
            this.cameraIcon.View = System.Windows.Forms.View.Tile;
            // 
            // aspectRatioLabel
            // 
            this.aspectRatioLabel.AutoSize = true;
            this.aspectRatioLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.aspectRatioLabel.Location = new System.Drawing.Point(8, 407);
            this.aspectRatioLabel.Name = "aspectRatioLabel";
            this.aspectRatioLabel.Size = new System.Drawing.Size(63, 13);
            this.aspectRatioLabel.TabIndex = 10;
            this.aspectRatioLabel.Text = "Aspect ratio";
            // 
            // aspectRatio
            // 
            this.aspectRatio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.aspectRatio.Location = new System.Drawing.Point(0, 427);
            this.aspectRatio.Name = "aspectRatio";
            this.aspectRatio.Size = new System.Drawing.Size(244, 20);
            this.aspectRatio.TabIndex = 22;
            // 
            // camEditIconLabel
            // 
            this.camEditIconLabel.AutoSize = true;
            this.camEditIconLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.camEditIconLabel.Location = new System.Drawing.Point(8, 296);
            this.camEditIconLabel.Name = "camEditIconLabel";
            this.camEditIconLabel.Size = new System.Drawing.Size(66, 13);
            this.camEditIconLabel.TabIndex = 11;
            this.camEditIconLabel.Text = "Camera icon";
            // 
            // rtspGood
            // 
            this.rtspGood.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtspGood.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.rtspGood.Location = new System.Drawing.Point(0, 199);
            this.rtspGood.Multiline = true;
            this.rtspGood.Name = "rtspGood";
            this.rtspGood.Size = new System.Drawing.Size(244, 60);
            this.rtspGood.TabIndex = 20;
            this.rtspGood.Text = "Ask camera vendor. Examples:\r\nrtsp://admin:1111@192.168.1.3/live/main\r\nrtsp://192" +
    ".168.1.4:554/av0_0&user=admin&password=1111";
            // 
            // rtspBad
            // 
            this.rtspBad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtspBad.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.rtspBad.Location = new System.Drawing.Point(0, 105);
            this.rtspBad.Multiline = true;
            this.rtspBad.Name = "rtspBad";
            this.rtspBad.Size = new System.Drawing.Size(244, 60);
            this.rtspBad.TabIndex = 19;
            this.rtspBad.Text = "Ask camera vendor. Examples:\r\nrtsp://admin:1111@192.168.1.3/live/sub\r\nrtsp://192." +
    "168.1.4:554/av0_1&user=admin&password=1111";
            // 
            // camEditRtsp2Label
            // 
            this.camEditRtsp2Label.AutoSize = true;
            this.camEditRtsp2Label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.camEditRtsp2Label.Location = new System.Drawing.Point(8, 179);
            this.camEditRtsp2Label.Name = "camEditRtsp2Label";
            this.camEditRtsp2Label.Size = new System.Drawing.Size(168, 13);
            this.camEditRtsp2Label.TabIndex = 12;
            this.camEditRtsp2Label.Text = "Good quality RTSP connect string";
            // 
            // camEditRtsp1Label
            // 
            this.camEditRtsp1Label.AutoSize = true;
            this.camEditRtsp1Label.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.camEditRtsp1Label.Location = new System.Drawing.Point(8, 84);
            this.camEditRtsp1Label.Name = "camEditRtsp1Label";
            this.camEditRtsp1Label.Size = new System.Drawing.Size(161, 13);
            this.camEditRtsp1Label.TabIndex = 13;
            this.camEditRtsp1Label.Text = "Bad quality RTSP connect string";
            // 
            // camNameModify
            // 
            this.camNameModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.camNameModify.ForeColor = System.Drawing.SystemColors.ControlText;
            this.camNameModify.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.camNameModify.Location = new System.Drawing.Point(130, 51);
            this.camNameModify.Name = "camNameModify";
            this.camNameModify.Size = new System.Drawing.Size(112, 17);
            this.camNameModify.TabIndex = 18;
            this.camNameModify.Text = "modify...";
            this.camNameModify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.camNameModify.MouseEnter += new System.EventHandler(this.ButtonLabel_MouseEnter);
            this.camNameModify.MouseLeave += new System.EventHandler(this.ButtonLabel_MouseLeave);
            // 
            // cameraDeleteConfirm1
            // 
            this.cameraDeleteConfirm1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cameraDeleteConfirm1.Location = new System.Drawing.Point(3, 448);
            this.cameraDeleteConfirm1.Name = "cameraDeleteConfirm1";
            this.cameraDeleteConfirm1.Size = new System.Drawing.Size(239, 13);
            this.cameraDeleteConfirm1.TabIndex = 23;
            this.cameraDeleteConfirm1.Text = "Do you really want to delete camera";
            this.cameraDeleteConfirm1.Visible = false;
            // 
            // cameraDeleteConfirm2
            // 
            this.cameraDeleteConfirm2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cameraDeleteConfirm2.Location = new System.Drawing.Point(3, 462);
            this.cameraDeleteConfirm2.Name = "cameraDeleteConfirm2";
            this.cameraDeleteConfirm2.Size = new System.Drawing.Size(239, 13);
            this.cameraDeleteConfirm2.TabIndex = 24;
            this.cameraDeleteConfirm2.Text = "You are watching this camera now. Are you sure?";
            this.cameraDeleteConfirm2.Visible = false;
            // 
            // rtspGoodOnlyInFullview
            // 
            this.rtspGoodOnlyInFullview.AutoSize = true;
            this.rtspGoodOnlyInFullview.Checked = true;
            this.rtspGoodOnlyInFullview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rtspGoodOnlyInFullview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rtspGoodOnlyInFullview.Location = new System.Drawing.Point(4, 262);
            this.rtspGoodOnlyInFullview.Name = "rtspGoodOnlyInFullview";
            this.rtspGoodOnlyInFullview.Size = new System.Drawing.Size(180, 17);
            this.rtspGoodOnlyInFullview.TabIndex = 25;
            this.rtspGoodOnlyInFullview.TabStop = false;
            this.rtspGoodOnlyInFullview.Text = "show only when in fullview mode";
            this.rtspGoodOnlyInFullview.UseVisualStyleBackColor = true;
            // 
            // ModifySourceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rtspGoodOnlyInFullview);
            this.Controls.Add(this.cameraDeleteConfirm1);
            this.Controls.Add(this.cameraDeleteConfirm2);
            this.Controls.Add(this.camNameInherit);
            this.Controls.Add(this.camNameShow);
            this.Controls.Add(this.camNameLabel);
            this.Controls.Add(this.camName);
            this.Controls.Add(this.camEditBtnsPanel);
            this.Controls.Add(this.cameraIcon);
            this.Controls.Add(this.aspectRatioLabel);
            this.Controls.Add(this.aspectRatio);
            this.Controls.Add(this.camEditIconLabel);
            this.Controls.Add(this.rtspGood);
            this.Controls.Add(this.rtspBad);
            this.Controls.Add(this.camEditRtsp2Label);
            this.Controls.Add(this.camEditRtsp1Label);
            this.Controls.Add(this.camNameModify);
            this.Name = "ModifySourceControl";
            this.Size = new System.Drawing.Size(245, 561);
            this.camEditBtnsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox camNameInherit;
        private System.Windows.Forms.CheckBox camNameShow;
        private System.Windows.Forms.Label camNameLabel;
        private System.Windows.Forms.TextBox camName;
        private System.Windows.Forms.Label delCamLabel;
        private System.Windows.Forms.Button cancelCamButton;
        private System.Windows.Forms.Button saveCamButton;
        private System.Windows.Forms.Panel camEditBtnsPanel;
        private System.Windows.Forms.ListView cameraIcon;
        private System.Windows.Forms.Label aspectRatioLabel;
        private System.Windows.Forms.TextBox aspectRatio;
        private System.Windows.Forms.Label camEditIconLabel;
        private System.Windows.Forms.TextBox rtspGood;
        private System.Windows.Forms.TextBox rtspBad;
        private System.Windows.Forms.Label camEditRtsp2Label;
        private System.Windows.Forms.Label camEditRtsp1Label;
        private System.Windows.Forms.Label camNameModify;
        private System.Windows.Forms.Button createCamButton;
        private System.Windows.Forms.Label cameraDeleteConfirm1;
        private System.Windows.Forms.Label cameraDeleteConfirm2;
        private System.Windows.Forms.CheckBox rtspGoodOnlyInFullview;
    }
}
