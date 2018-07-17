using System;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    class PlayerControlPresenter : BasePresenterControl<IPlayerControlView>
    {
        public PlayerControlPresenter(IApplicationController controller, IPlayerControlView view)
            : base(controller, view)
        {
            View.Play += () => Invoke(Play);
            View.Stop += () => Invoke(Stop);
            View.VolumeUp += () => Invoke(VolumeUp);
            View.VolumeDown += () => Invoke(VolumeDown);
            View.OpenOptions += () => Invoke(OpenOptions);
            View.Maximize += () => Invoke(Maximize);
            View.Remove += () => Invoke(Remove);
            View.SourceReset();
        }
        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public void SourceSet()
        {
            View.SourceSet();
        }
        public void SourceReset() { View.SourceReset(); }
        public void Playing() { View.Playing(); }
        public void Stopped() { View.Stopped(); }
        public void Buffering() { View.Buffering(); }
        public void SoundFound() { View.SoundFound(); }
        public void Maximized() { View.Maximized(); }
        public void Minimized() { View.Minimized(); }

        public event Action Play;
        public event Action Stop;
        public event Action VolumeUp;
        public event Action VolumeDown;
        public event Action OpenOptions;
        public event Action Maximize;
        public event Action Remove;
    }
}