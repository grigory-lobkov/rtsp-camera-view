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
        public bool srcNameAutoHide = false;
        public bool SrcNameAutoHide
        {
            get => srcNameAutoHide;
            set { srcNameAutoHide = value; if (srcNameShow && value && srcName.Visible) ShowSrcName(); }
        }

        private bool srcNameShow = false;
        public bool SrcNameShow
        {
            get => srcNameShow;
            set { srcNameShow = value; srcName.Visible = value; }
        }

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
            //topPanel.MouseMove += (sender, args) => Invoke(MouseMoved);
            topPanel.Click += (sender, args) => Invoke(MouseMoved);
            topPanel.DoubleClick += (sender, args) => Invoke(DoubleClicked);
            switchToGoodTimer.Tick += (sender, args) => { switchToGoodTimer.Enabled = false; Invoke(SwitchToGood); };
            switchToBadTimer.Tick += (sender, args) => { switchToBadTimer.Enabled = false; Invoke(SwitchToBad); };
            stopBadTimer.Tick += (sender, args) => { stopBadTimer.Enabled = false; Invoke(StopBadPlayer); };
            stopGoodTimer.Tick += (sender, args) => { stopGoodTimer.Enabled = false; Invoke(StopGoodPlayer); };
            stopOnInvisibleTimer.Tick += (sender, args) => { stopOnInvisibleTimer.Enabled = false; Invoke(StopOnInvisible); };
            this.SizeChanged += (sender, args) => Invoke(SizeChange);
            log.Dock = DockStyle.Right;
            log.BringToFront();
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }
        public event Action MouseMoved;
        public event Action DoubleClicked;
        public event Action SizeChange;

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
            controlPlayer.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) | AnchorStyles.Right)));
            controlPlayer.Visible = false;
            controlPlayer.MouseMove += (sender, args) => Invoke(MouseMoved);
            controlPlayer.BringToFront();
        }
        public void ShowControl()
        {
            if (controlPlayer == null) return;
            controlHideTimer.Enabled = false;
            controlHideTimer.Enabled = true;
            if (!controlPlayer.Visible)
            {
                controlPlayer.Visible = true;
                if (srcNameShow)
                    if (srcNameAutoHide) ShowSrcName();
                    else SrcNameRefresh();
            }
            if (srcNameShow && srcNameAutoHide) ShowSrcName();
        }
        private void HideControl()
        {
            if (controlPlayer == null) return;
            controlPlayer.Visible = false;
            controlHideTimer.Enabled = false;
            if (srcNameShow) if (!srcNameAutoHide) SrcNameRefresh();
        }
        private void ShowSrcName()
        {
            srcName.Visible = true;
            nameHideTimer.Enabled = false;
            nameHideTimer.Enabled = true;
        }
        private void HideSrcName()
        {
            srcName.Visible = false;
            nameHideTimer.Enabled = false;
        }
        public void SrcNameRefresh()
        {
            if (!srcNameShow) { srcName.Visible = false; return; }
            int clientw = ClientSize.Width,
                clienth = ClientSize.Height,
                jointw = MinimumSize.Width,
                jointh = MinimumSize.Height;
            if (Dock == DockStyle.Fill)
            {
                jointw = Math.Max(jointw, 2);
                jointh = Math.Max(jointh, 2);
            }
            int clientm = Math.Min(clientw / jointw, clienth / jointh);
            float fs = Math.Max((float)clientm / 100 * SrcNameSize, 5);
            srcName.Font = new Font(srcName.Font.Name, fs, srcName.Font.Style, srcName.Font.Unit);
            //if (srcNameShow) srcName.Visible = true; else nameHideTimer.Enabled = srcName.Visible;
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
                    top = clienth * 29 / 30 - (int)fs;
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
            controlPlayer.Width = clientw;
        }

        private void SourceControl_Resize(object sender, EventArgs e)
        {
            int clienth = ClientSize.Height / (Dock == DockStyle.Fill ? Math.Max(MinimumSize.Height, 2) : MinimumSize.Height);
            controlPlayer.Height = clienth > 200 ? clienth / 10 : (clienth < 100 ? clienth / 5 : 20);
            SrcNameRefresh();
        }
        public bool Maximized
        {
            get => Dock == DockStyle.Fill;
            set
            {
                Dock = value ? DockStyle.Fill : DockStyle.None;
                SourceControl_Resize(null, null);
                BringToFront();
            }
        }
        public void Log(string str)
        {
            log.Items.Add(str);
            log.Visible = true;
            log.Width = Math.Min(ClientRectangle.Width - 20, 150);
        }

        /*****
         *      Stream switch functions
         */
        public bool SwitchToBadTimerEnabled
        {
            get => switchToBadTimer.Enabled;
            set { if (value) switchToBadTimer.Enabled = false; switchToBadTimer.Enabled = value; }
        }
        public bool SwitchToGoodTimerEnabled
        {
            get => switchToGoodTimer.Enabled;
            set { if (value) switchToGoodTimer.Enabled = false; switchToGoodTimer.Enabled = value; }
        }
        public bool StopBadTimerEnabled
        {
            get => stopBadTimer.Enabled;
            set { if (value) stopBadTimer.Enabled = false; stopBadTimer.Enabled = value; }
        }
        public bool StopGoodTimerEnabled
        {
            get => stopGoodTimer.Enabled;
            set { if (value) stopGoodTimer.Enabled = false; stopGoodTimer.Enabled = value; }
        }
        public bool StopOnInvisibleTimerEnabled
        {
            get => stopOnInvisibleTimer.Enabled;
            set { if (value) stopOnInvisibleTimer.Enabled = false; stopOnInvisibleTimer.Enabled = value; }
        }
        public event Action SwitchToGood;
        public event Action SwitchToBad;
        public event Action StopBadPlayer;
        public event Action StopGoodPlayer;
        public event Action StopOnInvisible;
        public void ShowBadPlayer() { goodPlayer?.SendToBack(); }
        public void ShowGoodPlayer() { badPlayer?.SendToBack(); }

        /*****
         * Drag & Drop methods
         */
        private bool sourceDragging = false;
        public bool SourceDragging { get => sourceDragging; set => sourceDragging = value; }
        public event Action DragDropAccept;
        public event Action DragDropInit;
        public event Action DragDropInitFinish;
        private void TopPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (sourceDragging) e.Effect = DragDropEffects.Copy;
        }
        private void TopPanel_DragDrop(object sender, DragEventArgs e) { Invoke(DragDropAccept); }
        private bool isMouseDown;
        private Point mouseDownLocation;
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = true;
                mouseDownLocation = e.Location;
            }
        }
        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Math.Abs(e.X - mouseDownLocation.X) + Math.Abs(e.Y - mouseDownLocation.Y) > 10)
            {
                if (isMouseDown)
                {
                    Invoke(DragDropInit);
                    DoDragDrop(this, DragDropEffects.Copy | DragDropEffects.Move);
                    Invoke(DragDropInitFinish);
                    isMouseDown = false;
                }
                else Invoke(MouseMoved);
                mouseDownLocation = e.Location;
            }
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
