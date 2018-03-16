using System;
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
    partial class RtspBadGoodVLC
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
            if (disposing)
            {
                vlc1.Dispose();
                vlc2.Dispose();
                topPanel.Dispose();
                lostRtsp1Timer.Dispose();
                lostRtsp2Timer.Dispose();
                switchToRtsp2Timer.Dispose();
                switchToRtsp1Timer.Dispose();
                stopRtsp1Timer.Dispose();
                stopRtsp2Timer.Dispose();
                stopOnInvisibleTimer.Dispose();
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
            this.vlc1 = new AxAXVLC.AxVLCPlugin2();
            this.vlc2 = new AxAXVLC.AxVLCPlugin2();
            ((System.ComponentModel.ISupportInitialize)(vlc1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(vlc2)).BeginInit();

            topPanel = new TopPanel();
            lostRtsp1Timer = new Timer();
            lostRtsp2Timer = new Timer();
            switchToRtsp2Timer = new Timer();
            switchToRtsp1Timer = new Timer();
            stopRtsp1Timer = new Timer();
            stopRtsp2Timer = new Timer();
            stopOnInvisibleTimer = new Timer();

            this.SuspendLayout();
            // 
            // vlc1
            // 
            vlc1.Enabled = false;
            vlc1.Dock = DockStyle.Fill;
            vlc1.MediaPlayerPositionChanged += new AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEventHandler(vlc1PositionChanged);
            vlc1.MediaPlayerBuffering += new AxAXVLC.DVLCEvents_MediaPlayerBufferingEventHandler(vlc1Buffering);
            //vlc1.Visible = false;
            this.Controls.Add(vlc1);
            // 
            // vlc2
            // 
            vlc2.Enabled = true;
            vlc2.Dock = DockStyle.Fill;
            vlc2.MediaPlayerPositionChanged += new AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEventHandler(vlc2PositionChanged);
            vlc2.MediaPlayerBuffering += new AxAXVLC.DVLCEvents_MediaPlayerBufferingEventHandler(vlc2Buffering);
            vlc2.Visible = false;
            this.Controls.Add(vlc2);
            //
            // topPanel
            //
            topPanel.Dock = DockStyle.Fill;
            this.Controls.Add(topPanel);
            topPanel.BringToFront();
            topPanel.MouseEnter += new EventHandler(this.topPanel_MouseEnter);
            topPanel.MouseDoubleClick += new MouseEventHandler(this.topPanel_MouseDoubleClick);
            topPanel.MouseDown += new MouseEventHandler(this.topPanel_MouseDown);
            topPanel.MouseMove += new MouseEventHandler(this.topPanel_MouseMove);
            topPanel.MouseUp += new MouseEventHandler(this.topPanel_MouseUp);
            topPanel.DragEnter += new DragEventHandler(this.topPanel_DragEnter);
            topPanel.DragDrop += new DragEventHandler(this.topPanel_DragDrop);
            // Timers
            lostRtsp1Timer.Tick += new EventHandler(this.lostRtsp1Timer_Tick);
            switchToRtsp2Timer.Tick += new EventHandler(this.switchToRtsp2Timer_Tick);
            lostRtsp2Timer.Tick += new EventHandler(this.lostRtsp2Timer_Tick);
            switchToRtsp1Timer.Tick += new EventHandler(this.switchToRtsp1Timer_Tick);
            stopRtsp1Timer.Interval = Convert.ToInt32(Properties.Resources.stopBadRtspTimer);
            stopRtsp1Timer.Tick += new EventHandler(this.stopRtsp1Timer_Tick);
            stopRtsp2Timer.Interval = Convert.ToInt32(Properties.Resources.stopGoodRtspTimer);
            stopRtsp2Timer.Tick += new EventHandler(this.stopRtsp2Timer_Tick);
            stopOnInvisibleTimer.Interval = Convert.ToInt32(Properties.Resources.stopOnInvisibleTimer);
            stopOnInvisibleTimer.Tick += new EventHandler(this.stopOnInvisibleTimer_Tick);

            ((System.ComponentModel.ISupportInitialize)(this.vlc1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vlc2)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private TopPanel topPanel;
        private AxAXVLC.AxVLCPlugin2 vlc1;
        private AxAXVLC.AxVLCPlugin2 vlc2;
        private VlcStatus vlc1Status;
        private VlcStatus vlc2Status;
        private Timer lostRtsp1Timer;
        private Timer lostRtsp2Timer;
        private Timer switchToRtsp2Timer;
        private Timer switchToRtsp1Timer;
        private Timer stopRtsp1Timer;
        private Timer stopRtsp2Timer;
        private Timer stopOnInvisibleTimer;
    }
}
