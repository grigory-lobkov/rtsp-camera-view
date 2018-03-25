using System;
using System.Windows.Forms;
using Presenter.Views;

namespace View
{
    public partial class NameViewEditForm : Form, INameViewEditView
    {
        private readonly ApplicationContext _context;
        public NameViewEditForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();

            btnChangeUsername.Click += (sender, args) => Invoke(ChangeUsername);
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }

        public void SetUserInfo(string username, string password)
        {
            lblUsername.Text = username;
            lblPassword.Text = password;
        }

        public event Action ChangeUsername;

        private void Invoke(Action action)
        {
            if (action != null) action();
        }
    }
}
