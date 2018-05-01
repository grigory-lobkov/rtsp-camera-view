using System;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Common;
using Presenter.Views;

namespace View
{
    public partial class MainForm : Form, IMainView
    {
        private const string OpenLabelTextConst = ">>";
        private const string CloseLabelTextConst = "<<";
        private readonly ApplicationContext _context;
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
                this.Location = new Point(sc[screen].Bounds.Location.X, sc[screen].Bounds.Location.Y);
                this.Size = new Size(sc[screen].Bounds.Width, sc[screen].Bounds.Height);
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
                + (Application.CurrentCulture.TwoLetterISOLanguageName == "ru" ? "решениеготово.рф  /  Григорий Лобков" : "Gregory Lobkov");
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
    }
}
