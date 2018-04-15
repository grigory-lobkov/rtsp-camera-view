using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    class SourcePresenter : BasePresenterControl<ISourceView>
    {
        private AppSettings _settings = null;
        private PlayerPresenter _badPlayer = null;
        private PlayerPresenter _goodPlayer = null;
        private PlayerPresenter _shownPlayer = null;
        private PlayerControlPresenter _control = null;
        private Camera _source = null;

        public SourcePresenter(IApplicationController controller, ISourceView view)
            : base(controller, view)
        {
            _control = Controller.Get<PlayerControlPresenter>();
            View.SetPlayerControlControl(_control.Control);
            _control.Show();
            _control.Play += CommandPlay;
            _control.Stop += CommandStop;
            _control.VolumeUp += CommandVolumeUp;
            _control.VolumeDown += CommandVolumeDown;
            _control.OpenOptions += CommandOpenOptions;
            _control.Maximize += CommandPlayMaximize;
            _control.Remove += CommandPlayRemove;
    }

        public void SetSettings(AppSettings settings)
        {
            _settings = settings;
        }

        public int position;

        public Camera Source { get => _source; set => SetSource(value); }

        private void SetSource(Camera source)
        {
            if (_badPlayer == null)
            {
                _badPlayer = Controller.Get<PlayerPresenter>();
                View.SetBadPlayerControl(_badPlayer.Control);
                _badPlayer.Playing += BadPlaying;
            }
            _badPlayer.SetSourceString(source.rtspBad);
            _badPlayer.SetAspectRatio(source.aspectRatio);
            if (_goodPlayer == null)
            {
                _goodPlayer = Controller.Get<PlayerPresenter>();
                View.SetGoodPlayerControl(_goodPlayer.Control);
            }
            _goodPlayer.SetSourceString(source.rtspBad);
            _goodPlayer.SetAspectRatio(source.aspectRatio);
            View.SrcName = source.name;
            View.SrcNameShow = source.nameView.enabled;
            NameView nv = source.nameView.inheritGlobal ? _settings.nameView : source.nameView;
            View.SrcNameColor = nv.color;
            View.SrcNameBg = nv.paintBg;
            View.SrcNameBgColor = nv.bgColor;
            View.SrcNameSize = nv.size;
            View.SrcNameAlign = (int)nv.position;
            View.SrcNameAutoHide = nv.autoHide;
            View.SrcNameShowSec = nv.autoHideSec;
            View.SrcNameRefresh();
            _source = source;
            if (!_badPlayer.IsPlaying) View.HidePlayer = true;
            if (_settings.autoplay == 1) Play();
            _control.Show();
            _control.SetSource();
            _control.ShowSec = 100;
            _shownPlayer = _badPlayer;
        }

        private void CommandPlay()
        {
            if (_shownPlayer == null) return;
            _shownPlayer.Play();
        }
        private void CommandStop()
        {
            if (_shownPlayer == null) return;
            _shownPlayer.Stop();
        }
        private void CommandVolumeUp()
        {
            if (_shownPlayer == null) return;
            _shownPlayer.Volume += Math.Max(_shownPlayer.Volume / 4, 5);
        }
        private void CommandVolumeDown() {
            if (_shownPlayer == null) return;
            _shownPlayer.Volume -= _shownPlayer.Volume + 10;
        }
        private void CommandOpenOptions() { }
        private void CommandPlayMaximize() { }
        private void CommandPlayRemove() { }

        private void Play()
        {
            if (_source == null) return;
            _badPlayer.Play();
            _control.Buffering();
        }

        private void BadPlaying()
        {
            View.HidePlayer = false;
            _control.Playing();
        }

    }
}
