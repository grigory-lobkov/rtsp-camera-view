using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IPlayerControlView : IViewControl
    {
        void SourceSet();
        void SourceReset();
        void Playing();
        void Stopped();
        void Buffering();
        void SoundFound();
        void Maximized();
        void Minimized();

        event Action Play;
        event Action Stop;
        event Action VolumeUp;
        event Action VolumeDown;
        event Action OpenOptions;
        event Action Maximize;
        event Action Remove;
    }
}