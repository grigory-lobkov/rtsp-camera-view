using System;
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
            if (action != null) action();
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
                if (value) controlPanel_SelectedIndexChanged(null, null);
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

        public void SetSourceListControl(IViewControl control) {
            var c = (UserControl)control;
            sourcesPage.Controls.Add(c);
            c.Dock = DockStyle.Fill;
        }
        public void SetSettingsControl(IViewControl control)
        {
            var c = (UserControl)control;
            settingsPage.Controls.Add(c);
            c.Dock = DockStyle.Fill;
        }

        public event Action SourcesPageSelected;
        public event Action SettingsPageSelected;

        private void controlPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(controlPanel.SelectedTab == sourcesPage)
            {
                Invoke(SourcesPageSelected);
            }
            else if (controlPanel.SelectedTab == settingsPage)
            {
                Invoke(SettingsPageSelected);
            }
        }
    }
}
