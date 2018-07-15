using System;
using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    public class AlertSetupPresenter : BasePresener<IAlertSetupView, Alert>
    {
        private Alert _alert;
        private IEmailAlertService _eMalertService;

        public AlertSetupPresenter(IApplicationController controller, IAlertSetupView view, IEmailAlertService eMalertService) : base(controller, view)
        {
            // View localization
            View.ThisText = Locale.Instance.Get("AlertSetup/this");
            View.EmailPageText = Locale.Instance.Get("AlertSetup/emailPageText");
            View.EmLostCheckBoxText = Locale.Instance.Get("AlertSetup/emLostCheckBoxText");
            View.EmRecoverCheckBoxText = Locale.Instance.Get("AlertSetup/emRecoverCheckBoxText");
            View.EmToLabelText = Locale.Instance.Get("AlertSetup/emToLabelText");
            View.EmFromLabelText = Locale.Instance.Get("AlertSetup/emFromLabelText");
            View.EmServerGroupBoxText = Locale.Instance.Get("AlertSetup/emServerGroupBoxText");
            View.EmNameLabelText = Locale.Instance.Get("AlertSetup/emNameLabelText");
            View.EmPortLabelText = Locale.Instance.Get("AlertSetup/emPortLabelText");
            View.EmTestLinkLabelText = Locale.Instance.Get("AlertSetup/emTestLinkLabelText");
            View.EmUsernameLabelText = Locale.Instance.Get("AlertSetup/emUsernameLabelText");
            View.EmPasswordLabelText = Locale.Instance.Get("AlertSetup/emPasswordLabelText");
            View.OkButtonText = Locale.Instance.Get("AlertSetup/okButtonText");
            View.CancelButtonText = Locale.Instance.Get("AlertSetup/cancelButtonText");

            // View actions
            View.OkClick += OkClick;
            View.CancelClick += CancelClick;
            View.EmTestClick += TestClick;
            _eMalertService = eMalertService;
        }

        public override void Run(Alert alert)
        {
            _alert = alert;
            ViewRefresh();
            _eMalertService.SetSettings(alert);
            View.Show();
        }

        private void ViewRefresh()
        {
            View.EmFrom = _alert.email.emailFrom;
            View.EmLost = _alert.email.onSignalLost;
            View.EmLostMin = _alert.email.whenDissapearMin;
            View.EmPassword = _alert.email.authPassword;
            View.EmRecover = _alert.email.onSignalRecover;
            View.EmSerName = _alert.email.serverUrl;
            View.EmSerPort = _alert.email.serverPort;
            View.EmTo = _alert.email.emailTo;
            View.EmUsername = _alert.email.authUser;
        }

        private void OkClick()
        {
            _alert.email.emailFrom = View.EmFrom;
            _alert.email.onSignalLost = View.EmLost;
            _alert.email.whenDissapearMin = View.EmLostMin;
            _alert.email.authPassword = View.EmPassword;
            _alert.email.onSignalRecover = View.EmRecover;
            _alert.email.serverUrl = View.EmSerName;
            _alert.email.serverPort = View.EmSerPort;
            _alert.email.emailTo = View.EmTo;
            _alert.email.authUser = View.EmUsername;
            View.Close();
        }

        private void CancelClick()
        {
            View.Close();
        }

        private void TestClick()
        {
            //ToDo: check emailFrom, emailTo
            _eMalertService.SendAlert("Alert test", "Congratulations!\nYour settings are working!");
        }
    }
}
