using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface INameViewEditView : IView
    {
        void SetUserInfo(string username, string password);
        event Action ChangeUsername;
    }
}