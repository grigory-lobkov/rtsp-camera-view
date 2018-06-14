using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IAlertSetupView : IView
    {
        event Action OkClick;
        event Action CancelClick;

        // Email
        event Action EmTestClick;
        bool EmLost { get; set; }
        int EmLostMin { get; set; }
        bool EmRecover { get; set; }
        string EmTo { get; set; }
        string EmFrom { get; set; }
        string EmSerName { get; set; }
        int EmSerPort { get; set; }
        string EmUsername { get; set; }
        string EmPassword { get; set; }

    }
}
