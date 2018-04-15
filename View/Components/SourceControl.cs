using System;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Views;
using Presenter.Common;

namespace View.Components
{
    public partial class SourceControl : UserControl, ISourceView
    {
        private enum Align { TopLeft = 1, TopCenter = 2, TopRight = 3, MiddleLeft = 4, MiddleCenter = 5, MiddleRight = 6, BottomLeft = 7, BottomCenter = 8, BottomRight = 9 };
        private UserControl badPlayer = null;
        private UserControl goodPlayer = null;
        private UserControl controlPlayer = null;
        public int ControlShowSec
        {
            get => controlHideTimer.Interval / 1000;
            set => controlHideTimer.Interval = value * 1000;
        }
        public bool HidePlayer { get => hidePlayerPanel.Visible; set => hidePlayerPanel.Visible = value; }

        public string SrcName { get => srcName.Text; set => srcName.Text = value; }
        private Align srcNameAlign;
        public int SrcNameAlign { get => (int)srcNameAlign; set => srcNameAlign = (Align)value; }
        public int SrcNameShowSec
        {
            get => nameHideTimer.Interval / 1000;
            set => nameHideTimer.Interval = value * 1000;
        }
        public bool srcNameAutoHide = true;
        public bool SrcNameAutoHide { get => srcNameAutoHide; set => srcNameAutoHide = value; }
        private bool srcNameShow = true;
        public bool SrcNameShow { get => srcNameShow; set => srcNameShow = value; }
        private int srcNameSize = 3;
        public int SrcNameSize { get => srcNameSize; set => srcNameSize = value; }
        public Color SrcNameColor { get => srcName.ForeColor; set => srcName.ForeColor = value; }
        private bool srcNameBg = true;
        public bool SrcNameBg
        {
            get => srcNameBg;
            set { srcNameBg = value; srcName.BackColor = srcNameBg ? srcNameBgColor : Color.Transparent; }
        }
        public Color srcNameBgColor = Color.Black;
        public Color SrcNameBgColor
        {
            get => srcNameBgColor;
            set { srcNameBgColor = value; srcName.BackColor = srcNameBg ? srcNameBgColor : Color.Transparent; }
        }

        public SourceControl()
        {
            InitializeComponent();
            srcName.SendToBack();
            srcName.Text = "";
            hidePlayerPanel.SendToBack();
            controlHideTimer.Tick += (sender, args) => HideControl();
            nameHideTimer.Tick += (sender, args) => HideSrcName();
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public void SetBadPlayerControl(IViewControl control)
        {
            badPlayer = (UserControl)control;
            this.Controls.Add(badPlayer);
            badPlayer.Dock = DockStyle.Fill;
            badPlayer.SendToBack();
            if (goodPlayer != null) goodPlayer.SendToBack();
        }
        public void SetGoodPlayerControl(IViewControl control)
        {
            goodPlayer = (UserControl)control;
            this.Controls.Add(goodPlayer);
            goodPlayer.Dock = DockStyle.Fill;
            goodPlayer.SendToBack();
        }
        public void SetPlayerControlControl(IViewControl control)
        {
            controlPlayer = (UserControl)control;
            this.Controls.Add(controlPlayer);
            controlPlayer.Dock = DockStyle.Bottom;
            controlPlayer.Visible = false;
        }
        public void ShowControl()
        {
            if (controlPlayer == null) return;
            controlPlayer.Visible = true;
            controlHideTimer.Enabled = false;
            controlHideTimer.Enabled = true;
            if (!srcNameAutoHide) SrcNameRefresh(); else
            { 
                srcName.Visible = true;
            }
        }
        private void HideControl()
        {
            if (controlPlayer == null) return;
            controlPlayer.Visible = false;
            controlHideTimer.Enabled = false;
            if (!srcNameAutoHide) SrcNameRefresh();
        }
        private void ShowSrcName()
        {
            srcName.Visible = true;
            nameHideTimer.Enabled = false;
            nameHideTimer.Enabled = true;
        }
        private void HideSrcName()
        {
            if(!srcNameShow) srcName.Visible = false;
            nameHideTimer.Enabled = false;
        }
        public void SrcNameRefresh()
        {
            int clientw = ClientSize.Width,
                clienth = ClientSize.Height,
                clientm = Math.Min(clientw, clienth),
                fs = Math.Max(clientm / 100 * SrcNameSize, 4);
            srcName.Font = new Font(srcName.Font.Name, fs, srcName.Font.Style, srcName.Font.Unit);
            if (srcNameShow) srcName.Visible = true; else nameHideTimer.Enabled = srcName.Visible;
            srcName.Refresh();
            int top, left;
            switch (srcNameAlign)
            {
                case Align.TopLeft:
                case Align.TopCenter:
                case Align.TopRight:
                    top = clienth / 40;
                    break;
                default: // bottom
                    top = clienth * 11 / 12;
                    if (controlPlayer != null)
                        if (srcNameAutoHide || controlPlayer.Visible)
                            top = top - controlPlayer.Height;
                    break;
            };
            switch (srcNameAlign)
            {
                case Align.TopLeft:
                case Align.BottomLeft:
                    left = clientw / 40;
                    break;
                case Align.TopCenter:
                case Align.BottomCenter:
                    left = (clientw - srcName.Width) / 2;
                    break;
                default: // right
                    left = clientw * 39 / 40 - srcName.Width;
                    break;
            };
            srcName.Location = new Point(left, top);
        }

        private void SourceControl_Resize(object sender, EventArgs e)
        {
            SrcNameRefresh();
            int clienth = ClientSize.Height;
            controlPlayer.Height = clienth > 200 ? clienth / 10 : (clienth < 100 ? clienth / 5 : 20);
        }
    }
    public class TopPanel : Panel
    {
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
    }
}
