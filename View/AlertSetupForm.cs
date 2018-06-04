using System;
using System.Windows.Forms;
using Presenter.Views;

namespace View
{
    public partial class AlertSetupForm : Form, IAlertSetupView
    {
        public event Action OkClick;
        public event Action CancelClick;

        public AlertSetupForm()
        {
            InitializeComponent();
            okButton.Click += (sender, args) => Invoke(OkClick);
            cancelButton.Click += (sender, args) => Invoke(CancelClick);
            emTestLinkLabel.LinkClicked += (sender, args) => Invoke(EmTestClick);
        }

        public new void Show()
        {
            ShowDialog();
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        private void NumberInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    try
                    {
                        int v = Convert.ToInt32(((TextBox)sender).Text);
                        if (v < 65536) ((TextBox)sender).Text = (v + 1).ToString();
                    }
                    catch (Exception) { }
                    break;
                case Keys.Down:
                    try
                    {
                        int v = Convert.ToInt32(((TextBox)sender).Text);
                        if (v > 1) ((TextBox)sender).Text = (v - 1).ToString();
                        if (v > 65536) ((TextBox)sender).Text = "65536";
                    }
                    catch (Exception) { }
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }
        private void NumberInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }
        }


        /***
         * Email tab
         */

        public event Action EmTestClick;
        public bool EmLost { get => emLostCheckBox.Checked; set => emLostCheckBox.Checked = value; }
        public int EmLostMin { get => Convert.ToInt32(emLostMinTextBox.Text); set => emLostMinTextBox.Text = value.ToString(); }
        public bool EmRecover { get => emRecoverCheckBox.Checked; set => emRecoverCheckBox.Checked = value; }
        public string EmTo { get => emToTextBox.Text; set => emToTextBox.Text = value; }
        public string EmFrom { get => emFromTextBox.Text; set => emFromTextBox.Text = value; }
        public string EmSerName { get => emNameTextBox.Text; set => emNameTextBox.Text = value; }
        public int EmSerPort { get => Convert.ToInt32(emPortTextBox.Text); set => emPortTextBox.Text = value.ToString(); }
        public int EmConnProt { get => emConnProtComboBox.SelectedIndex; set => emConnProtComboBox.SelectedIndex = value; }
        public int EmAuthMethod { get => emAuthMethodComboBox.SelectedIndex; set => emAuthMethodComboBox.SelectedIndex = value; }
        public string EmUsername { get => emUsernameTextBox.Text; set => emUsernameTextBox.Text = value; }
        public string EmPassword { get => emPasswordTextBox.Text; set => emPasswordTextBox.Text = value; }

    }
}
