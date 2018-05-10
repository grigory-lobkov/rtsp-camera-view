using System;
using System.Drawing;
using System.Windows.Forms;
using AxAXVLC;

public enum VlcStatus { Stopped = 0, Playing = 1, Buffering = 2, Preparing = 3, Invisible = 4 };

/********************
 * Copyright 2018 Grigory Lobkov
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 *
 * You may obtain a copy of the License at
 * https://github.com/grigory-lobkov/rtsp-camera-view/blob/master/LICENSE
 *
 *
 * TODO:
 * Не рисовать PaintWait, когда поверх уже нарисовалось видео =
 * = Do not draw PaintWait, when video is drown upside
 * 
 ********************/

namespace RTSP_mosaic_VLC_player
{
    public delegate void EventHandlerWObject(object sender);
    public delegate void ZoomEventHandler(object sender, int x, int y, int w, int h);

    [ToolboxBitmap(typeof(ColorDialog))]
    public partial class RtspBadGoodVLC : Control
    {
        private string rtspBad;
        private string rtspGood;
        private string aspectRatio;
        private int vlcH;
        private int vlcW;
        private int volume = 0;
        //private int mouseDownX, mouseDownY, mouseDownW, mouseDownH;
        private bool isSoundPresent;
        private bool isRtsp2Shown;
        public event EventHandlerWObject OnStop;
        public event EventHandlerWObject OnBuffering;
        public event EventHandlerWObject OnPlay;
        public event EventHandlerWObject OnSoundtrackFound;
        public event EventHandlerWObject OnBeforeRtspSwitch;
        private string playlistAddOptions = null;//":no-audio"

        public int Volume
        {
            get { return volume; }
            set
            {
                try { vlc1.Volume = value; vlc2.Volume = value; }
                catch { }
                volume = value;
            }
        }
        public bool SoundPresent
        {
            get { return isSoundPresent; }
        }
        public string RtspBad
        {
            get { return rtspBad; }
            set
            {
                Stop(this);
                vlc1.playlist.items.clear();
                if (value != "" && value != null) vlc1.playlist.add(value, null, playlistAddOptions);
                vlc1.Toolbar = false;
                rtspBad = value;
            }
        }
        public string RtspGood
        {
            get { return rtspGood; }
            set
            {
                Stop(this);
                vlc2.playlist.items.clear();
                if (value != "" && value != null) vlc2.playlist.add(value, null, playlistAddOptions);
                vlc2.Toolbar = false;
                rtspGood = value;
            }
        }
        public string AspectRatio
        {
            get { return aspectRatio; }
            set
            {
                Stop(this);
                try
                {
                    if (value != "" && value != null)
                    {
                        vlc1.video.aspectRatio = value;
                        vlc2.video.aspectRatio = value;
                    }
                    else
                    {
                        vlc1.video.aspectRatio = Properties.Resources.defaultAspectRatio;
                        vlc2.video.aspectRatio = Properties.Resources.defaultAspectRatio;
                    }
                }
                catch { }
                aspectRatio = value;
            }
        }
        public bool EnableZoom { get { return topPanel.enableZoom; } set { topPanel.enableZoom = value; } }

        public VlcStatus Status
        {
            get
            {
                if (vlc1Status == VlcStatus.Playing || vlc2Status == VlcStatus.Playing) return VlcStatus.Playing;
                if (vlc1Status == VlcStatus.Buffering || vlc2Status == VlcStatus.Buffering) return VlcStatus.Buffering;
                if (vlc1Status == VlcStatus.Preparing || vlc2Status == VlcStatus.Preparing) return VlcStatus.Preparing;
                return VlcStatus.Stopped;
            }
        }
        public override bool AllowDrop { get { return topPanel.AllowDrop; } set { topPanel.AllowDrop = value; } }


        public RtspBadGoodVLC()
        {
            InitializeComponent();
            vlc1Status = VlcStatus.Preparing;
            vlc2Status = VlcStatus.Preparing;
            try { Stop(null); }
            catch { }
        }

        public bool Stop(object sender)
        {
            if (vlc1Status != VlcStatus.Stopped || vlc2Status != VlcStatus.Stopped)
            {
                topPanel.Wait = true;
                lostRtsp1Timer.Enabled = false;
                lostRtsp2Timer.Enabled = false;
                switchToRtsp2Timer.Enabled = false;
                switchToRtsp1Timer.Enabled = false;
                stopRtsp1Timer.Enabled = false;
                stopRtsp2Timer.Enabled = false;
                stopOnInvisibleTimer.Enabled = false;
                vlcH = 0;
                vlcW = 0;
                vlc1.playlist.stop();
                vlc2.playlist.stop();
                vlc2.SendToBack();
                isRtsp2Shown = false;
                isSoundPresent = false;
                vlc1Status = VlcStatus.Stopped;
                vlc2Status = VlcStatus.Stopped;
                if (sender != null) OnStop?.Invoke(this);
                topPanel.Wait = false;
                return true;
            }
            return false;
        }

