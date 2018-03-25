using System;
using System.Windows.Forms;
using Presenter.Views;

namespace View
{
    public partial class AboutForm : Form, IAboutView
    {
        public AboutForm()
        {
            InitializeComponent();

            btnSave.Click += (sender, args) => Invoke(Save);
        }

        public new void Show()
        {
            ShowDialog();
        }

        public string Username { get { return txtUsername.Text; } }
        public event Action Save;

        private void Invoke(Action action)
        {
            if (action != null) action();
        }
    }
}
