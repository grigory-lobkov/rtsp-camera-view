using System;
using System.Drawing;
using System.Windows.Forms;

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
            this.cameraContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.largeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smallListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ascendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descendingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraIconsImageList = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.camerasPage = new System.Windows.Forms.TabPage();
            this.editCamPanel = new System.Windows.Forms.Panel();
            this.camNameShowInheritCheck = new System.Windows.Forms.CheckBox();
            this.camNameShowCheck = new System.Windows.Forms.CheckBox();
            this.camNameLabel = new System.Windows.Forms.Label();
            this.camNameTextBox = new System.Windows.Forms.TextBox();
            this.camEditBtnsPanel = new System.Windows.Forms.Panel();
            this.delCamLabel = new System.Windows.Forms.Label();
            this.cancelCamButton = new System.Windows.Forms.Button();
            this.saveCamButton = new System.Windows.Forms.Button();
            this.camerasIconListView = new System.Windows.Forms.ListView();
            this.aspectRatioLabel = new System.Windows.Forms.Label();
            this.aspectRatioTextBox = new System.Windows.Forms.TextBox();
            this.camEditIconLabel = new System.Windows.Forms.Label();
            this.rtsp2TextBox = new System.Windows.Forms.TextBox();
            this.rtsp1TextBox = new System.Windows.Forms.TextBox();
            this.camEditRtsp2Label = new System.Windows.Forms.Label();
            this.camEditRtsp1Label = new System.Windows.Forms.Label();
            this.camNameShowModifyLabel = new System.Windows.Forms.Label();
            this.viewPanel = new System.Windows.Forms.Panel();
            this.camerasListView = new System.Windows.Forms.ListView();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.optionsPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.matrixSaveLabel = new System.Windows.Forms.Label();
            this.matrixYinput = new System.Windows.Forms.TextBox();
            this.matrixXinput = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.matrixDimensionsLabel = new System.Windows.Forms.Label();
            this.camNameViewGlbButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.developerLinkLabel = new System.Windows.Forms.LinkLabel();
            this.commandLineHelpButton = new System.Windows.Forms.Button();
            this.cameraDeleteConfirm2 = new System.Windows.Forms.Label();
            this.cameraDeleteConfirm1 = new System.Windows.Forms.Label();
            this.errorSaveSettings = new System.Windows.Forms.Label();
            this.errorLoadSettings = new System.Windows.Forms.Label();
            this.commandLineHelp = new System.Windows.Forms.Label();
            this.ctrlPanel = new System.Windows.Forms.Panel();
            this.splitLabel = new System.Windows.Forms.Label();
            this.camPanel = new System.Windows.Forms.Panel();
            this.hintDropCamera = new System.Windows.Forms.Label();
            this.hintRTSP2 = new System.Windows.Forms.Label();
            this.hintRTSP1 = new System.Windows.Forms.Label();
            this.hintAddCamera = new System.Windows.Forms.Label();
            this.hintOpenCtrl = new System.Windows.Forms.Label();
            this.stringsPanel = new System.Windows.Forms.Panel();
            this.errorSetCamera = new System.Windows.Forms.Label();
            this.errorInitVLCbadLib = new System.Windows.Forms.Label();
            this.errorInitVLCbadLibVer = new System.Windows.Forms.Label();
            this.errorInitVLCnoLib = new System.Windows.Forms.Label();
            this.errorInitVLC = new System.Windows.Forms.Label();
            this.tabControlSplitter = new System.Windows.Forms.Splitter();
            this.showHintTimer = new System.Windows.Forms.Timer(this.components);
            this.watchDogTimer = new System.Windows.Forms.Timer(this.components);
            this.cameraContextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.camerasPage.SuspendLayout();
            this.editCamPanel.SuspendLayout();
            this.camEditBtnsPanel.SuspendLayout();
            this.viewPanel.SuspendLayout();
            this.optionsPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ctrlPanel.SuspendLayout();
            this.camPanel.SuspendLayout();
            this.stringsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameraContextMenuStrip
            // 
            this.cameraContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.newCameraToolStripMenuItem,
            this.modifyCameraToolStripMenuItem});
            this.cameraContextMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.cameraContextMenuStrip, "cameraContextMenuStrip");
            this.cameraContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.largeListToolStripMenuItem,
            this.smallListToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // largeIconsToolStripMenuItem
            // 
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            resources.ApplyResources(this.largeIconsToolStripMenuItem, "largeIconsToolStripMenuItem");
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.LargeIconsToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem
            // 
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            resources.ApplyResources(this.smallIconsToolStripMenuItem, "smallIconsToolStripMenuItem");
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.SmallIconsToolStripMenuItem_Click);
            // 
            // largeListToolStripMenuItem
            // 
            this.largeListToolStripMenuItem.Name = "largeListToolStripMenuItem";
            resources.ApplyResources(this.largeListToolStripMenuItem, "largeListToolStripMenuItem");
            this.largeListToolStripMenuItem.Click += new System.EventHandler(this.LargeListToolStripMenuItem_Click);
            // 
            // smallListToolStripMenuItem
            // 
            this.smallListToolStripMenuItem.Name = "smallListToolStripMenuItem";
            resources.ApplyResources(this.smallListToolStripMenuItem, "smallListToolStripMenuItem");
            this.smallListToolStripMenuItem.Click += new System.EventHandler(this.SmallListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascendingToolStripMenuItem,
            this.descendingToolStripMenuItem,
            this.disabledToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // ascendingToolStripMenuItem
            // 
            this.ascendingToolStripMenuItem.Name = "ascendingToolStripMenuItem";
            resources.ApplyResources(this.ascendingToolStripMenuItem, "ascendingToolStripMenuItem");
            this.ascendingToolStripMenuItem.Click += new System.EventHandler(this.AscendingToolStripMenuItem_Click);
            // 
            // descendingToolStripMenuItem
            // 
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            resources.ApplyResources(this.descendingToolStripMenuItem, "descendingToolStripMenuItem");
            this.descendingToolStripMenuItem.Click += new System.EventHandler(this.DescendingToolStripMenuItem_Click);
            // 
            // disabledToolStripMenuItem
            // 
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            resources.ApplyResources(this.disabledToolStripMenuItem, "disabledToolStripMenuItem");
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.DisabledToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // newCameraToolStripMenuItem
            // 
            this.newCameraToolStripMenuItem.Name = "newCameraToolStripMenuItem";
            resources.ApplyResources(this.newCameraToolStripMenuItem, "newCameraToolStripMenuItem");
            this.newCameraToolStripMenuItem.Click += new System.EventHandler(this.NewCameraToolStripMenuItem_Click);
            // 
            // modifyCameraToolStripMenuItem
            // 
            this.modifyCameraToolStripMenuItem.Name = "modifyCameraToolStripMenuItem";
            resources.ApplyResources(this.modifyCameraToolStripMenuItem, "modifyCameraToolStripMenuItem");
            this.modifyCameraToolStripMenuItem.Click += new System.EventHandler(this.ModifyCameraToolStripMenuItem_Click);
            // 
            // cameraIconsImageList
            // 
            this.cameraIconsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("cameraIconsImageList.ImageStream")));
            this.cameraIconsImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.cameraIconsImageList.Images.SetKeyName(0, "cam1.png");
            this.cameraIconsImageList.Images.SetKeyName(1, "cam2.png");
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.camerasPage);
            this.tabControl1.Controls.Add(this.optionsPage);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // camerasPage
            // 
            this.camerasPage.Controls.Add(this.editCamPanel);
            this.camerasPage.Controls.Add(this.viewPanel);
            resources.ApplyResources(this.camerasPage, "camerasPage");
            this.camerasPage.Name = "camerasPage";
            this.camerasPage.UseVisualStyleBackColor = true;
            // 
            // editCamPanel
            // 
            this.editCamPanel.Controls.Add(this.camNameShowInheritCheck);
            this.editCamPanel.Controls.Add(this.camNameShowCheck);
            this.editCamPanel.Controls.Add(this.camNameLabel);
            this.editCamPanel.Controls.Add(this.camNameTextBox);
            this.editCamPanel.Controls.Add(this.camEditBtnsPanel);
            this.editCamPanel.Controls.Add(this.camerasIconListView);
            this.editCamPanel.Controls.Add(this.aspectRatioLabel);
            this.editCamPanel.Controls.Add(this.aspectRatioTextBox);
            this.editCamPanel.Controls.Add(this.camEditIconLabel);
            this.editCamPanel.Controls.Add(this.rtsp2TextBox);
            this.editCamPanel.Controls.Add(this.rtsp1TextBox);
            this.editCamPanel.Controls.Add(this.camEditRtsp2Label);
            this.editCamPanel.Controls.Add(this.camEditRtsp1Label);
            this.editCamPanel.Controls.Add(this.camNameShowModifyLabel);
            resources.ApplyResources(this.editCamPanel, "editCamPanel");
            this.editCamPanel.Name = "editCamPanel";
            // 
            // camNameShowInheritCheck
            // 
            resources.ApplyResources(this.camNameShowInheritCheck, "camNameShowInheritCheck");
            this.camNameShowInheritCheck.Checked = true;
            this.camNameShowInheritCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.camNameShowInheritCheck.Name = "camNameShowInheritCheck";
            this.camNameShowInheritCheck.TabStop = false;
            this.camNameShowInheritCheck.UseVisualStyleBackColor = true;
            this.camNameShowInheritCheck.CheckedChanged += new System.EventHandler(this.CamNameShowInheritCheck_CheckedChanged);
            // 
            // camNameShowCheck
            // 
            resources.ApplyResources(this.camNameShowCheck, "camNameShowCheck");
            this.camNameShowCheck.Checked = true;
            this.camNameShowCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.camNameShowCheck.Name = "camNameShowCheck";
            this.camNameShowCheck.TabStop = false;
            this.camNameShowCheck.UseVisualStyleBackColor = true;
            this.camNameShowCheck.CheckedChanged += new System.EventHandler(this.CamNameShowCheck_CheckedChanged);
            // 
            // camNameLabel
            // 
            resources.ApplyResources(this.camNameLabel, "camNameLabel");
            this.camNameLabel.Name = "camNameLabel";
            // 
            // camNameTextBox
            // 
            resources.ApplyResources(this.camNameTextBox, "camNameTextBox");
            this.camNameTextBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.camNameTextBox.Name = "camNameTextBox";
            this.camNameTextBox.Enter += new System.EventHandler(this.CamNameTextBox_Enter);
            // 
            // camEditBtnsPanel
            // 
            this.camEditBtnsPanel.Controls.Add(this.delCamLabel);
            this.camEditBtnsPanel.Controls.Add(this.cancelCamButton);
            this.camEditBtnsPanel.Controls.Add(this.saveCamButton);
            resources.ApplyResources(this.camEditBtnsPanel, "camEditBtnsPanel");
            this.camEditBtnsPanel.Name = "camEditBtnsPanel";
            // 
            // delCamLabel
            // 
            resources.ApplyResources(this.delCamLabel, "delCamLabel");
            this.delCamLabel.ForeColor = System.Drawing.Color.Red;
            this.delCamLabel.Name = "delCamLabel";
            this.delCamLabel.Click += new System.EventHandler(this.DelCamLabel_Click);
            this.delCamLabel.MouseEnter += new System.EventHandler(this.ButtonLabel_MouseEnter);
            this.delCamLabel.MouseLeave += new System.EventHandler(this.ButtonLabel_MouseLeave);
            // 
            // cancelCamButton
            // 
            resources.ApplyResources(this.cancelCamButton, "cancelCamButton");
            this.cancelCamButton.Name = "cancelCamButton";
            this.cancelCamButton.UseVisualStyleBackColor = true;
            this.cancelCamButton.Click += new System.EventHandler(this.CancelCamButton_Click);
            // 
            // saveCamButton
            // 
            resources.ApplyResources(this.saveCamButton, "saveCamButton");
            this.saveCamButton.Name = "saveCamButton";
            this.saveCamButton.UseVisualStyleBackColor = true;
            this.saveCamButton.Click += new System.EventHandler(this.SaveCamButton_Click);
            // 
            // camerasIconListView
            // 
            resources.ApplyResources(this.camerasIconListView, "camerasIconListView");
            this.camerasIconListView.HideSelection = false;
            this.camerasIconListView.MultiSelect = false;
            this.camerasIconListView.Name = "camerasIconListView";
            this.camerasIconListView.TileSize = new System.Drawing.Size(60, 52);
            this.camerasIconListView.UseCompatibleStateImageBehavior = false;
            this.camerasIconListView.View = System.Windows.Forms.View.Tile;
            // 
            // aspectRatioLabel
            // 
            resources.ApplyResources(this.aspectRatioLabel, "aspectRatioLabel");
            this.aspectRatioLabel.Name = "aspectRatioLabel";
            // 
            // aspectRatioTextBox
            // 
            resources.ApplyResources(this.aspectRatioTextBox, "aspectRatioTextBox");
            this.aspectRatioTextBox.Name = "aspectRatioTextBox";
            // 
            // camEditIconLabel
            // 
            resources.ApplyResources(this.camEditIconLabel, "camEditIconLabel");
            this.camEditIconLabel.Name = "camEditIconLabel";
            // 
            // rtsp2TextBox
            // 
            resources.ApplyResources(this.rtsp2TextBox, "rtsp2TextBox");
            this.rtsp2TextBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.rtsp2TextBox.Name = "rtsp2TextBox";
            this.rtsp2TextBox.Enter += new System.EventHandler(this.Rtsp2TextBox_Enter);
            // 
            // rtsp1TextBox
            // 
            resources.ApplyResources(this.rtsp1TextBox, "rtsp1TextBox");
            this.rtsp1TextBox.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.rtsp1TextBox.Name = "rtsp1TextBox";
            this.rtsp1TextBox.Enter += new System.EventHandler(this.Rtsp1TextBox_Enter);
            // 
            // camEditRtsp2Label
            // 
            resources.ApplyResources(this.camEditRtsp2Label, "camEditRtsp2Label");
            this.camEditRtsp2Label.Name = "camEditRtsp2Label";
            // 
            // camEditRtsp1Label
            // 
            resources.ApplyResources(this.camEditRtsp1Label, "camEditRtsp1Label");
            this.camEditRtsp1Label.Name = "camEditRtsp1Label";
            // 
            // camNameShowModifyLabel
            // 
            resources.ApplyResources(this.camNameShowModifyLabel, "camNameShowModifyLabel");
            this.camNameShowModifyLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.camNameShowModifyLabel.Name = "camNameShowModifyLabel";
            this.camNameShowModifyLabel.Click += new System.EventHandler(this.CamNameShowModifyLabel_Click);
            this.camNameShowModifyLabel.MouseEnter += new System.EventHandler(this.ButtonLabel_MouseEnter);
            this.camNameShowModifyLabel.MouseLeave += new System.EventHandler(this.ButtonLabel_MouseLeave);
            // 
            // viewPanel
            // 
            this.viewPanel.Controls.Add(this.camerasListView);
            this.viewPanel.Controls.Add(this.infoPanel);
            resources.ApplyResources(this.viewPanel, "viewPanel");
            this.viewPanel.Name = "viewPanel";
            // 
            // camerasListView
            // 
            this.camerasListView.AllowDrop = true;
            this.camerasListView.ContextMenuStrip = this.cameraContextMenuStrip;
            resources.ApplyResources(this.camerasListView, "camerasListView");
            this.camerasListView.HideSelection = false;
            this.camerasListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("camerasListView.Items"))),
            ((System.Windows.Forms.ListViewItem)(resources.GetObject("camerasListView.Items1")))});
            this.camerasListView.LabelEdit = true;
            this.camerasListView.LargeImageList = this.cameraIconsImageList;
            this.camerasListView.MultiSelect = false;
            this.camerasListView.Name = "camerasListView";
            this.camerasListView.SmallImageList = this.cameraIconsImageList;
            this.camerasListView.TileSize = new System.Drawing.Size(150, 150);
            this.camerasListView.UseCompatibleStateImageBehavior = false;
            this.camerasListView.View = System.Windows.Forms.View.List;
            this.camerasListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.CamerasListView_AfterLabelEdit);
            this.camerasListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.CamerasListView_DragEnter);
            this.camerasListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CamerasListView_MouseDown);
            // 
            // infoPanel
            // 
            resources.ApplyResources(this.infoPanel, "infoPanel");
            this.infoPanel.Name = "infoPanel";
            // 
            // optionsPage
            // 
            this.optionsPage.Controls.Add(this.panel2);
            this.optionsPage.Controls.Add(this.matrixDimensionsLabel);
            this.optionsPage.Controls.Add(this.camNameViewGlbButton);
            this.optionsPage.Controls.Add(this.panel1);
            resources.ApplyResources(this.optionsPage, "optionsPage");
            this.optionsPage.Name = "optionsPage";
            this.optionsPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.matrixSaveLabel);
            this.panel2.Controls.Add(this.matrixYinput);
            this.panel2.Controls.Add(this.matrixXinput);
            this.panel2.Controls.Add(this.xLabel);
            this.panel2.Name = "panel2";
            // 
            // matrixSaveLabel
            // 
            resources.ApplyResources(this.matrixSaveLabel, "matrixSaveLabel");
            this.matrixSaveLabel.Name = "matrixSaveLabel";
            this.matrixSaveLabel.Click += new System.EventHandler(this.MatrixSaveLabel_Click);
            this.matrixSaveLabel.MouseEnter += new System.EventHandler(this.ButtonLabel_MouseEnter);
            this.matrixSaveLabel.MouseLeave += new System.EventHandler(this.ButtonLabel_MouseLeave);
            // 
            // matrixYinput
            // 
            resources.ApplyResources(this.matrixYinput, "matrixYinput");
            this.matrixYinput.Name = "matrixYinput";
            this.matrixYinput.TextChanged += new System.EventHandler(this.MatrixXinput_TextChanged);
            this.matrixYinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MatrixXinput_KeyDown);
            this.matrixYinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MatrixXinput_KeyPress);
            // 
            // matrixXinput
            // 
            resources.ApplyResources(this.matrixXinput, "matrixXinput");
            this.matrixXinput.Name = "matrixXinput";
            this.matrixXinput.TextChanged += new System.EventHandler(this.MatrixXinput_TextChanged);
            this.matrixXinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MatrixXinput_KeyDown);
            this.matrixXinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MatrixXinput_KeyPress);
            // 
            // xLabel
            // 
            resources.ApplyResources(this.xLabel, "xLabel");
            this.xLabel.Name = "xLabel";
            // 
            // matrixDimensionsLabel
            // 
            resources.ApplyResources(this.matrixDimensionsLabel, "matrixDimensionsLabel");
            this.matrixDimensionsLabel.Name = "matrixDimensionsLabel";
            // 
            // camNameViewGlbButton
            // 
            resources.ApplyResources(this.camNameViewGlbButton, "camNameViewGlbButton");
            this.camNameViewGlbButton.Name = "camNameViewGlbButton";
            this.camNameViewGlbButton.UseVisualStyleBackColor = true;
            this.camNameViewGlbButton.Click += new System.EventHandler(this.CamNameViewGlbButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.developerLinkLabel);
            this.panel1.Controls.Add(this.commandLineHelpButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // developerLinkLabel
            // 
            resources.ApplyResources(this.developerLinkLabel, "developerLinkLabel");
            this.developerLinkLabel.Name = "developerLinkLabel";
            this.developerLinkLabel.TabStop = true;
            this.developerLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DeveloperLinkLabel_LinkClicked);
            // 
            // commandLineHelpButton
            // 
            resources.ApplyResources(this.commandLineHelpButton, "commandLineHelpButton");
            this.commandLineHelpButton.Name = "commandLineHelpButton";
            this.commandLineHelpButton.UseVisualStyleBackColor = true;
            this.commandLineHelpButton.Click += new System.EventHandler(this.CommandLineHelpButton_Click);
            // 
            // cameraDeleteConfirm2
            // 
            resources.ApplyResources(this.cameraDeleteConfirm2, "cameraDeleteConfirm2");
            this.cameraDeleteConfirm2.Name = "cameraDeleteConfirm2";
            // 
            // cameraDeleteConfirm1
            // 
            resources.ApplyResources(this.cameraDeleteConfirm1, "cameraDeleteConfirm1");
            this.cameraDeleteConfirm1.Name = "cameraDeleteConfirm1";
            // 
            // errorSaveSettings
            // 
            resources.ApplyResources(this.errorSaveSettings, "errorSaveSettings");
            this.errorSaveSettings.Name = "errorSaveSettings";
            // 
            // errorLoadSettings
            // 
            resources.ApplyResources(this.errorLoadSettings, "errorLoadSettings");
            this.errorLoadSettings.Name = "errorLoadSettings";
            // 
            // commandLineHelp
            // 
            resources.ApplyResources(this.commandLineHelp, "commandLineHelp");
            this.commandLineHelp.Name = "commandLineHelp";
            // 
            // ctrlPanel
            // 
            this.ctrlPanel.Controls.Add(this.tabControl1);
            resources.ApplyResources(this.ctrlPanel, "ctrlPanel");
            this.ctrlPanel.Name = "ctrlPanel";
            // 
            // splitLabel
            // 
            resources.ApplyResources(this.splitLabel, "splitLabel");
            this.splitLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.splitLabel.Name = "splitLabel";
            this.splitLabel.Click += new System.EventHandler(this.SplitLabel_Click);
            this.splitLabel.MouseEnter += new System.EventHandler(this.SplitLabel_MouseEnter);
            this.splitLabel.MouseLeave += new System.EventHandler(this.SplitLabel_MouseLeave);
            // 
            // camPanel
            // 
            this.camPanel.BackColor = System.Drawing.Color.Black;
            this.camPanel.Controls.Add(this.hintDropCamera);
            this.camPanel.Controls.Add(this.hintRTSP2);
            this.camPanel.Controls.Add(this.hintRTSP1);
            this.camPanel.Controls.Add(this.hintAddCamera);
            this.camPanel.Controls.Add(this.hintOpenCtrl);
            this.camPanel.Controls.Add(this.stringsPanel);
            this.camPanel.Controls.Add(this.splitLabel);
            resources.ApplyResources(this.camPanel, "camPanel");
            this.camPanel.ForeColor = System.Drawing.Color.White;
            this.camPanel.Name = "camPanel";
            // 
            // hintDropCamera
            // 
            resources.ApplyResources(this.hintDropCamera, "hintDropCamera");
            this.hintDropCamera.BackColor = System.Drawing.SystemColors.Info;
            this.hintDropCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintDropCamera.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hintDropCamera.Name = "hintDropCamera";
            // 
            // hintRTSP2
            // 
            this.hintRTSP2.BackColor = System.Drawing.SystemColors.Info;
            this.hintRTSP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintRTSP2.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.hintRTSP2, "hintRTSP2");
            this.hintRTSP2.Name = "hintRTSP2";
            // 
            // hintRTSP1
            // 
            this.hintRTSP1.BackColor = System.Drawing.SystemColors.Info;
            this.hintRTSP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintRTSP1.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.hintRTSP1, "hintRTSP1");
            this.hintRTSP1.Name = "hintRTSP1";
            // 
            // hintAddCamera
            // 
            resources.ApplyResources(this.hintAddCamera, "hintAddCamera");
            this.hintAddCamera.BackColor = System.Drawing.SystemColors.Info;
            this.hintAddCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintAddCamera.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hintAddCamera.Name = "hintAddCamera";
            // 
            // hintOpenCtrl
            // 
            resources.ApplyResources(this.hintOpenCtrl, "hintOpenCtrl");
            this.hintOpenCtrl.BackColor = System.Drawing.SystemColors.Info;
            this.hintOpenCtrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintOpenCtrl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hintOpenCtrl.Name = "hintOpenCtrl";
            // 
            // stringsPanel
            // 
            this.stringsPanel.Controls.Add(this.errorSetCamera);
            this.stringsPanel.Controls.Add(this.errorInitVLCbadLib);
            this.stringsPanel.Controls.Add(this.errorInitVLCbadLibVer);
            this.stringsPanel.Controls.Add(this.errorInitVLCnoLib);
            this.stringsPanel.Controls.Add(this.errorInitVLC);
            this.stringsPanel.Controls.Add(this.cameraDeleteConfirm2);
            this.stringsPanel.Controls.Add(this.errorSaveSettings);
            this.stringsPanel.Controls.Add(this.commandLineHelp);
            this.stringsPanel.Controls.Add(this.errorLoadSettings);
            this.stringsPanel.Controls.Add(this.cameraDeleteConfirm1);
            resources.ApplyResources(this.stringsPanel, "stringsPanel");
            this.stringsPanel.Name = "stringsPanel";
            // 
            // errorSetCamera
            // 
            resources.ApplyResources(this.errorSetCamera, "errorSetCamera");
            this.errorSetCamera.Name = "errorSetCamera";
            // 
            // errorInitVLCbadLib
            // 
            resources.ApplyResources(this.errorInitVLCbadLib, "errorInitVLCbadLib");
            this.errorInitVLCbadLib.Name = "errorInitVLCbadLib";
            // 
            // errorInitVLCbadLibVer
            // 
            resources.ApplyResources(this.errorInitVLCbadLibVer, "errorInitVLCbadLibVer");
            this.errorInitVLCbadLibVer.Name = "errorInitVLCbadLibVer";
            // 
            // errorInitVLCnoLib
            // 
            resources.ApplyResources(this.errorInitVLCnoLib, "errorInitVLCnoLib");
            this.errorInitVLCnoLib.Name = "errorInitVLCnoLib";
            // 
            // errorInitVLC
            // 
            resources.ApplyResources(this.errorInitVLC, "errorInitVLC");
            this.errorInitVLC.Name = "errorInitVLC";
            // 
            // tabControlSplitter
            // 
            this.tabControlSplitter.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.tabControlSplitter, "tabControlSplitter");
            this.tabControlSplitter.Name = "tabControlSplitter";
            this.tabControlSplitter.TabStop = false;
            this.tabControlSplitter.SplitterMoving += new System.Windows.Forms.SplitterEventHandler(this.TabControlSplitter_SplitterMoving);
            this.tabControlSplitter.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.TabControlSplitter_SplitterMoved);
            // 
            // showHintTimer
            // 
            this.showHintTimer.Tick += new System.EventHandler(this.ShowHintTimer_Tick);
            // 
            // watchDogTimer
            // 
            this.watchDogTimer.Interval = 50000;
            this.watchDogTimer.Tick += new System.EventHandler(this.WatchDogTimer_Tick);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.tabControlSplitter);
            this.Controls.Add(this.camPanel);
            this.Controls.Add(this.ctrlPanel);
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.cameraContextMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.camerasPage.ResumeLayout(false);
            this.editCamPanel.ResumeLayout(false);
            this.editCamPanel.PerformLayout();
            this.camEditBtnsPanel.ResumeLayout(false);
            this.camEditBtnsPanel.PerformLayout();
            this.viewPanel.ResumeLayout(false);
            this.optionsPage.ResumeLayout(false);
            this.optionsPage.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ctrlPanel.ResumeLayout(false);
            this.camPanel.ResumeLayout(false);
            this.camPanel.PerformLayout();
            this.stringsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip cameraContextMenuStrip;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem largeIconsToolStripMenuItem;
        private ToolStripMenuItem smallIconsToolStripMenuItem;
        private ToolStripMenuItem ascendingToolStripMenuItem;
        private ToolStripMenuItem descendingToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ImageList cameraIconsImageList;
        private ToolStripMenuItem largeListToolStripMenuItem;
        private ToolStripMenuItem smallListToolStripMenuItem;
        private ToolStripMenuItem newCameraToolStripMenuItem;
        private ToolStripMenuItem modifyCameraToolStripMenuItem;
        private ToolStripMenuItem disabledToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage camerasPage;
        private Panel viewPanel;
        private Panel infoPanel;
        private ListView camerasListView;
        private Panel editCamPanel;
        private Panel camEditBtnsPanel;
        private Label delCamLabel;
        private Button cancelCamButton;
        private Button saveCamButton;
        private ListView camerasIconListView;
        private Label camEditIconLabel;
        private TextBox rtsp2TextBox;
        private TextBox rtsp1TextBox;
        private Label camEditRtsp2Label;
        private Label camEditRtsp1Label;
        private TabPage optionsPage;
        private Panel ctrlPanel;
        private Label splitLabel;
        private Panel camPanel;
        private Splitter tabControlSplitter;
        private Label aspectRatioLabel;
        private TextBox aspectRatioTextBox;
        private Label camNameLabel;
        private TextBox camNameTextBox;
        private Panel panel1;
        private Button commandLineHelpButton;
        private Label commandLineHelp;
        private Label errorSaveSettings;
        private Label errorLoadSettings;
        private LinkLabel developerLinkLabel;
        private Label cameraDeleteConfirm2;
        private Label cameraDeleteConfirm1;
        private Panel stringsPanel;
        private Label errorInitVLC;
        private Label errorInitVLCnoLib;
        private Label errorInitVLCbadLibVer;
        private Label errorInitVLCbadLib;
        private Label hintOpenCtrl;
        private Timer showHintTimer;
        private Label hintAddCamera;
        private Label hintDropCamera;
        private Label hintRTSP2;
        private Label hintRTSP1;
        private Label camNameShowModifyLabel;
        private CheckBox camNameShowInheritCheck;
        private CheckBox camNameShowCheck;
        private Button camNameViewGlbButton;
        private Label matrixDimensionsLabel;
        private TextBox matrixXinput;
        private TextBox matrixYinput;
        private Label xLabel;
        private Panel panel2;
        private Label matrixSaveLabel;
        private Label errorSetCamera;
        private Timer watchDogTimer;
    }
}

