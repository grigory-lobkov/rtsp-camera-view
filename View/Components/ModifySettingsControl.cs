using System;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Views;

namespace View.Components
{
    public partial class ModifySettingsControl : UserControl, IModifySettingsView
    {
        int _matrixMaxX = 8;
        int _matrixMaxY = 8;
        int _lastX;
        int _lastY;

        public ModifySettingsControl()
        {
            InitializeComponent();
            commandLineHelpButton.Click += (sender, args) => Invoke(CommandLineHelpClick);
            githubLinkLabel.Click += (sender, args) => Invoke(GitHubSiteClick);
            camNameViewGlbButton.Click += (sender, args) => Invoke(ModifyNameViewClick);
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public int MatrixMaxX {
            set { _matrixMaxX = value; }
        }

        public int MatrixMaxY {
            set { _matrixMaxY = value; }
        }

        public int MatrixX {
            get { return Convert.ToInt32(matrixXinput.Text); }
            set { matrixXinput.Text = value.ToString(); _lastX = value; }
        }

        public int MatrixY {
            get { return Convert.ToInt32(matrixYinput.Text); }
            set { matrixYinput.Text = value.ToString(); _lastY = value; }
        }

        public event Action ApplyMatrixSizeClick;

        public event Action CommandLineHelpClick;

        public void ShowCommandLineHelp()
        {
            MessageBox.Show(commandLineHelp.Text, commandLineHelpButton.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public event Action GitHubSiteClick;

        public void OpenGitHubSite()
        {
            System.Diagnostics.Process.Start("https://github.com/grigory-lobkov/rtsp-camera-view");
            githubLinkLabel.LinkVisited = true;
        }

        public event Action ModifyNameViewClick;

        private void applyMatrixSize_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }

        private void applyMatrixSize_MouseLeave(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = SystemColors.ControlText;
        }

        private void matrixInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    try
                    {
                        int v = Convert.ToInt32(((TextBox)sender).Text);
                        if (sender == matrixXinput && v < _matrixMaxX
                            || sender == matrixYinput && v < _matrixMaxY)
                        {
                            ((TextBox)sender).Text = (v + 1).ToString();
                        }
                    }
                    catch (Exception) { }
                    break;
                case Keys.Down:
                    try
                    {
                        int v = Convert.ToInt32(((TextBox)sender).Text);
                        if (v > 1) ((TextBox)sender).Text = (v - 1).ToString();
                        if (sender == matrixXinput)
                        {
                            if (v > _matrixMaxX) ((TextBox)sender).Text = _matrixMaxX.ToString();
                        }
                        else if (v > _matrixMaxY) ((TextBox)sender).Text = _matrixMaxY.ToString();
                    }
                    catch (Exception) { }
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }

        private void matrixInput_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(matrixXinput.Text);
                int y = Convert.ToInt32(matrixYinput.Text);
                applyMatrixSize.Visible = (x > 0 && y > 0 && (x != _lastX || y != _lastY)
                     && x <= _matrixMaxX && y <= _matrixMaxY);
            }
            catch
            {
                applyMatrixSize.Visible = false;
            }
        }

        private void matrixInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }
        }

        private void applyMatrixSize_Click(object sender, EventArgs e)
        {
            applyMatrixSize.Visible = false;
            Invoke(ApplyMatrixSizeClick);
            _lastX = Convert.ToInt32(matrixXinput.Text);
            _lastY = Convert.ToInt32(matrixYinput.Text);
        }
    }
}
