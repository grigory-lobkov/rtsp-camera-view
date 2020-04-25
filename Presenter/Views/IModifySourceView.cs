using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IModifySourceView : IViewControl
    {
        void SetImges(object imageList);

        string SrcName { get; set; }
        event Action NameViewClick;
        string RtspBad { get; set; }
        string RtspGood { get; set; }
        string AspectRatio { get; set; }
        int CamIcon { get; set; }
        int Position { get; set; }
        bool IsNewSource { get; set; }
        bool IsNameShow { get; set; }
        bool IsNameInherit { get; set; }
        int IsGoodOnlyInFullview { get; set; }

        event Action CreateClick;
        event Action SaveClick;
        event Action CancelClick;
        event Action DeleteClick;
        event Action RtspBadEnter;
        event Action RtspGoodEnter;

        void Show();
        void Hide();

        // Localization
        string CamNameLabelText { set; }
        string CamNameText { set; }
        string CamNameShowText { set; }
        string CamNameInheritText { set; }
        string CamNameModifyText { set; }
        string CamEditRtsp1LabelText { set; }
        string RtspBadText { set; }
        string CamEditRtsp2LabelText { set; }
        string RtspGoodText { set; }
        string CamEditIconLabelText { set; }
        string AspectRatioLabelText { set; }
        string AspectRatioText { set; }
        string CreateCamButtonText { set; }
        string SaveCamButtonText { set; }
        string CancelCamButtonText { set; }
        string DelCamLabelText { set; }
        string CameraDeleteConfirm1Text { set; }
        string CameraDeleteConfirm2Text { set; }
        string RtspGoodOnlyInFullviewText { set; }

    }
}