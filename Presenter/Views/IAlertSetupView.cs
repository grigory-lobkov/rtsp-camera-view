using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IAlertSetupView : IView
    {
        event Action OkClick;
        event Action CancelClick;

        void ShowError(string errorMessage);

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

        // Localization
        string ThisText { set; }
        string EmailPageText { set; }
        string EmLostCheckBoxText { set; }
        string EmRecoverCheckBoxText { set; }
        string EmToLabelText { set; }
        string EmFromLabelText { set; }
        string EmServerGroupBoxText { set; }
        string EmNameLabelText { set; }
        string EmPortLabelText { set; }
        string EmTestLinkLabelText { set; }
        string EmUsernameLabelText { set; }
        string EmPasswordLabelText { set; }
        string OkButtonText { set; }
        string CancelButtonText { set; }

    }
}
