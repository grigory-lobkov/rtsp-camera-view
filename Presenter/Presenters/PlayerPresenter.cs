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
        }

        public bool Play() {
            // actions link
            // moved here from constructor, somewhy link disappear in ViewVlc215 elsewhere
            View.Playing += Playing;
            View.Buffering += Buffering;
            View.Stopped += Stopped;
            View.SoundDetected += SoundDetected;
            View.LostStream += LostStream;
            // end actions link
            return View.Play();
        }
        public bool Stop() { return View.Stop(); }
        public bool IsPlaying { get => View.IsPlaying; }

        public event Action Playing;
        public event Action Buffering;
        public event Action Stopped;
        public event Action SoundDetected;
        public event Action LostStream;

        public int Volume { get => View.Volume; set => View.Volume = value; }

        public void SetSourceString(string value) { View.SourceString = value; }
        public void SetAspectRatio(string value) { View.AspectRatio = value; }
        public string SourceString { get => View.SourceString; }
    }
}