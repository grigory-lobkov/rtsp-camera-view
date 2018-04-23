using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IPlayerView : IViewControl
    {
        bool Play();
        bool Stop();
        bool IsPlaying { get; }

        event Action Playing;
        event Action Buffering;
        event Action Stopped;
        event Action SoundDetected;
        event Action LostStream;
        event Action SizeDetected;

        int Volume { get; set; }
        string SourceString { get; set; }
        string AspectRatio { set; }
        int SrcHeight { get; }
        int SrcWidth { get; }
    }
}