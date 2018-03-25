using System;
using Model;
using Model.Rtsp;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    public class MainPresenter : BasePresener<IMainView>
    {
        private readonly IRtspService _service;

        public MainPresenter(IApplicationController controller, IMainView view, IRtspService service)
            : base(controller, view)
        {
            _service = service;
            
            View.Login += () => Login(View.Username, View.Password);
        }

        private void Login(string username, string password)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (password == null)
                throw new ArgumentNullException("password");

            var user = new User {Name = username, Password = password};
            if (!_service.Login(user))
            {
                View.ShowError("Invalid username or password");
            }
            else
            {
                Controller.Run<NameViewEditPresener, User>(user);
                View.Close();
            }
        }
    }
}