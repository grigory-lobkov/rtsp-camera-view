using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IMainView : IView
    {
        void SetSourceListControl(IViewControl control);
        void SetSettingsControl(IViewControl control);
        void SetGridControl(IViewControl control);

        void ShowError(string errorMessage);

        event Action OpenClosePanelClick;

        bool PanelState { get; set; }

        event Action SplitterMoved;

        int CtrlPanelWidth { get; set; }

        event Action SourcesPageSelected;
        event Action SettingsPageSelected;

        void DoFullscreen();
        void ExitFullscreen();
        void DoAlwaysOnTop();
        void ExitAlwaysOnTop();
        void MoveToScreen(int screen);
        void Maximize();
        void SetPriority(int priority);
        void SetAppCaption();
    }
}