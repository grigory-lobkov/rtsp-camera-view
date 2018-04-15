using System.Drawing;
using Presenter.Common;

namespace Presenter.Views
{
    public interface ISourceView : IViewControl
    {
        void SetBadPlayerControl(IViewControl control);
        void SetGoodPlayerControl(IViewControl control);
        void SetPlayerControlControl(IViewControl control);

        bool HidePlayer { get; set; }

        int ControlShowSec { get; set; }
        void ShowControl();

        string SrcName { get; set; }
        bool SrcNameShow { get; set; }
        Color SrcNameColor { get; set; }
        bool SrcNameBg { get; set; }
        Color SrcNameBgColor { get; set; }
        int SrcNameSize { get; set; }
        int SrcNameAlign { get; set; }
        bool SrcNameAutoHide { get; set; }
        int SrcNameShowSec { get; set; }
        void SrcNameRefresh();
    }
}