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
    public partial class RtspBadGoodControl : Control
    {
        public string Title { get { return nameLabel.Text; } set { nameLabel.Text = value; } }
        private string RtspBad { get { return bgvlc.RtspBad; } set { bgvlc.RtspBad = value; } }
        private string RtspGood { get { return bgvlc.RtspGood; } set { bgvlc.RtspGood = value; } }
        private string AspectRatio { get { return bgvlc.AspectRatio; } set { bgvlc.AspectRatio = value; } }
        public int Volume { get { return bgvlc.Volume; } set { bgvlc.Volume = value; } }
        public bool SoundPresent { get { return bgvlc.SoundPresent; } }
        public override bool AllowDrop { get { return bgvlc.AllowDrop; } set { bgvlc.AllowDrop = value; } }
        public bool isCameraSet = false;
        public VlcStatus Status { get { return bgvlc.Status; } }
        public event EventHandler onOptionsClick;
        private Camera camera = null;
        public Camera Camera { get { return camera; } set { setCamera(value); } }
        private NameView nameView = null;
        public NameView NameView { get { return nameView; } set { setNameView(value); } }
        private NameView globalNameView = null;
        public NameView GlobalNameView { get { return globalNameView; } set { setGlobalNameView(value); } }
        //private Graphics gfx;

        public RtspBadGoodControl()
        {
            InitializeComponent();
            //gfx = CreateGraphics();
        }

        public void resizeEnd(object sender) { sizeChangedTimer_Tick(sizeChangedTimer, null); }
        private void bgvlc_MouseEnter(Object sender, EventArgs e) { showControl(); OnMouseEnter(e); }
        private void bgvlc_MouseDoubleClick(Object sender, MouseEventArgs e) {
            OnMouseDoubleClick(e);
            if (Dock == DockStyle.Fill) btnMaxMin.BackgroundImage = Convert.ToInt32(btnMaxMin.Tag) == 0 ? Properties.Resources.btn_minimize : InvertImage(Properties.Resources.btn_minimize);
            else btnMaxMin.BackgroundImage = Convert.ToInt32(btnMaxMin.Tag) == 0 ? Properties.Resources.btn_maximize : InvertImage(Properties.Resources.btn_maximize);
        }
        private void bgvlc_DragEnter(Object sender, DragEventArgs e) { showControl(); OnDragEnter(e); }
        private void bgvlc_DragDrop(Object sender, DragEventArgs e) { showControl(); OnDragDrop(e); }
        private void bgvlc_MouseDown(Object sender, MouseEventArgs e) { showControl(); OnMouseDown(e); }
        private void bgvlc_MouseMove(Object sender, MouseEventArgs e) { showControl(); OnMouseMove(e); }
        private void bgvlc_MouseUp(Object sender, MouseEventArgs e) { showControl(); OnMouseUp(e); }

        private void setCamera(Camera c)
        {
            if (c == null)
            {
                stop(this);
                RtspBad = "";
                RtspGood = "";
                Title = "";
                AspectRatio = Properties.Resources.defaultAspectRatio;
                btnPlayStop.BackgroundImage = Convert.ToInt32(btnPlayStop.Tag) == 0 ? Properties.Resources.btn_eject : InvertImage(Properties.Resources.btn_eject);
                hideControlTimer.Interval = Convert.ToInt32(Properties.Resources.hideControlTimer);
                nameLabel.Enabled = false;
                setNameView(null);
            }
            else
            {
                if (c.rtspBad == null || c.rtspBad == "") return;
                Title = c.name;
                RtspBad = c.rtspBad;
                RtspGood = c.rtspGood;
                AspectRatio = c.aspectRatio;
                btnPlayStop.BackgroundImage = Convert.ToInt32(btnPlayStop.Tag) == 0 ? Properties.Resources.btn_play : InvertImage(Properties.Resources.btn_play);
                setNameView(c.nameView);
            }
            camera = c;
            isCameraSet = (c != null);
            controlPanelR.Visible = isCameraSet;
            btnVolMinus.Visible = isCameraSet;
            btnVolPlus.Visible = isCameraSet;
        }
        private void setNameView(NameView nv)
        {
            if (nv == null)
            {
                nameView = globalNameView;
            }
            else
            {
                nameView = (nv.inheritGlobal && globalNameView != null) ? globalNameView : nv;
                nameView.enabled = nv.enabled;
                nameLabel.Enabled = nv.enabled;
            }
            if (nameView != null)
            {
                nameLabel.Enabled = nameView.enabled;
                if (nameView.enabled)
                {
                    hideControlTimer.Interval = nameView.autoHide ? nameView.autoHideSec * 1000 :
                        Convert.ToInt32(Properties.Resources.hideControlTimer);
                    nameLabel.BackColor = nameView.paintBg ? nameView.bgColor : Color.Transparent;
                    nameLabel.ForeColor = nameView.color;
                    updateNameLabelPosition();
                    nameLabel.Visible = nameView.autoHide ? controlPanel.Visible : true;
                }
            }
            else
            {
                nameLabel.Enabled = false;
            }
        }
        private void setGlobalNameView(NameView nv)
        {
            globalNameView = nv;
            if (camera != null && camera.nameView != null && camera.nameView.inheritGlobal)
            {
                setNameView(camera.nameView);
            }
        }

        private void updateNameLabelPosition()
        {
            if (nameView == null) return;
            int clientw = ClientSize.Width,
                clienth = ClientSize.Height,
                clientm = Math.Min(clientw, clienth),
                fs = Math.Max(clientm / 100 * nameView.size, 4);
            nameLabel.Font = new Font(nameLabel.Font.Name, fs, nameLabel.Font.Style, nameLabel.Font.Unit);
            nameLabel.Refresh();
            int top, left;
            switch (nameView.position) {
                case TextPosition.TopLeft:
                case TextPosition.TopCenter:
                case TextPosition.TopRight:
                    top = clienth / 40;
                    break;
                default: // bottom
                    top = clienth * 11 / 12;
                    if (nameView.autoHide || controlPanel.Visible) top = top - controlPanel.Height;
                    break;
            };
            switch (nameView.position) {
                case TextPosition.TopLeft:
                case TextPosition.BottomLeft:
                    left = clientw / 40;
                    break;
                case TextPosition.TopCenter:
                case TextPosition.BottomCenter:
                    left = (clientw - nameLabel.Width) / 2;
                    break;
                default: // right
                    left = clientw * 39 / 40 - nameLabel.Width;
                    break;
            };
            nameLabel.Location = new Point(left, top);
        }

        private void sizeChangedTimer_Tick(object sender, EventArgs e)
        {
            (sender as Timer).Enabled = false;
            int clientw = ClientSize.Width,
                clienth = ClientSize.Height,
                clientm = Math.Min(clientw, clienth);
            int bh = Math.Max(clientm / 14, 14), bm = bh / 7, bh2 = Math.Max(clientm / 21, 10), bm2 = bm * 2;
            Size bS = new Size(bh, bh), bS2 = new Size(bh2, bh2);
            int bs = bh + bm, bs2 = bh2 + bm;

            controlPanel.Location = new Point(0, clienth - bs - bm);
            controlPanel.Size = new Size(clientw, bs + bm);
            bgvlc.Location = new Point(0, 0);
            bgvlc.Size = ClientSize;
            btnPlayStop.Size = bS;
            btnVolMinus.Size = bS;
            btnVolPlus.Size = bS;
            btnOptions.Size = bS2;
            btnMaxMin.Size = bS2;
            btnClose.Size = bS2;
            btnPlayStop.Location = new Point(bs, bm);
            btnVolMinus.Location = new Point(bs * 4, bm);
            btnVolPlus.Location = new Point(bs * 5, bm);
            btnOptions.Location = new Point(bm2, bm2);
            btnMaxMin.Location = new Point(bm2 + bs2, bm2);
            btnClose.Location = new Point(bm2 + bs2 * 2, bm2);
            controlPanelR.Width = bm2 * 2 + bs2 * 3;
            updateNameLabelPosition();
        }

        public bool stop(object sender) 
        {
            btnPlayStop.BackgroundImage = Convert.ToInt32(btnPlayStop.Tag) == 0 ? Properties.Resources.btn_wait : InvertImage(Properties.Resources.btn_wait);
            return bgvlc.stop(this);
        }
        public bool play(object sender)
        {
            btnPlayStop.BackgroundImage = Convert.ToInt32(btnPlayStop.Tag) == 0 ? Properties.Resources.btn_wait : InvertImage(Properties.Resources.btn_wait);
            return bgvlc.play(this);
        }

        public void bgvlc_Stop(object sender)
        {
            btnPlayStop.BackgroundImage = Convert.ToInt32(btnPlayStop.Tag) == 0 ? Properties.Resources.btn_play : InvertImage(Properties.Resources.btn_play);
        }
        public void bgvlc_Play(object sender)
        {
            btnPlayStop.BackgroundImage = Convert.ToInt32(btnPlayStop.Tag) == 0 ? Properties.Resources.btn_stop : InvertImage(Properties.Resources.btn_stop);
        }

        public void bgvlc_SoundTrackFound(object sender)
        {
            btnVolMinus.Visible = btnVolPlus.Visible = true;
            showControl();
        }

        public void bgvlc_BeforeRtspSwitch(object sender)
        {
            hideControlTimer_Tick(hideControlTimer, null);
        }

        private void showControl()
        {
            if (nameLabel.Enabled)
            {
                nameLabel.Visible = true;
                if (!controlPanel.Visible && nameView != null && !nameView.autoHide &&
                    (nameView.position == TextPosition.BottomLeft ||
                    nameView.position == TextPosition.BottomCenter ||
                    nameView.position == TextPosition.BottomRight
                    )) nameLabel.Top = nameLabel.Top - controlPanel.Height;
            }
            controlPanel.Visible = true;
            hideControlTimer.Enabled = false;
            hideControlTimer.Enabled = true;
        }

        private void hideControlTimer_Tick(object sender, EventArgs e)
        {
            hideControlTimer.Enabled = false;
            if (nameLabel.Enabled)
            {
                if (nameView.autoHide) nameLabel.Visible = false;
                else if (nameView.position == TextPosition.BottomLeft ||
                    nameView.position == TextPosition.BottomCenter ||
                    nameView.position == TextPosition.BottomRight
                    ) nameLabel.Top = nameLabel.Top + controlPanel.Height;
            }
            controlPanel.Visible = false;
        }

        private Bitmap InvertImage(Image source)
        {
            Bitmap newBitmap = new Bitmap(source.Width, source.Height);
            Graphics g = Graphics.FromImage(newBitmap);
            System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(
               new float[][]
               {
                  new float[] {-1, 0, 0, 0, 0},
                  new float[] {0, -1, 0, 0, 0},
                  new float[] {0, 0, -1, 0, 0},
                  new float[] {0, 0, 0, 1, 0},
                  new float[] {1, 1, 1, 0, 1}
               });
            colorMatrix.Matrix00 = colorMatrix.Matrix11 = colorMatrix.Matrix22 = -1f;
            colorMatrix.Matrix33 = colorMatrix.Matrix44 = 1f;
            System.Drawing.Imaging.ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height),
                        0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);
            g.Dispose();
            return newBitmap;
        }

        private void btn_MouseEnterLeaveInvert(object sender, EventArgs e)
        {
            Panel s = (sender as Panel);
            s.BackgroundImage = InvertImage(s.BackgroundImage);
            s.Tag = Convert.ToInt32(s.Tag) != 0 ? 0 : 1;
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point l = (sender as Panel).Location;
                l.X += 1;
                l.Y += 1;
                (sender as Panel).Location = l;
            }
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point l = (sender as Panel).Location;
                l.X -= 1;
                l.Y -= 1;
                (sender as Panel).Location = l;
            }
        }

        private void btnPlayStop_MouseClick(object sender, MouseEventArgs e)
        {
            showControl();
            if (!isCameraSet) return;
            if (bgvlc.Status == VlcStatus.Playing) stop(btnPlayStop);
            else if (bgvlc.Status == VlcStatus.Stopped) play(btnPlayStop);
        }

        private void btnVolMinus_Click(object sender, EventArgs e)
        {
            bgvlc.Volume -= Math.Max(16, bgvlc.Volume / 4);//25 if 100
            showControl();
        }

        private void btnVolPlus_Click(object sender, EventArgs e)
        {
            bgvlc.Volume += Math.Max(16, bgvlc.Volume / 3);//25 if 75
            showControl();
        }

        private void controlPanel_MouseEnter(object sender, EventArgs e)
        {
            showControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            showControl();
            Camera = null;
        }

        private void btnMaxMin_Click(object sender, EventArgs e)
        {
            bgvlc_MouseDoubleClick(this,null);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            showControl();
            if (sender != null) if (onOptionsClick != null) onOptionsClick(this, null);
        }
    }
}
