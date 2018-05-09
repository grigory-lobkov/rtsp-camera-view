using System;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Common;
using Presenter.Views;
//using System.Runtime.InteropServices;//for DllImport

namespace View
{
    public partial class MainForm : Form, IMainView
    {
        private const string OpenLabelTextConst = ">>";
        private const string CloseLabelTextConst = "<<";
        private const string VlcDownloadPage = "http://download.videolan.org/pub/videolan/vlc/2.1.5/win32/";
        private readonly ApplicationContext _context;
        /*
        internal enum SWP
        {
            ASYNCWINDOWPOS = 0x4000,
            DEFERERASE = 0x2000,
            DRAWFRAME = 0x0020,
            FRAMECHANGED = 0x0020,
            HIDEWINDOW = 0x0080,
            NOACTIVATE = 0x0010,
            NOCOPYBITS = 0x0100,
            NOMOVE = 0x0002,
            NOOWNERZORDER = 0x0200,
            NOREDRAW = 0x0008,
            NOREPOSITION = 0x0200,
            NOSENDCHANGING = 0x0400,
            NOSIZE = 0x0001,
            NOZORDER = 0x0004,
            SHOWWINDOW = 0x0040,
        }
        [DllImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
        private static extern bool _SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SWP uFlags);
        */
        public MainForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();

            splitLabel.Click += (sender, args) => Invoke(OpenClosePanelClick);
            splitLabel.MouseEnter += (sender, args) => RepaintSplitLabel(true);
            splitLabel.MouseLeave += (sender, args) => RepaintSplitLabel();
            ResizeEnd += (sender, args) => RepaintControlPanel();
            Shown += (sender, args) => RepaintControlPanel();
            splitter.SplitterMoved += (sender, args) => RepaintControlPanel();
            splitter.SplitterMoved += (sender, args) => Invoke(SplitterMoved);
            fullScreenMenuItem.Click += (sender, args) => DoFullscreen();
            exitFullScreenMenuItem.Click += (sender, args) => ExitFullscreen();
            exitFullScreenMenuItem.Visible = false;
        }

        public new void Show()
        {
            _context.MainForm = this;
            controlPanel.Visible = false;
            splitter.Visible = false;
            controlPanel.SelectedTab = sourcesPage;
            Application.Run(_context);
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, Application.ProductName,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public event Action OpenClosePanelClick;

        /*private void OpenClosePanel()
        {
            Invoke(OpenClosePanelClick);
        }*/

        public bool PanelState
        {
            get
            {
                return controlPanel.Visible;
            }
            set
            {
                if(value) // on show panel
                {
                    controlPanel.SelectedTab = sourcesPage; // to show EditForm of Source, when on camera "settings" pressed
                }
                controlPanel.Visible = value;
                splitter.Visible = value;
                if (value) ControlPanel_SelectedIndexChanged(null, null);
                RepaintControlPanel();
                splitLabel.Text = value ? CloseLabelTextConst : OpenLabelTextConst;
            }
        }

        public event Action SplitterMoved;

        public int CtrlPanelWidth
        {
            get
            {
                return controlPanel.Width;
            }
            set
            {
                controlPanel.Width = value;
                RepaintControlPanel();
            }
        }

        private void RepaintControlPanel()
        {
            int s = Math.Min(Math.Max(controlPanel.Width / 30, 6), 18);
            splitLabel.Font = new System.Drawing.Font(splitLabel.Font.Name, s, splitLabel.Font.Style, splitLabel.Font.Unit);
            splitLabel.Width = s + 4;
            splitLabel.Height = s * 5;
            splitLabel.Top = (this.ClientRectangle.Height - splitLabel.Height) / 2;
            splitter.Width = s / 2;
            RepaintSplitLabel();
        }

        private void RepaintSplitLabel(bool hover = false)
        {
            splitLabel.Left = (controlPanel.Visible ? controlPanel.Width : -splitter.Width)
                + (hover ? splitter.Width : 0);
        }

        public void SetSourceListControl(IViewControl control)
        {
            Control c = (Control)control;
            sourcesPage.Controls.Add(c);
            c.Dock = DockStyle.Fill;
        }
        public void SetSettingsControl(IViewControl control)
        {
            Control c = (Control)control;
            settingsPage.Controls.Add(c);
            c.Dock = DockStyle.Fill;
        }
        public void SetGridControl(IViewControl control)
        {
            Control c = (Control)control;
            this.Controls.Add(c);
            c.Dock = DockStyle.Fill;
            c.BringToFront();
            c.ContextMenuStrip = gridMenu;
            splitLabel.BringToFront();
        }

        public event Action SourcesPageSelected;
        public event Action SettingsPageSelected;

        private void ControlPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (controlPanel.SelectedTab == sourcesPage)
            {
                Invoke(SourcesPageSelected);
            }
            else if (controlPanel.SelectedTab == settingsPage)
            {
                Invoke(SettingsPageSelected);
            }
        }