        public bool Play(object sender)
        {
            if (vlc1Status == VlcStatus.Stopped && vlc2Status == VlcStatus.Stopped && vlc1.playlist.items.count>0)
            {
                topPanel.Wait = true;
                lostRtsp1Timer.Interval = Convert.ToInt32(Properties.Resources.lostRtspOnStartTimer);
                lostRtsp1Timer.Enabled = true;
                vlc1Status = VlcStatus.Buffering;
                vlc1.playlist.play();
                OnBuffering?.Invoke(this);
                return true;
            }
            return false;
        }
        
        protected virtual void OnBeforeRtspSwitch1(object sender)
        {
            if (sender != null) OnBeforeRtspSwitch?.Invoke(this);
        }

        private void Vlc1Buffering(object sender, AxAXVLC.DVLCEvents_MediaPlayerBufferingEvent e)
        {
            if (vlc1Status == VlcStatus.Buffering)
            {
                if (vlc2Status == VlcStatus.Playing)
                {
                    vlc1.audio.Volume = 0;
                    return;
                }
                vlc1.audio.Volume = this.volume;
                if (vlc1.audio.track > 1 && !isSoundPresent)
                {
                    isSoundPresent = vlc1.audio.track > 1;
                    OnSoundtrackFound?.Invoke(this);
                }
            }
        }

        private void Vlc2Buffering(object sender, AxAXVLC.DVLCEvents_MediaPlayerBufferingEvent e)
        {
            if (vlc2Status == VlcStatus.Buffering)
            {
                if (vlc1Status == VlcStatus.Playing)
                {
                    vlc2.audio.Volume = 0;
                    return;
                }
                vlc2.audio.Volume = this.volume;
                if (vlc1.audio.track > 1 && !isSoundPresent)
                {
                    isSoundPresent = vlc1.audio.track > 1;
                    OnSoundtrackFound?.Invoke(this);
                }
            }
        }

        private void Vlc1PositionChanged(object sender, AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEvent e)
        {
            lostRtsp1Timer.Enabled = false;
            lostRtsp1Timer.Enabled = true;
            if (vlc1Status == VlcStatus.Buffering)
            {
                vlc1Status = VlcStatus.Playing;
                OnPlay?.Invoke(sender);
                topPanel.Wait = false;
                lostRtsp1Timer.Interval = Convert.ToInt32(Properties.Resources.lostRtspTimer);
                if (vlc2Status == VlcStatus.Playing)
                {
                    switchToRtsp1Timer.Interval = 500;
                    switchToRtsp1Timer.Enabled = true;
                    OnBeforeRtspSwitch1(this);
                }
            }
            if (isRtsp2Shown) return;
            if (vlcH <= 0)
                if (vlc1.video.height > 0)
                {
                    vlcH = vlc1.video.height;
                    vlcW = vlc1.video.width;
                }
                else
                {
                    vlcH -= 1;
                    if (vlcH < -3) { vlcH = 576; vlcW = 704; }
                }
            if (vlcH > 0 && !switchToRtsp2Timer.Enabled && !(vlc2Status == VlcStatus.Buffering || vlc2Status == VlcStatus.Preparing) && this.Height > vlcH * Convert.ToInt32(Properties.Resources.switchToGoodRtspPercent) / 100)
            {
                if (vlc2Status == VlcStatus.Playing)
                {
                    switchToRtsp2Timer.Interval = 50;
                    OnBeforeRtspSwitch1(this);
                }
                else
                {
                    vlc2Status = VlcStatus.Preparing;
                    switchToRtsp2Timer.Interval = Convert.ToInt32(Properties.Resources.switchToGoodRtspTimer);
                }
                switchToRtsp2Timer.Enabled = true;
            }
        }

