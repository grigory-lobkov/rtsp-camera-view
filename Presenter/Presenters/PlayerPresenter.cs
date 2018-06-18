using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    class PlayerPresenter : BasePresenterControl<IPlayerView>
    {
        public PlayerPresenter(IApplicationController controller, IPlayerView view)
            : base(controller, view)
        {
            View.Playing += () => Invoke(Playing);
            View.Buffering += () => Invoke(Buffering);
            View.Stopped += () => Invoke(Stopped);
            View.SoundDetected += () => Invoke(SoundDetected);
            View.LostStream += () => Invoke(LostStream);
            View.LostStreamRestored += () => Invoke(LostStreamRestored);
            View.SizeDetected += () => Invoke(SizeDetected);
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public bool Play() {
            return View.Play();
        }
        public bool Stop() { return View.Stop(); }
        public bool IsPlaying { get => View.IsPlaying; }

        public event Action Playing;
        public event Action Buffering;
        public event Action Stopped;
        public event Action SoundDetected;
        public event Action SizeDetected;
        public event Action LostStream;
        public event Action LostStreamRestored;

        public int Volume { get => View.Volume; set => View.Volume = value; }

        public void SetSourceString(string value) { View.SourceString = value; }
        public void SetAspectRatio(string value) { View.AspectRatio = value; }
        public string SourceString { get => View.SourceString; }
        public int SrcHeight { get => View.SrcHeight; }
        public int SrcWidth { get => View.SrcWidth; }

        public int LostRtspRetryMin { get => View.LostRtspRetryMin; set => View.LostRtspRetryMin = value; }
    }
}