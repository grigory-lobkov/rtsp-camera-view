using System;
using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    public class AboutPresenter : BasePresener<IAboutView, User>
    {
        private User _user;
        
        public AboutPresenter(IApplicationController controller, IAboutView view) : base(controller, view)
        {
            View.Save += () => ChangeUsername(View.Username);
        }

        private void ChangeUsername(string username)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (username != string.Empty)
            {
                _user.Name = username;
                View.Close();
            }
        }

        public override void Run(User argument)
        {
            _user = argument;
            View.Show();
        }
    }
}