        private void Vlc2PositionChanged(object sender, AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEvent e)
        {
            lostRtsp2Timer.Enabled = false;
            lostRtsp2Timer.Enabled = true;
            if (vlc2Status == VlcStatus.Buffering)
            {
                vlc2Status = VlcStatus.Playing;
                lostRtsp2Timer.Interval = Convert.ToInt32(Properties.Resources.lostGoodRtspTimer);
                if (vlc1Status == VlcStatus.Playing)
                {
                    switchToRtsp2Timer.Interval = 500;
                    switchToRtsp2Timer.Enabled = true;
                    OnBeforeRtspSwitch1(this);
                }
            }
            if (!isRtsp2Shown) return;
            if (vlcH > 0 && this.Height <= vlcH && !switchToRtsp1Timer.Enabled && !(vlc1Status == VlcStatus.Buffering || vlc1Status == VlcStatus.Preparing))
            {
                if (vlc1Status == VlcStatus.Playing)
                {
                    switchToRtsp1Timer.Interval = 50;
                    OnBeforeRtspSwitch1(this);
                }
                else
                {
                    vlc1Status = VlcStatus.Preparing;
                    switchToRtsp1Timer.Interval = Convert.ToInt32(Properties.Resources.switchToBadRtspTimer);
                }
                switchToRtsp1Timer.Enabled = true;
            }
        }

        private void LostRtsp1Timer_Tick(object sender, EventArgs e)
        {
            lostRtsp1Timer.Enabled = false;
            if (vlc2Status == VlcStatus.Playing)
            {
                vlc1.playlist.stop();
                vlc1Status = VlcStatus.Stopped;
                vlc1.SendToBack();
                isRtsp2Shown = true;
            }
        }

        private void LostRtsp2Timer_Tick(object sender, EventArgs e)
        {
            lostRtsp2Timer.Enabled = false;
            if (vlc1Status == VlcStatus.Playing)
            {
                vlc2.playlist.stop();
                vlc2Status = VlcStatus.Stopped;
                vlc2.SendToBack();
                isRtsp2Shown = false;
            }
        }

        private void SwitchToRtsp2Timer_Tick(object sender, EventArgs e)
        {
            switchToRtsp2Timer.Enabled = false;
            stopRtsp2Timer.Enabled = false;
            if (vlc2Status == VlcStatus.Playing)
            {
                vlc1.SendToBack();
                isRtsp2Shown = true;
                stopRtsp1Timer.Enabled = true;
                vlc2.audio.Volume = this.volume;
            }
            else if (vlc2.playlist.items.count > 0)
            {
                vlc2.SendToBack();
                isRtsp2Shown = false;
                vlc2.Visible = true;
                lostRtsp2Timer.Interval = Convert.ToInt32(Properties.Resources.lostGoodRtspOnStartTimer);
                lostRtsp2Timer.Enabled = true;
                vlc2Status = VlcStatus.Buffering;
                vlc2.playlist.play();
            }
        }

        private void SwitchToRtsp1Timer_Tick(object sender, EventArgs e)
        {
            switchToRtsp1Timer.Enabled = false;
            stopRtsp1Timer.Enabled = false;
            if (vlc1Status == VlcStatus.Playing)
            {
                vlc2.SendToBack();
                isRtsp2Shown = false;
                stopRtsp2Timer.Enabled = true;
                vlc1.audio.Volume = this.volume;
            }
            else
            {
                vlc1.SendToBack();
                isRtsp2Shown = true;
                vlc1.Visible = true;
                lostRtsp1Timer.Interval = Convert.ToInt32(Properties.Resources.lostGoodRtspOnStartTimer);
                lostRtsp1Timer.Enabled = true;
                vlc1Status = VlcStatus.Buffering;
                vlc1.playlist.play();
            }
        }

        private void StopRtsp1Timer_Tick(object sender, EventArgs e)
        {
            stopRtsp1Timer.Enabled = false;
            if (!isRtsp2Shown) return;
            vlc1.playlist.stop();
            vlc1Status = VlcStatus.Stopped;
        }

        private void StopRtsp2Timer_Tick(object sender, EventArgs e)
        {
            stopRtsp2Timer.Enabled = false;
            if (isRtsp2Shown) return;
            vlc2.playlist.stop();
            vlc2Status = VlcStatus.Stopped;
        }

        private void StopOnInvisibleTimer_Tick(object sender, EventArgs e)
        {
            stopOnInvisibleTimer.Enabled = false;
            if (isSoundPresent && this.volume > 0) return;
            if (vlc1Status == VlcStatus.Stopped && vlc2Status == VlcStatus.Stopped) return;
            Stop(null);
            vlc1Status = VlcStatus.Invisible;
        }

