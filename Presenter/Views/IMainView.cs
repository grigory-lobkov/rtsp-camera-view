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

        void ErrorAccessSettings(string msg);
        void ErrorOnLoadSettings(string msg);
        void ErrorOnSaveSettings(string msg);
        void ErrorOnCreateGridNoLib(string msg);
        void ErrorOnCreateGridBadVer(string msg);
        void ErrorOnCreateGridOther(string msg);

        event Action ShowHintTimer;
        event Action HideHintTimer;
        bool HintShowTimer { get; set; }
        bool HintOpenCtrlShow { get; set; }
        bool HintAddCameraShow { get; set; }
        bool HintDropCameraShow { get; set; }
        bool HintNewRtspBadShow { get; set; }
        bool HintNewRtspGoodShow { get; set; }

        bool AskIfAddSamples();

        string SourcesPageText { set; }
        string SettingsPageText { set; }
        string AskAddSamplesText { set; }
        string CreateGridCommonErrorText { set; }
        string CreateGridNoLibErrorText { set; }
        string CreateGridBadVerErrorText { set; }
        string CreateGridEndErrorText { set; }
        string SettingsSaveErrorText { set; }
        string SettingsLoadErrorText { set; }
        string SettingsAccesErrorText { set; }
        string HintOpenCtrlText { set; }
        string HintAddCameraText { set; }
        string HintDropCameraText { set; }
        string HintRTSP1Text { set; }
        string HintRTSP2Text { set; }
        string FullScreenMenuItemText { set; }
        string ExitFullScreenMenuItemText { set; }
    }
}