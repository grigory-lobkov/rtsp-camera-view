
/********************
 * Copyright 2018 Grigory Lobkov
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 *
 * You may obtain a copy of the License at
 * https://github.com/grigory-lobkov/rtsp-camera-view/blob/master/LICENSE
 *
 ********************/

namespace RTSP_mosaic_VLC_player
{
    partial class CamNameConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CamNameConfigForm));
            this.textColorLabel = new System.Windows.Forms.Label();
            this.textColorButton = new System.Windows.Forms.Button();
            this.positioningPanel = new System.Windows.Forms.Panel();
            this.camNameLabel = new System.Windows.Forms.Label();
            this.bottomRightButton = new System.Windows.Forms.Button();
            this.bottomCenterButton = new System.Windows.Forms.Button();
            this.bottomLeftButton = new System.Windows.Forms.Button();
            this.topRightButton = new System.Windows.Forms.Button();
            this.topCenterButton = new System.Windows.Forms.Button();
            this.topLeftButton = new System.Windows.Forms.Button();
            this.positioningLabel = new System.Windows.Forms.Label();
            this.textColorPanel = new System.Windows.Forms.Panel();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.backgroundPanel = new System.Windows.Forms.Panel();
            this.backgroundCheckBox = new System.Windows.Forms.CheckBox();
            this.textSizeLabel = new System.Windows.Forms.Label();
            this.textSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.autoHideCheckBox = new System.Windows.Forms.CheckBox();
            this.autoHideTrackBar = new System.Windows.Forms.TrackBar();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.positioningPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSizeTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoHideTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // textColorLabel
            // 
            resources.ApplyResources(this.textColorLabel, "textColorLabel");
            this.textColorLabel.Name = "textColorLabel";
            // 
            // textColorButton
            // 
            resources.ApplyResources(this.textColorButton, "textColorButton");
            this.textColorButton.Name = "textColorButton";
            this.textColorButton.UseVisualStyleBackColor = true;
            this.textColorButton.Click += new System.EventHandler(this.textColorButton_Click);
            // 
            // positioningPanel
            // 
            resources.ApplyResources(this.positioningPanel, "positioningPanel");
            this.positioningPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.positioningPanel.Controls.Add(this.camNameLabel);
            this.positioningPanel.Controls.Add(this.bottomRightButton);
            this.positioningPanel.Controls.Add(this.bottomCenterButton);
            this.positioningPanel.Controls.Add(this.bottomLeftButton);
            this.positioningPanel.Controls.Add(this.topRightButton);
            this.positioningPanel.Controls.Add(this.topCenterButton);
            this.positioningPanel.Controls.Add(this.topLeftButton);
            this.positioningPanel.Name = "positioningPanel";
            // 
            // camNameLabel
            // 
            resources.ApplyResources(this.camNameLabel, "camNameLabel");
            this.camNameLabel.Name = "camNameLabel";
            // 
            // bottomRightButton
            // 
            resources.ApplyResources(this.bottomRightButton, "bottomRightButton");
            this.bottomRightButton.Name = "bottomRightButton";
            this.bottomRightButton.UseVisualStyleBackColor = true;
            this.bottomRightButton.Click += new System.EventHandler(this.bottomRightButton_Click);
            // 
            // bottomCenterButton
            // 
            resources.ApplyResources(this.bottomCenterButton, "bottomCenterButton");
            this.bottomCenterButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bottomCenterButton.Name = "bottomCenterButton";
            this.bottomCenterButton.UseVisualStyleBackColor = true;
            this.bottomCenterButton.Click += new System.EventHandler(this.bottomCenterButton_Click);
            // 
            // bottomLeftButton
            // 
            resources.ApplyResources(this.bottomLeftButton, "bottomLeftButton");
            this.bottomLeftButton.Name = "bottomLeftButton";
            this.bottomLeftButton.UseVisualStyleBackColor = true;
            this.bottomLeftButton.Click += new System.EventHandler(this.bottomLeftButton_Click);
            // 
            // topRightButton
            // 
            resources.ApplyResources(this.topRightButton, "topRightButton");
            this.topRightButton.Name = "topRightButton";
            this.topRightButton.UseVisualStyleBackColor = true;
            this.topRightButton.Click += new System.EventHandler(this.topRightButton_Click);
            // 
            // topCenterButton
            // 
            resources.ApplyResources(this.topCenterButton, "topCenterButton");
            this.topCenterButton.Name = "topCenterButton";
            this.topCenterButton.UseVisualStyleBackColor = true;
            this.topCenterButton.Click += new System.EventHandler(this.topCenterButton_Click);
            // 
            // topLeftButton
            // 
            resources.ApplyResources(this.topLeftButton, "topLeftButton");
            this.topLeftButton.Name = "topLeftButton";
            this.topLeftButton.UseVisualStyleBackColor = true;
            this.topLeftButton.Click += new System.EventHandler(this.topLeftButton_Click);
            // 
            // positioningLabel
            // 
            resources.ApplyResources(this.positioningLabel, "positioningLabel");
            this.positioningLabel.Name = "positioningLabel";
            // 
            // textColorPanel
            // 
            resources.ApplyResources(this.textColorPanel, "textColorPanel");
            this.textColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textColorPanel.Name = "textColorPanel";
            this.textColorPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textColorPanel_MouseDoubleClick);
            // 
            // backgroundButton
            // 
            resources.ApplyResources(this.backgroundButton, "backgroundButton");
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // backgroundPanel
            // 
            resources.ApplyResources(this.backgroundPanel, "backgroundPanel");
            this.backgroundPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.backgroundPanel.Name = "backgroundPanel";
            this.backgroundPanel.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.backgroundPanel_MouseDoubleClick);
            // 
            // backgroundCheckBox
            // 
            resources.ApplyResources(this.backgroundCheckBox, "backgroundCheckBox");
            this.backgroundCheckBox.Name = "backgroundCheckBox";
            this.backgroundCheckBox.UseVisualStyleBackColor = true;
            this.backgroundCheckBox.CheckedChanged += new System.EventHandler(this.backgroundCheckBox_CheckedChanged);
            // 
            // textSizeLabel
            // 
            resources.ApplyResources(this.textSizeLabel, "textSizeLabel");
            this.textSizeLabel.Name = "textSizeLabel";
            // 
            // textSizeTrackBar
            // 
            resources.ApplyResources(this.textSizeTrackBar, "textSizeTrackBar");
            this.textSizeTrackBar.LargeChange = 3;
            this.textSizeTrackBar.Minimum = 1;
            this.textSizeTrackBar.Name = "textSizeTrackBar";
            this.textSizeTrackBar.Value = 1;
            this.textSizeTrackBar.ValueChanged += new System.EventHandler(this.textSizeTrackBar_ValueChanged);
            // 
            // autoHideCheckBox
            // 
            resources.ApplyResources(this.autoHideCheckBox, "autoHideCheckBox");
            this.autoHideCheckBox.Name = "autoHideCheckBox";
            this.autoHideCheckBox.UseVisualStyleBackColor = true;
            this.autoHideCheckBox.CheckedChanged += new System.EventHandler(this.autoHideCheckBox_CheckedChanged);
            // 
            // autoHideTrackBar
            // 
            resources.ApplyResources(this.autoHideTrackBar, "autoHideTrackBar");
            this.autoHideTrackBar.LargeChange = 3;
            this.autoHideTrackBar.Maximum = 30;
            this.autoHideTrackBar.Minimum = 1;
            this.autoHideTrackBar.Name = "autoHideTrackBar";
            this.autoHideTrackBar.Value = 1;
            this.autoHideTrackBar.ValueChanged += new System.EventHandler(this.autoHideTrackBar_ValueChanged);
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // colorDialog
            // 
            this.colorDialog.AllowFullOpen = false;
            // 
            // CamNameConfigForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
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
            this.Name = "CamNameConfigForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CamNameConfigForm_FormClosing);
            this.positioningPanel.ResumeLayout(false);
            this.positioningPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textSizeTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.autoHideTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label textColorLabel;
        private System.Windows.Forms.Button textColorButton;
        private System.Windows.Forms.Panel positioningPanel;
        private System.Windows.Forms.Label camNameLabel;
        private System.Windows.Forms.Button bottomRightButton;
        private System.Windows.Forms.Button bottomCenterButton;
        private System.Windows.Forms.Button bottomLeftButton;
        private System.Windows.Forms.Button topRightButton;
        private System.Windows.Forms.Button topCenterButton;
        private System.Windows.Forms.Button topLeftButton;
        private System.Windows.Forms.Label positioningLabel;
        private System.Windows.Forms.Panel textColorPanel;
        private System.Windows.Forms.Button backgroundButton;
        private System.Windows.Forms.Panel backgroundPanel;
        private System.Windows.Forms.CheckBox backgroundCheckBox;
        private System.Windows.Forms.Label textSizeLabel;
        private System.Windows.Forms.TrackBar textSizeTrackBar;
        private System.Windows.Forms.CheckBox autoHideCheckBox;
        private System.Windows.Forms.TrackBar autoHideTrackBar;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ColorDialog colorDialog;

    }
}