        private void TopPanel_MouseEnter(Object sender, EventArgs e) { this.OnMouseEnter(e); }
        private void TopPanel_MouseDoubleClick(Object sender, MouseEventArgs e) { this.OnMouseDoubleClick(e); }
        private void TopPanel_MouseDown(Object sender, MouseEventArgs e) { this.OnMouseDown(e); }
        private void TopPanel_MouseMove(Object sender, MouseEventArgs e) { this.OnMouseMove(e); }
        private void TopPanel_MouseUp(Object sender, MouseEventArgs e) { this.OnMouseUp(e); }
        private void TopPanel_DragEnter(Object sender, DragEventArgs e) { this.OnDragEnter(e); }
        private void TopPanel_DragDrop(Object sender, DragEventArgs e) { this.OnDragDrop(e); }
    }
    [ToolboxBitmap(typeof(Panel))]
    public class TopPanel : Panel
    {
        public bool enableZoom = false; // handlers works, but hard to zoom video, need aspectRatio calculations
        public Color zoomColor = Color.Red;
        public int waitBrickCount = 5;
        public int repaintZoomInterval = 20;
        public int waitInterval = 400;
        private int x1 = -1, y1, x2, y2, x3 = -1, y3, x4, y4; // for paintRect
        private int z5; // for paintWait
        private bool paintRect = false;
        private Timer repaintTimer;
        public event ZoomEventHandler OnZoom;
        private bool paintWait = true;

        public TopPanel() {
            repaintTimer = new Timer();
            repaintTimer.Tick += new EventHandler(this.RepaintTimer_Tick);
        }
        protected override void OnPaintBackground(PaintEventArgs e) { } //for transparency
        protected override CreateParams CreateParams //for transparency
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }
        private void RepaintTimer_Tick(object sender, EventArgs e)
        {
            x3 = -1;
            z5 = (z5 + 1) % waitBrickCount;
            Invalidate();
        }
        public bool Wait
        {
            get { return paintWait; }
            set
            {
                if (value == paintWait) return;
                if (value)
                {
                    repaintTimer.Interval = waitInterval;
                    z5 = 0;
                    repaintTimer.Enabled = true;
                    Invalidate();
                }
                else
                {
                    z5 = -1;
                    repaintTimer.Enabled = false;
                    Invalidate();
                }
                paintWait = value;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (paintWait)
            {
                int x5 = this.Width / 2, y5 = this.Height / 2;
                int w = Math.Max(20, x5 / 2 / waitBrickCount), h = w / 2, m = w / 10,
                    x = x5 - w * waitBrickCount / 2, y = y5 - h;
                //Color cc = e.Graphics.getPixel(x, y);
                //IntPtr myDC=e.Graphics.GetHdc();
                //Color cc = ColorTranslator.FromWin32(System.Drawing.GetPixel(myDC, x, y));
                //Bitmap bmp = new Bitmap(x + 1, y + 1, e.Graphics);
                //Color cc = Color.FromArgb(255,bmp.GetPixel(x, y));
                //if (cc != Color.FromArgb(255,this.BackColor) && cc != Color.FromArgb(255,Color.Gray) && cc != Color.FromArgb(255,Color.White)) return;
                if (z5 >= 0)
                {
                    SolidBrush b1 = new SolidBrush(Color.Gray);
                    SolidBrush b2 = new SolidBrush(Color.White);
                    if (x < 0) { x = 0; w = x5 * 2 / waitBrickCount; h = w / 2; }
                    for (int i = 0; i < waitBrickCount; i++)
                        e.Graphics.FillRectangle(i == z5 ? b2 : b1, x + w * i, y, w - m, h);
                }
                else e.Graphics.FillRectangle(new SolidBrush(this.BackColor), x, y, w * waitBrickCount, h);
                return;
            }
            if (paintRect)
            {
                if (x3 >= 0) e.Graphics.DrawRectangle(new Pen(this.BackColor), new Rectangle(
                    new Point(Math.Min(x3, x4), Math.Min(y3, y4)), new Size(Math.Abs(x4 - x3), Math.Abs(y4 - y3))));
                if (x1 >= 0) e.Graphics.DrawRectangle(new Pen(this.zoomColor), new Rectangle(
                    new Point(Math.Min(x1, x2), Math.Min(y1, y2)), new Size(Math.Abs(x2 - x1), Math.Abs(y2 - y1))));
                else paintRect = false;
                x3 = x1; x4 = x2; y3 = y1; y4 = y2;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (paintWait) return;
            if (enableZoom)
            {
                x2 = x1 = e.X; y2 = y1 = e.Y;
                paintRect = true;
                repaintTimer.Interval = repaintZoomInterval;
                repaintTimer.Enabled = true;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (paintRect)
            {
                x2 = e.X; y2 = e.Y;
                Invalidate();
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (paintWait) return;
            if (enableZoom)
            {
                repaintTimer.Enabled = false;
                x2 = e.X; y2 = e.Y;
                OnZoom?.Invoke(this, Math.Min(x1, x2), Math.Min(y1, y2), Math.Abs(x2 - x1), Math.Abs(y2 - y1));
                x1 = -1;
                Invalidate();
            }
        }
    }
}
