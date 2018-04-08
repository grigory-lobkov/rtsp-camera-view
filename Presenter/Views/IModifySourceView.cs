using System;
using System.Drawing;
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

        event Action CreateClick;
        event Action SaveClick;
        event Action CancelClick;
        event Action DeleteClick;

        void Show();
        void Hide();
    }
}