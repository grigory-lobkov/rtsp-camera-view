using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IMainView : IView
    {
        string Username { get; }
        string Password { get; }
        event Action Login;
        void ShowError(string errorMessage);
    }
}