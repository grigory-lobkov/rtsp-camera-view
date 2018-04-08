using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IModifySettingsView : IViewControl
    {
        event Action CommandLineHelpClick;
        void ShowCommandLineHelp();
        event Action GitHubSiteClick;
        void OpenGitHubSite();
        int MatrixMaxX { set; }
        int MatrixMaxY { set; }
        int MatrixX { get; set; }
        int MatrixY { get; set; }
        event Action ApplyMatrixSizeClick;
        event Action ModifyNameViewClick;
    }
}