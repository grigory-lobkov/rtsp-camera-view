using System;
using System.Drawing;
using Presenter.Common;

namespace Presenter.Views
{
    public interface INameViewSetupView : IView
    {
        //event Action PositionChanged;
        int Position { get; set; }

        //event Action TextColorChanged;
        Color TextColor { get; set; }

        //event Action BgEnabledChanged;
        bool BgEnabled { get; set; }

        //event Action BgColorChanged;
        Color BgColor { get; set; }

        //event Action TextSizeChanged;
        int TextSize { get; set; }

        //event Action AutoHideEnabledChanged;
        bool AutoHideEnabled { get; set; }

        //event Action AutoHideSecChanged;
        int AutoHideSec { get; set; }

        event Action OkClick;
        event Action CancelClick;

        // Localization
        string ThisText { set; }
        string PositioningLabelText { set; }
        string CamNameLabelText { set; }
        string TextColorLabelText { set; }
        string BackgroundCheckBoxText { set; }
        string TextSizeLabelText { set; }
        string AutoHideCheckBoxText { set; }
        string OkButtonText { set; }
        string CancelButtonText { set; }

    }
}