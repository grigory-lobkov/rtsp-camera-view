namespace View
{
    partial class NameViewSetupForm
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.autoHideTrackBar = new System.Windows.Forms.TrackBar();
            this.autoHideCheckBox = new System.Windows.Forms.CheckBox();
            this.textSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.textSizeLabel = new System.Windows.Forms.Label();
            this.backgroundCheckBox = new System.Windows.Forms.CheckBox();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.positioningLabel = new System.Windows.Forms.Label();
            this.positioningPanel = new System.Windows.Forms.Panel();
            this.camNameLabel = new System.Windows.Forms.Label();
            this.bottomRightButton = new System.Windows.Forms.Button();
            this.bottomCenterButton = new System.Windows.Forms.Button();
            this.bottomLeftButton = new System.Windows.Forms.Button();
            this.topRightButton = new System.Windows.Forms.Button();
            this.topCenterButton = new System.Windows.Forms.Button();
            this.topLeftButton = new System.Windows.Forms.Button();
            this.textColorButton = new System.Windows.Forms.Button();
            this.textColorLabel = new System.Windows.Forms.Label();
            this.textColorPanel = new System.Windows.Forms.Panel();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.autoHideTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSizeTrackBar)).BeginInit();
            this.positioningPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cancelButton.Location = new System.Drawing.Point(170, 407);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 29;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.okButton.Location = new System.Drawing.Point(67, 407);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 28;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // autoHideTrackBar
            // 
            this.autoHideTrackBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.autoHideTrackBar.LargeChange = 3;
            this.autoHideTrackBar.Location = new System.Drawing.Point(34, 349);
            this.autoHideTrackBar.Maximum = 30;
            this.autoHideTrackBar.Minimum = 1;
            this.autoHideTrackBar.Name = "autoHideTrackBar";
            this.autoHideTrackBar.Size = new System.Drawing.Size(247, 45);
            this.autoHideTrackBar.TabIndex = 27;
            this.autoHideTrackBar.Value = 1;
            // 
            // autoHideCheckBox
            // 
            this.autoHideCheckBox.AutoSize = true;
            this.autoHideCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.autoHideCheckBox.Location = new System.Drawing.Point(19, 326);
            this.autoHideCheckBox.Name = "autoHideCheckBox";
            this.autoHideCheckBox.Size = new System.Drawing.Size(112, 17);
            this.autoHideCheckBox.TabIndex = 26;
            this.autoHideCheckBox.Text = "Hide automatically";
            this.autoHideCheckBox.UseVisualStyleBackColor = true;
            this.autoHideCheckBox.Click += new System.EventHandler(this.AutoHideCheckBox_Click);
            // 
            // textSizeTrackBar
            // 
            this.textSizeTrackBar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textSizeTrackBar.LargeChange = 3;
            this.textSizeTrackBar.Location = new System.Drawing.Point(34, 267);
            this.textSizeTrackBar.Minimum = 1;
            this.textSizeTrackBar.Name = "textSizeTrackBar";
            this.textSizeTrackBar.Size = new System.Drawing.Size(247, 45);
            this.textSizeTrackBar.TabIndex = 25;
            this.textSizeTrackBar.Value = 1;
            // 
            // textSizeLabel
            // 
            this.textSizeLabel.AutoSize = true;
            this.textSizeLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textSizeLabel.Location = new System.Drawing.Point(12, 251);
            this.textSizeLabel.Name = "textSizeLabel";
            this.textSizeLabel.Size = new System.Drawing.Size(49, 13);
            this.textSizeLabel.TabIndex = 24;
            this.textSizeLabel.Text = "Text size";
            // 
            // backgroundCheckBox
            // 
            this.backgroundCheckBox.AutoSize = true;
            this.backgroundCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.backgroundCheckBox.Location = new System.Drawing.Point(15, 217);
            this.backgroundCheckBox.Name = "backgroundCheckBox";
            this.backgroundCheckBox.Size = new System.Drawing.Size(84, 17);
            this.backgroundCheckBox.TabIndex = 23;
            this.backgroundCheckBox.Text = "Background";
            this.backgroundCheckBox.UseVisualStyleBackColor = true;
            // 
            // backgroundButton
            // 
            this.backgroundButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.backgroundButton.Location = new System.Drawing.Point(250, 213);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(31, 23);
            this.backgroundButton.TabIndex = 21;
            this.backgroundButton.Text = "...";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.BackgroundButton_Click);
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundPanel.Location = new System.Drawing.Point(151, 213);
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.Size = new System.Drawing.Size(82, 23);
            this.backgroundPanel.TabIndex = 22;
            // 
            // positioningLabel
            // 
            this.positioningLabel.AutoSize = true;
            this.positioningLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.positioningLabel.Location = new System.Drawing.Point(12, 9);
            this.positioningLabel.Name = "positioningLabel";
            this.positioningLabel.Size = new System.Drawing.Size(58, 13);
            this.positioningLabel.TabIndex = 19;
            this.positioningLabel.Text = "Positioning";
            // 
            // positioningPanel
            // 
            this.positioningPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.positioningPanel.Controls.Add(this.camNameLabel);
            this.positioningPanel.Controls.Add(this.bottomRightButton);
            this.positioningPanel.Controls.Add(this.bottomCenterButton);
            this.positioningPanel.Controls.Add(this.bottomLeftButton);
            this.positioningPanel.Controls.Add(this.topRightButton);
            this.positioningPanel.Controls.Add(this.topCenterButton);
            this.positioningPanel.Controls.Add(this.topLeftButton);
            this.positioningPanel.Location = new System.Drawing.Point(34, 32);
            this.positioningPanel.Name = "positioningPanel";
            this.positioningPanel.Size = new System.Drawing.Size(247, 129);
            this.positioningPanel.TabIndex = 18;
            // 
            // camNameLabel
            // 
            this.camNameLabel.AutoSize = true;
            this.camNameLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.camNameLabel.Location = new System.Drawing.Point(101, 55);
            this.camNameLabel.Name = "camNameLabel";
            this.camNameLabel.Size = new System.Drawing.Size(35, 13);
            this.camNameLabel.TabIndex = 13;
            this.camNameLabel.Text = "Name";
            this.camNameLabel.Visible = false;
            // 
            // bottomRightButton
            // 
            this.bottomRightButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bottomRightButton.Location = new System.Drawing.Point(192, 104);
            this.bottomRightButton.Name = "bottomRightButton";
            this.bottomRightButton.Size = new System.Drawing.Size(50, 20);
            this.bottomRightButton.TabIndex = 12;
            this.bottomRightButton.UseVisualStyleBackColor = true;
            // 
            // bottomCenterButton
            // 
            this.bottomCenterButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bottomCenterButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bottomCenterButton.Location = new System.Drawing.Point(95, 104);
            this.bottomCenterButton.Name = "bottomCenterButton";
            this.bottomCenterButton.Size = new System.Drawing.Size(50, 20);
            this.bottomCenterButton.TabIndex = 11;
            this.bottomCenterButton.UseVisualStyleBackColor = true;
            // 
            // bottomLeftButton
            // 
            this.bottomLeftButton.BackColor = System.Drawing.SystemColors.Control;
            this.bottomLeftButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.bottomLeftButton.Location = new System.Drawing.Point(3, 104);
            this.bottomLeftButton.Name = "bottomLeftButton";
            this.bottomLeftButton.Size = new System.Drawing.Size(50, 20);
            this.bottomLeftButton.TabIndex = 10;
            this.bottomLeftButton.UseVisualStyleBackColor = true;
            // 
            // topRightButton
            // 
            this.topRightButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.topRightButton.Location = new System.Drawing.Point(192, 3);
            this.topRightButton.Name = "topRightButton";
            this.topRightButton.Size = new System.Drawing.Size(50, 20);
            this.topRightButton.TabIndex = 9;
            this.topRightButton.UseVisualStyleBackColor = true;
            // 
            // topCenterButton
            // 
            this.topCenterButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.topCenterButton.Location = new System.Drawing.Point(95, 3);
            this.topCenterButton.Name = "topCenterButton";
            this.topCenterButton.Size = new System.Drawing.Size(50, 20);
            this.topCenterButton.TabIndex = 8;
            this.topCenterButton.UseVisualStyleBackColor = true;
            // 
            // topLeftButton
            // 
            this.topLeftButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.topLeftButton.Location = new System.Drawing.Point(3, 3);
            this.topLeftButton.Name = "topLeftButton";
            this.topLeftButton.Size = new System.Drawing.Size(50, 20);
            this.topLeftButton.TabIndex = 7;
            this.topLeftButton.UseVisualStyleBackColor = true;
            // 
            // textColorButton
            // 
            this.textColorButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textColorButton.Location = new System.Drawing.Point(250, 180);
            this.textColorButton.Name = "textColorButton";
            this.textColorButton.Size = new System.Drawing.Size(31, 23);
            this.textColorButton.TabIndex = 17;
            this.textColorButton.Text = "...";
            this.textColorButton.UseVisualStyleBackColor = true;
            this.textColorButton.Click += new System.EventHandler(this.TextColorButton_Click);
            // 
            // textColorLabel
            // 
            this.textColorLabel.AutoSize = true;
            this.textColorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textColorLabel.Location = new System.Drawing.Point(12, 185);
            this.textColorLabel.Name = "textColorLabel";
            this.textColorLabel.Size = new System.Drawing.Size(54, 13);
            this.textColorLabel.TabIndex = 16;
            this.textColorLabel.Text = "Text color";
            // 
            // textColorPanel
            // 
            this.textColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textColorPanel.Location = new System.Drawing.Point(151, 180);
            this.textColorPanel.Name = "textColorPanel";
            this.textColorPanel.Size = new System.Drawing.Size(82, 23);
            this.textColorPanel.TabIndex = 20;
            // 
            // NameViewSetupForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(311, 450);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.autoHideTrackBar);
            this.Controls.Add(this.autoHideCheckBox);
            this.Controls.Add(this.textSizeTrackBar);
            this.Controls.Add(this.textSizeLabel);
            this.Controls.Add(this.backgroundCheckBox);
            this.Controls.Add(this.backgroundButton);
            this.Controls.Add(this.backgroundPanel);
            this.Controls.Add(this.positioningLabel);
            this.Controls.Add(this.positioningPanel);
            this.Controls.Add(this.textColorButton);
            this.Controls.Add(this.textColorLabel);
            this.Controls.Add(this.textColorPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NameViewSetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Source name view setup";
            ((System.ComponentModel.ISupportInitialize)(this.autoHideTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSizeTrackBar)).EndInit();
            this.positioningPanel.ResumeLayout(false);
            this.positioningPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TrackBar autoHideTrackBar;
        private System.Windows.Forms.CheckBox autoHideCheckBox;
        private System.Windows.Forms.TrackBar textSizeTrackBar;
        private System.Windows.Forms.Label textSizeLabel;
        private System.Windows.Forms.CheckBox backgroundCheckBox;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.Label positioningLabel;
        private System.Windows.Forms.Panel positioningPanel;
        private System.Windows.Forms.Label camNameLabel;
        private System.Windows.Forms.Button bottomRightButton;
        private System.Windows.Forms.Button bottomCenterButton;
        private System.Windows.Forms.Button bottomLeftButton;
        private System.Windows.Forms.Button topRightButton;
        private System.Windows.Forms.Button topCenterButton;
        private System.Windows.Forms.Button topLeftButton;
        private System.Windows.Forms.Button textColorButton;
        private System.Windows.Forms.Label textColorLabel;
        private System.Windows.Forms.Panel textColorPanel;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