        private FormBorderStyle saveBorderStyle;
        private FormWindowState saveWindowState;
        public void DoFullscreen()
        {
            saveBorderStyle = this.FormBorderStyle;
            saveWindowState = this.WindowState;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            fullScreenMenuItem.Visible = false;
            exitFullScreenMenuItem.Visible = true;
        }
        public void ExitFullscreen()
        {
            this.FormBorderStyle = saveBorderStyle;
            this.WindowState = saveWindowState;
            fullScreenMenuItem.Visible = true;
            exitFullScreenMenuItem.Visible = false;
        }
        public void DoAlwaysOnTop()
        {
            this.TopMost = true;
        }
        public void ExitAlwaysOnTop()
        {
            this.TopMost = false;
        }

        public void MoveToScreen(int screen)
        {
            Screen[] sc = Screen.AllScreens;
            if (screen > -1 && sc.Length > screen)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(sc[screen].Bounds.X, sc[screen].Bounds.Y);
                this.Size = new Size(sc[screen].Bounds.Width, sc[screen].Bounds.Height);
                /*
                IntPtr h1 = this.Handle;
                Point screenlocation = Screen.AllScreens[1].Bounds.Location;
                _SetWindowPos(h1, IntPtr.Zero, screenlocation.X, screenlocation.Y, Screen.AllScreens[1].Bounds.Width, Screen.AllScreens[1].Bounds.Height, 0);// SWP_NOZORDER | SWP_SHOWWINDOW);
                */
            }
        }
        public void Maximize()
        {
            this.WindowState = FormWindowState.Maximized;
        }
        public void SetPriority(int priority)
        {
            if (priority < 0 || priority > 4) return;
            System.Diagnostics.ProcessPriorityClass c = System.Diagnostics.ProcessPriorityClass.Normal;
            switch (priority)
            {
                case 0: c = System.Diagnostics.ProcessPriorityClass.Idle; break;
                case 1: c = System.Diagnostics.ProcessPriorityClass.BelowNormal; break;
                case 2: c = System.Diagnostics.ProcessPriorityClass.Normal; break;
                case 3: c = System.Diagnostics.ProcessPriorityClass.AboveNormal; break;
                case 4: c = System.Diagnostics.ProcessPriorityClass.High; break;
            }
            System.Diagnostics.Process.GetCurrentProcess().PriorityClass = c;
        }
        public void SetAppCaption()
        {
            this.Text = Application.ProductName + " " + Application.ProductVersion
                + "  /  gg81@yandex.ru  /  "
                + (Application.CurrentCulture.TwoLetterISOLanguageName == "ru" ? "Григорий Лобков" : "Gregory Lobkov");
        }

        public void ErrorAccessSettings(string msg)
        {
            MessageBox.Show(SettingsAccesError.Text + "\n\n" + msg,
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ErrorOnLoadSettings(string msg)
        {
            MessageBox.Show(SettingsLoadError.Text + "\n\n" + msg,
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ErrorOnSaveSettings(string msg)
        {
            MessageBox.Show(SettingsSaveError.Text + "\n\n" + msg,
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void ErrorOnCreateGridNoLib(string msg)
        {
            DialogResult a = MessageBox.Show(CreateGridCommonError.Text + "\n" + CreateGridNoLibError.Text +
                "\n\n" + msg + "\n\n" + CreateGridEndError.Text.Replace("{url}", VlcDownloadPage),
                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (a == DialogResult.Yes) System.Diagnostics.Process.Start(VlcDownloadPage);
            Environment.Exit(101);
        }
        public void ErrorOnCreateGridBadVer(string msg)
        {
            DialogResult a = MessageBox.Show(CreateGridCommonError.Text + "\n" + CreateGridBadVerError.Text +
                "\n\n" + msg + "\n\n" + CreateGridEndError.Text.Replace("{url}", VlcDownloadPage),
                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (a == DialogResult.Yes) System.Diagnostics.Process.Start(VlcDownloadPage);
            Environment.Exit(101);
        }
        public void ErrorOnCreateGridOther(string msg)
        {
            DialogResult a = MessageBox.Show(
                msg + "\n\n" + CreateGridEndError.Text.Replace("{url}", VlcDownloadPage),
                Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (a == DialogResult.Yes) System.Diagnostics.Process.Start(VlcDownloadPage);
            Environment.Exit(101);
        }

        public event Action ShowHintTimer;
        public event Action HideHintTimer;
        public bool HintShowTimer
        {
            get => showHintTimer.Enabled;
            set { if(value) showHintTimer.Enabled = false; showHintTimer.Enabled = value; }
        }
        public bool HintOpenCtrlShow
        {
            get => hintOpenCtrl.Visible;
            set
            {
                if (value)
                {
                    hintOpenCtrl.Location = new Point(splitLabel.Location.X + splitLabel.Width + 4, splitLabel.Location.Y + 3);
                    splitLabel.BackColor = Color.Red;
                    hintOpenCtrl.BringToFront();
                }
                else splitLabel.BackColor = SystemColors.ControlDark;
                hintOpenCtrl.Visible = value;
            }
        }
        public bool HintAddCameraShow
        {
            get => hintAddCamera.Visible;
            set
            {
                if (value)
                {
                    hintAddCamera.Location = new Point(sourcesPage.Location.X + 15, sourcesPage.Location.Y + 15);
                    hintAddCamera.BringToFront();
                }
                hintAddCamera.Visible = value;
            }
        }
        public bool HintDropCameraShow
        {
            get => hintDropCamera.Visible;
            set
            {
                if (value)
                {
                    hintDropCamera.Location = new Point(controlPanel.Width + 40, 30);
                    hintDropCamera.BringToFront();
                }
                hintDropCamera.Visible = value;
            }
        }
        public bool HintNewRtspBadShow
        {
            get => hintRTSP1.Visible;
            set
            {
                if (value)
                {
                    hintRTSP1.Location = new Point(controlPanel.Width + 10, 138);
                    hintRTSP1.BringToFront();
                }
                hintRTSP1.Visible = value;
            }
        }
        public bool HintNewRtspGoodShow
        {
            get => hintRTSP2.Visible;
            set
            {
                if (value)
                {
                    hintRTSP2.Location = new Point(controlPanel.Width + 10, 227);
                    hintRTSP2.BringToFront();
                }
                hintRTSP2.Visible = value;
            }
        }

        private void ShowHintTimer_Tick(object sender, EventArgs e)
        {
            showHintTimer.Enabled = false;
            Invoke(ShowHintTimer);
        }

        private void HideHintTimer_Tick(object sender, EventArgs e)
        {
            hideHintTimer.Enabled = false;
            Invoke(HideHintTimer);
        }
    }
}