using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    public class NameViewEditPresener : BasePresener<INameViewEditView, User>
    {
        private User _user;
        
        public NameViewEditPresener(IApplicationController controller, INameViewEditView view) : base(controller, view)
        {
            View.ChangeUsername += ChangeUsername;
        }

        public override void Run(User argument)
        {
            _user = argument;
            UpdateUserInfo();
            View.Show();
        }

        private void ChangeUsername()
        {
            Controller.Run<AboutPresenter, User>(_user);
            UpdateUserInfo();
        }

        private void UpdateUserInfo()
        {
            View.SetUserInfo(_user.Name, new string('*', _user.Password.Length));
        }
    }
}