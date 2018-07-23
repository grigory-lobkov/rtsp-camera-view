using System;
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
        int Height { get; }
        int Width { get; }

        event Action MouseMoved;
        event Action DoubleClicked;
        event Action SizeChange;

        bool Maximized { get; set; }
        void Log(string str);

        bool SwitchToBadTimerEnabled { get; set; }
        bool SwitchToGoodTimerEnabled { get; set; }
        bool StopBadTimerEnabled { get; set; }
        bool StopGoodTimerEnabled { get; set; }
        bool StopOnInvisibleTimerEnabled { get; set; }
        event Action SwitchToGood;
        event Action SwitchToBad;
        event Action StopBadPlayer;
        event Action StopGoodPlayer;
        event Action StopOnInvisible;
        void ShowBadPlayer();
        void ShowGoodPlayer();

        bool SourceDragging { get; set; }
        event Action DragDropAccept;
        event Action DragDropInit;
        event Action DragDropInitFinish;
    }
}