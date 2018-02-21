using System;
using System.Drawing;
using System.Windows.Forms;

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
        public Camera camera;
        //private Graphics gfx;

        public RtspBadGoodControl()
        {
            InitializeComponent();
            //gfx = this.CreateGraphics();
        }

        public void resizeEnd(object sender) { sizeChangedTimer_Tick(sizeChangedTimer, null); }
        private void bgvlc_MouseEnter(Object sender, EventArgs e) { showControl(); this.OnMouseEnter(e); }
        private void bgvlc_MouseDoubleClick(Object sender, MouseEventArgs e) {
            this.OnMouseDoubleClick(e);
            if (this.Dock == DockStyle.Fill) btnMaxMin.BackgroundImage = Convert.ToInt32(btnMaxMin.Tag) == 0 ? Properties.Resources.btn_minimize : InvertImage(Properties.Resources.btn_minimize);
            else btnMaxMin.BackgroundImage = Convert.ToInt32(btnMaxMin.Tag) == 0 ? Properties.Resources.btn_maximize : InvertImage(Properties.Resources.btn_maximize);
        }
        private void bgvlc_DragEnter(Object sender, DragEventArgs e) { showControl(); this.OnDragEnter(e); }
        private void bgvlc_DragDrop(Object sender, DragEventArgs e) { showControl(); this.OnDragDrop(e); }
        public void resetCamera()
        {
            this.stop(this);
            this.RtspBad = "";
            this.RtspGood = "";
            this.Title = "";
            this.AspectRatio = Properties.Resources.defaultAspectRatio;
            this.isCameraSet = false;
            this.camera = null;
            btnPlayStop.BackgroundImage = Convert.ToInt32(btnPlayStop.Tag) == 0 ? Properties.Resources.btn_eject : InvertImage(Properties.Resources.btn_eject);
            controlPanelR.Visible = false;
            btnVolMinus.Visible = false;
            btnVolPlus.Visible = false;
        }
        public void setCamera(Camera c)
        {
            if (c.rtspBad == null || c.rtspBad == "") return;
            this.RtspBad = c.rtspBad;
            this.RtspGood = c.rtspGood;
            this.Title = c.name;
            this.AspectRatio = c.aspectRatio;
            this.isCameraSet = true;
            this.camera = c;
            btnPlayStop.BackgroundImage = Convert.ToInt32(btnPlayStop.Tag) == 0 ? Properties.Resources.btn_play : InvertImage(Properties.Resources.btn_play);
            controlPanelR.Visible = true;
        }

        private void sizeChangedTimer_Tick(object sender, EventArgs e)
        {
            (sender as Timer).Enabled = false;
            int clientw = this.ClientSize.Width,
                clienth = this.ClientSize.Height,
                clientm = Math.Min(clientw, clienth);
            int bh = Math.Max(clientm / 14, 14), bm = bh / 7, bh2 = Math.Max(clientm / 21, 10), bm2 = bm * 2;
            Size bS = new Size(bh, bh), bS2 = new Size(bh2, bh2);
            int bs = bh + bm, bs2 = bh2 + bm;

            nameLabel.Font = new Font(nameLabel.Font.Name, bh / 3, nameLabel.Font.Style, nameLabel.Font.Unit);
            nameLabel.Location = new Point(clientw / 2 - nameLabel.Width / 2, clienth / 10 - bh / 2);
            controlPanel.Location = new Point(0, clienth - bs - bm);
            controlPanel.Size = new Size(clientw, bs + bm);
            bgvlc.Location = new Point(0, 0);
            bgvlc.Size = this.ClientSize;
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
            nameLabel.Visible = true;
            controlPanel.Visible = true;
            hideControlTimer.Enabled = false;
            hideControlTimer.Enabled = true;
        }

        private void hideControlTimer_Tick(object sender, EventArgs e)
        {
            hideControlTimer.Enabled = false;
            nameLabel.Visible = false;
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
            if (bgvlc.Status == VlcStatus.Playing) this.stop(btnPlayStop);
            else if (bgvlc.Status == VlcStatus.Stopped) this.play(btnPlayStop);
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
            resetCamera();
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
