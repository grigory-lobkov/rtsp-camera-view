using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IPlayerControlView : IViewControl
    {
        void ShowMe();
        int ShowSec { set; get; }

        void SourceSet();
        void SourceReset();
        void Playing();
        void Stopped();
        void Buffering();
        void SoundFound();

        event Action Play;
        event Action Stop;
        event Action VolumeUp;
        event Action VolumeDown;
        event Action OpenOptions;
        event Action Maximize;
        event Action Remove;
    }
}