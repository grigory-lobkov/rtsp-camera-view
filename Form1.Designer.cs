using System;
using System.Drawing;
using System.Windows.Forms;

namespace RTSP_mosaic_VLC_player
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.editCamPanel = new System.Windows.Forms.Panel();
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
            this.viewPanel = new System.Windows.Forms.Panel();
            this.camerasListView = new System.Windows.Forms.ListView();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorInitVLCbadLib = new System.Windows.Forms.Label();
            this.errorInitVLCbadLibVer = new System.Windows.Forms.Label();
            this.errorInitVLCnoLib = new System.Windows.Forms.Label();
            this.errorInitVLC = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.showHintTimer = new System.Windows.Forms.Timer(this.components);
            this.cameraContextMenuStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.editCamPanel.SuspendLayout();
            this.camEditBtnsPanel.SuspendLayout();
            this.viewPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ctrlPanel.SuspendLayout();
            this.camPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameraContextMenuStrip
            // 
            resources.ApplyResources(this.cameraContextMenuStrip, "cameraContextMenuStrip");
            this.cameraContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator1,
            this.newCameraToolStripMenuItem,
            this.modifyCameraToolStripMenuItem});
            this.cameraContextMenuStrip.Name = "contextMenuStrip1";
            this.cameraContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.largeIconsToolStripMenuItem,
            this.smallIconsToolStripMenuItem,
            this.largeListToolStripMenuItem,
            this.smallListToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // largeIconsToolStripMenuItem
            // 
            resources.ApplyResources(this.largeIconsToolStripMenuItem, "largeIconsToolStripMenuItem");
            this.largeIconsToolStripMenuItem.Name = "largeIconsToolStripMenuItem";
            this.largeIconsToolStripMenuItem.Click += new System.EventHandler(this.largeIconsToolStripMenuItem_Click);
            // 
            // smallIconsToolStripMenuItem
            // 
            resources.ApplyResources(this.smallIconsToolStripMenuItem, "smallIconsToolStripMenuItem");
            this.smallIconsToolStripMenuItem.Name = "smallIconsToolStripMenuItem";
            this.smallIconsToolStripMenuItem.Click += new System.EventHandler(this.smallIconsToolStripMenuItem_Click);
            // 
            // largeListToolStripMenuItem
            // 
            resources.ApplyResources(this.largeListToolStripMenuItem, "largeListToolStripMenuItem");
            this.largeListToolStripMenuItem.Name = "largeListToolStripMenuItem";
            this.largeListToolStripMenuItem.Click += new System.EventHandler(this.largeListToolStripMenuItem_Click);
            // 
            // smallListToolStripMenuItem
            // 
            resources.ApplyResources(this.smallListToolStripMenuItem, "smallListToolStripMenuItem");
            this.smallListToolStripMenuItem.Name = "smallListToolStripMenuItem";
            this.smallListToolStripMenuItem.Click += new System.EventHandler(this.smallListToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascendingToolStripMenuItem,
            this.descendingToolStripMenuItem,
            this.disabledToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // ascendingToolStripMenuItem
            // 
            resources.ApplyResources(this.ascendingToolStripMenuItem, "ascendingToolStripMenuItem");
            this.ascendingToolStripMenuItem.Name = "ascendingToolStripMenuItem";
            this.ascendingToolStripMenuItem.Click += new System.EventHandler(this.ascendingToolStripMenuItem_Click);
            // 
            // descendingToolStripMenuItem
            // 
            resources.ApplyResources(this.descendingToolStripMenuItem, "descendingToolStripMenuItem");
            this.descendingToolStripMenuItem.Name = "descendingToolStripMenuItem";
            this.descendingToolStripMenuItem.Click += new System.EventHandler(this.descendingToolStripMenuItem_Click);
            // 
            // disabledToolStripMenuItem
            // 
            resources.ApplyResources(this.disabledToolStripMenuItem, "disabledToolStripMenuItem");
            this.disabledToolStripMenuItem.Name = "disabledToolStripMenuItem";
            this.disabledToolStripMenuItem.Click += new System.EventHandler(this.disabledToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // newCameraToolStripMenuItem
            // 
            resources.ApplyResources(this.newCameraToolStripMenuItem, "newCameraToolStripMenuItem");
            this.newCameraToolStripMenuItem.Name = "newCameraToolStripMenuItem";
            this.newCameraToolStripMenuItem.Click += new System.EventHandler(this.newCameraToolStripMenuItem_Click);
            // 
            // modifyCameraToolStripMenuItem
            // 
            resources.ApplyResources(this.modifyCameraToolStripMenuItem, "modifyCameraToolStripMenuItem");
            this.modifyCameraToolStripMenuItem.Name = "modifyCameraToolStripMenuItem";
            this.modifyCameraToolStripMenuItem.Click += new System.EventHandler(this.modifyCameraToolStripMenuItem_Click);
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
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.editCamPanel);
            this.tabPage1.Controls.Add(this.viewPanel);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // editCamPanel
            // 
            resources.ApplyResources(this.editCamPanel, "editCamPanel");
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
            this.editCamPanel.Name = "editCamPanel";
            // 
            // camNameLabel
            // 
            resources.ApplyResources(this.camNameLabel, "camNameLabel");
            this.camNameLabel.Name = "camNameLabel";
            // 
            // camNameTextBox
            // 
            resources.ApplyResources(this.camNameTextBox, "camNameTextBox");
            this.camNameTextBox.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.camNameTextBox.Name = "camNameTextBox";
            this.camNameTextBox.Enter += new System.EventHandler(this.camNameTextBox_Enter);
            // 
            // camEditBtnsPanel
            // 
            resources.ApplyResources(this.camEditBtnsPanel, "camEditBtnsPanel");
            this.camEditBtnsPanel.Controls.Add(this.delCamLabel);
            this.camEditBtnsPanel.Controls.Add(this.cancelCamButton);
            this.camEditBtnsPanel.Controls.Add(this.saveCamButton);
            this.camEditBtnsPanel.Name = "camEditBtnsPanel";
            // 
            // delCamLabel
            // 
            resources.ApplyResources(this.delCamLabel, "delCamLabel");
            this.delCamLabel.ForeColor = System.Drawing.Color.Red;
            this.delCamLabel.Name = "delCamLabel";
            this.delCamLabel.Click += new System.EventHandler(this.delCamLabel_Click);
            // 
            // cancelCamButton
            // 
            resources.ApplyResources(this.cancelCamButton, "cancelCamButton");
            this.cancelCamButton.Name = "cancelCamButton";
            this.cancelCamButton.UseVisualStyleBackColor = true;
            this.cancelCamButton.Click += new System.EventHandler(this.cancelCamButton_Click);
            // 
            // saveCamButton
            // 
            resources.ApplyResources(this.saveCamButton, "saveCamButton");
            this.saveCamButton.Name = "saveCamButton";
            this.saveCamButton.UseVisualStyleBackColor = true;
            this.saveCamButton.Click += new System.EventHandler(this.saveCamButton_Click);
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
            this.rtsp2TextBox.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rtsp2TextBox.Name = "rtsp2TextBox";
            this.rtsp2TextBox.Enter += new System.EventHandler(this.rtsp2TextBox_Enter);
            // 
            // rtsp1TextBox
            // 
            resources.ApplyResources(this.rtsp1TextBox, "rtsp1TextBox");
            this.rtsp1TextBox.ForeColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.rtsp1TextBox.Name = "rtsp1TextBox";
            this.rtsp1TextBox.Enter += new System.EventHandler(this.rtsp1TextBox_Enter);
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
            // viewPanel
            // 
            resources.ApplyResources(this.viewPanel, "viewPanel");
            this.viewPanel.Controls.Add(this.camerasListView);
            this.viewPanel.Controls.Add(this.infoPanel);
            this.viewPanel.Name = "viewPanel";
            // 
            // camerasListView
            // 
            resources.ApplyResources(this.camerasListView, "camerasListView");
            this.camerasListView.AllowDrop = true;
            this.camerasListView.ContextMenuStrip = this.cameraContextMenuStrip;
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
            this.camerasListView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.camerasListView_AfterLabelEdit);
            this.camerasListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.camerasListView_DragEnter);
            this.camerasListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.camerasListView_MouseDown);
            // 
            // infoPanel
            // 
            resources.ApplyResources(this.infoPanel, "infoPanel");
            this.infoPanel.Name = "infoPanel";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.developerLinkLabel);
            this.panel1.Controls.Add(this.commandLineHelpButton);
            this.panel1.Name = "panel1";
            // 
            // developerLinkLabel
            // 
            resources.ApplyResources(this.developerLinkLabel, "developerLinkLabel");
            this.developerLinkLabel.Name = "developerLinkLabel";
            this.developerLinkLabel.TabStop = true;
            this.developerLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // commandLineHelpButton
            // 
            resources.ApplyResources(this.commandLineHelpButton, "commandLineHelpButton");
            this.commandLineHelpButton.Name = "commandLineHelpButton";
            this.commandLineHelpButton.UseVisualStyleBackColor = true;
            this.commandLineHelpButton.Click += new System.EventHandler(this.commandLineHelpButton_Click);
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
            resources.ApplyResources(this.ctrlPanel, "ctrlPanel");
            this.ctrlPanel.Controls.Add(this.tabControl1);
            this.ctrlPanel.Name = "ctrlPanel";
            // 
            // splitLabel
            // 
            resources.ApplyResources(this.splitLabel, "splitLabel");
            this.splitLabel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.splitLabel.Name = "splitLabel";
            this.splitLabel.Click += new System.EventHandler(this.splitLabel_Click);
            this.splitLabel.MouseEnter += new System.EventHandler(this.splitLabel_MouseEnter);
            this.splitLabel.MouseLeave += new System.EventHandler(this.splitLabel_MouseLeave);
            // 
            // camPanel
            // 
            resources.ApplyResources(this.camPanel, "camPanel");
            this.camPanel.BackColor = System.Drawing.Color.Black;
            this.camPanel.Controls.Add(this.hintDropCamera);
            this.camPanel.Controls.Add(this.hintRTSP2);
            this.camPanel.Controls.Add(this.hintRTSP1);
            this.camPanel.Controls.Add(this.hintAddCamera);
            this.camPanel.Controls.Add(this.hintOpenCtrl);
            this.camPanel.Controls.Add(this.panel2);
            this.camPanel.Controls.Add(this.splitLabel);
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
            resources.ApplyResources(this.hintRTSP2, "hintRTSP2");
            this.hintRTSP2.BackColor = System.Drawing.SystemColors.Info;
            this.hintRTSP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintRTSP2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hintRTSP2.Name = "hintRTSP2";
            // 
            // hintRTSP1
            // 
            resources.ApplyResources(this.hintRTSP1, "hintRTSP1");
            this.hintRTSP1.BackColor = System.Drawing.SystemColors.Info;
            this.hintRTSP1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hintRTSP1.ForeColor = System.Drawing.SystemColors.ControlText;
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
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.errorInitVLCbadLib);
            this.panel2.Controls.Add(this.errorInitVLCbadLibVer);
            this.panel2.Controls.Add(this.errorInitVLCnoLib);
            this.panel2.Controls.Add(this.errorInitVLC);
            this.panel2.Controls.Add(this.cameraDeleteConfirm2);
            this.panel2.Controls.Add(this.errorSaveSettings);
            this.panel2.Controls.Add(this.commandLineHelp);
            this.panel2.Controls.Add(this.errorLoadSettings);
            this.panel2.Controls.Add(this.cameraDeleteConfirm1);
            this.panel2.Name = "panel2";
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
            // splitter1
            // 
            resources.ApplyResources(this.splitter1, "splitter1");
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Name = "splitter1";
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoving += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoving);
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // showHintTimer
            // 
            this.showHintTimer.Tick += new System.EventHandler(this.showHintTimer_Tick);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.camPanel);
            this.Controls.Add(this.ctrlPanel);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.cameraContextMenuStrip.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.editCamPanel.ResumeLayout(false);
            this.editCamPanel.PerformLayout();
            this.camEditBtnsPanel.ResumeLayout(false);
            this.camEditBtnsPanel.PerformLayout();
            this.viewPanel.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ctrlPanel.ResumeLayout(false);
            this.camPanel.ResumeLayout(false);
            this.camPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
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
        private TabPage tabPage1;
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
        private TabPage tabPage2;
        private Panel ctrlPanel;
        private Label splitLabel;
        private Panel camPanel;
        private Splitter splitter1;
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
        private Panel panel2;
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
    }
}

