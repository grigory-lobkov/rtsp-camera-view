using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IPlayerView : IViewControl
    {
        //VlcStatus Status;
        bool Play();
        bool Stop();
        bool IsPlaying { get; }

        event Action Playing;
        event Action Buffering;
        event Action Stopped;
        event Action SoundDetected;
        //event Action SizeDetected;
        event Action LostStream;

        int Volume { get; set; }
        //bool SoundPresent { get; }
        string SourceString { get; set; }
        //string AspectRatio { get; set; }
        string AspectRatio { set; }
    }
}