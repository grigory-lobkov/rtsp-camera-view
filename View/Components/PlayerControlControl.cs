using System;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Views;
using Presenter.Common;

namespace View.Components
{
    public partial class PlayerControlControl : UserControl, IPlayerControlView
    {
        private enum Status { Stopped = 0, Playing = 1, Buffering = 2, Preparing = 3 };

        private Status status;

        public event Action Play;
        public event Action Stop;
        public event Action VolumeUp;
        public event Action VolumeDown;
        public event Action OpenOptions;
        public event Action Maximize;
        public event Action Remove;

        public PlayerControlControl()
        {
            InitializeComponent();
            status = Status.Preparing;
            this.MouseMove += (sender, args) => this.controlPanel_MouseMove();
            controlPanelR.MouseEnter += (sender, args) => this.controlPanel_MouseMove();
            this.Resize += (sender, args) => this.Resized();
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public int ShowSec
        {
            get => hideControlTimer.Interval / 1000;
            set => hideControlTimer.Interval = value * 1000;
        }

        public void SourceReset()
        {
            this.Buffering();
            status = Status.Preparing;
            btnPlayStop.BackgroundImage = btnPlayStop.Tag == null ? 
                RtspCameraView.Properties.Resources.btn_eject : 
                InvertImage(RtspCameraView.Properties.Resources.btn_eject);
            controlPanelR.Visible = false;
            btnVolMinus.Visible = btnVolPlus.Visible = false;
        }
        public void SourceSet()
        {
            btnPlayStop.BackgroundImage = btnPlayStop.Tag == null ? 
                RtspCameraView.Properties.Resources.btn_play : 
                InvertImage(RtspCameraView.Properties.Resources.btn_play);
            controlPanelR.Visible = true;
        }

        private void Resized()
        {
            int clientw = this.ClientSize.Width,
                clienth = this.ClientSize.Height,
                clientm = Math.Min(clientw, clienth);
            int bh = clientm * 4 / 5, bm = bh / 7, bh2 = clientm / 21, bm2 = bm * 2;
            Size bS = new Size(bh, bh), bS2 = new Size(bh2, bh2);
            int bs = bh + bm, bs2 = bh2 + bm;

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
        }

        public void Buffering()
        {
            btnPlayStop.BackgroundImage = btnPlayStop.Tag == null ? 
                RtspCameraView.Properties.Resources.btn_wait : 
                InvertImage(RtspCameraView.Properties.Resources.btn_wait);
            status = Status.Buffering;
        }
        public void Stopped()
        {
            btnPlayStop.BackgroundImage = btnPlayStop.Tag == null ? 
                RtspCameraView.Properties.Resources.btn_play : 
                InvertImage(RtspCameraView.Properties.Resources.btn_play);
            status = Status.Stopped;
        }
        public void Playing()
        {
            btnPlayStop.BackgroundImage = btnPlayStop.Tag == null ? 
                RtspCameraView.Properties.Resources.btn_stop : 
                InvertImage(RtspCameraView.Properties.Resources.btn_stop);
            status = Status.Playing;
        }

        public void SoundFound()
        {
            btnVolMinus.Visible = btnVolPlus.Visible = true;
            ShowMe();
        }
        /*
        public void bgvlc_BeforeRtspSwitch(object sender)
        {
            hideControlTimer_Tick(hideControlTimer, null);
        }*/

        public void ShowMe()
        {
            Visible = true;
            hideControlTimer.Enabled = false;
            hideControlTimer.Enabled = true;
        }

        private void hideControlTimer_Tick(object sender, EventArgs e)
        {
            hideControlTimer.Enabled = false;
            Visible = false;
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
            s.Tag = s.Tag != null ? null : sender;
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
            ShowMe();
            if (status == Status.Playing) { Invoke(Stop); Buffering(); }
            else if (status == Status.Stopped) { Invoke(Play); Buffering(); }
        }

        private void btnVolMinus_Click(object sender, EventArgs e)
        {
            Invoke(VolumeDown);
            ShowMe();
        }

        private void btnVolPlus_Click(object sender, EventArgs e)
        {
            Invoke(VolumeUp);
            ShowMe();
        }

        private void controlPanel_MouseMove()
        {
            ShowMe();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ShowMe();
            Invoke(Remove);
        }

        private void btnMaxMin_Click(object sender, EventArgs e)
        {
            ShowMe();
            Invoke(Maximize);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            ShowMe();
            Invoke(OpenOptions);
        }
    }
}
