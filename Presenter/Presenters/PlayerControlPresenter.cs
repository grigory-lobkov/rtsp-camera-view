using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    class PlayerControlPresenter : BasePresenterControl<IPlayerControlView>
    {
        public PlayerControlPresenter(IApplicationController controller, IPlayerControlView view)
            : base(controller, view)
        {
            View.Play += Play;
            View.Stop += Stop;
            View.VolumeUp += VolumeUp;
            View.VolumeDown += VolumeDown;
            View.OpenOptions += OpenOptions;
            View.Maximize += Maximize;
            View.Remove += Remove;
            View.SourceReset();
        }

        public void Show() { View.ShowMe(); }
        public int ShowSec { set => View.ShowSec = value; get => View.ShowSec; }

        public void SetSource() { View.SourceSet(); }
        //public void EmptySource() { View.SourceReset(); }
        public void Playing() { View.Playing(); }
        public void Stopped() { View.Stopped(); }
        public void Buffering() { View.Buffering(); }

        public event Action Play;
        public event Action Stop;
        public event Action VolumeUp;
        public event Action VolumeDown;
        public event Action OpenOptions;
        public event Action Maximize;
        public event Action Remove;
    }
}