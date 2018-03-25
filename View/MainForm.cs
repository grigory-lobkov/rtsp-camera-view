using System;
using System.Windows.Forms;
using Presenter.Views;

namespace View
{
    public partial class MainForm : Form, IMainView
    {
        private readonly ApplicationContext _context;
        public MainForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();

            btnLogin.Click += (sender, args) => Invoke(Login);
        }

        public new void Show()
        {
            _context.MainForm = this;
            Application.Run(_context);
        }

        public string Username { get { return txtUsername.Text; } }
        public string Password { get { return txtPassword.Text; } }
        public event Action Login;
        
        public void ShowError(string errorMessage)
        {
            lblError.Text = errorMessage;
        }

        private void Invoke(Action action)
        {
            if (action != null) action();
        }
    }
}
