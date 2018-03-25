using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IAboutView : IView
    {
        string Username { get; }

        event Action Save;
    }
}