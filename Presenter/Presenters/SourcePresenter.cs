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
        private int _badH, _badW;
        private string _badString, _goodString;
        private bool stoppedOnInvisible = false;
        private bool log = false; // for debug

        public Action Maximized;
        public Action Minimized;

        public SourcePresenter(IApplicationController controller, ISourceView view)
            : base(controller, view)
        {
            _control = Controller.Get<PlayerControlPresenter>();
            View.SetPlayerControlControl(_control.Control);
            _control.Play += CommandPlay;
            _control.Stop += CommandStop;
            _control.VolumeUp += CommandVolumeUp;
            _control.VolumeDown += CommandVolumeDown;
            _control.OpenOptions += CommandOpenOptions;
            _control.Maximize += CommandMaximize;
            _control.Remove += CommandRemove;
            View.MouseMoved += MouseMoved;
            View.DoubleClicked += CommandMaximize;
            View.SizeChange += CheckNeedSwitch;
            View.SwitchToGood += SwitchToGood;
            View.SwitchToBad += SwitchToBad;
            View.StopBadPlayer += StopBadPlayer;
            View.StopGoodPlayer += StopGoodPlayer;
            View.StopOnInvisible += StopOnInvisible;
            View.DragDropAccept += DragDropAcceptF;
            View.DragDropInit += DragDropInitF;
            View.DragDropInitFinish += () => Invoke(DragDropInitFinish);
        }
        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public void SetSettings(AppSettings settings)
        {
            if (log) View.Log("SetSettings");
            _settings = settings;
        }

        private int _position;
        public int Position
        {
            get => _position;
            set { _position = value; if (_source != null) _source.position = -1; }
        }
        public bool IsPlaying
        {
            get => _shownPlayer != null && _shownPlayer.IsPlaying;
            set { if (value) CommandPlay(); else CommandStop(); }
        }

        private void MouseMoved()
        {
            View.ShowControl();
        }


        /*****
         * Set/Reset Source functions
         */
        public Camera Source
        {
            get => _source;
            set { if (value != null) SetSource(value); else ResetSource(); }
        }

        private void ResetSource()
        {
            if (log) View.Log("ResetSource");
            CommandStop();
            View.HidePlayer = true;
            if (_source != null) { _source.position = -1; _source = null; }
            View.SrcName = "";
            _badString = "";
            _goodString = "";
            View.SrcNameShow = false;
            _shownPlayer = null;
            _control.SourceReset();
        }
        public void CreateBadSource()
        {
            _badPlayer = Controller.Get<PlayerPresenter>();
            View.SetBadPlayerControl(_badPlayer.Control);
            _badPlayer.Playing += BadPlaying;
            _badPlayer.Stopped += BadStopped;
            _badPlayer.SoundDetected += BadSoundDetected;
            _badPlayer.Buffering += BadBuffering;
            _badPlayer.SizeDetected += BadSizeDetected;
            _badPlayer.LostStream += SignalLostF;
            _badPlayer.LostStreamRestored += SignalRestoredF;
            _badPlayer.LostRtspRetryMin = _settings.alert.email.whenDissapearMin;
        }
        private void SetSource(Camera source)
        {
            if (log) View.Log("SetSource");
            if (_settings == null) return;
            source.position = _position;
            if (String.IsNullOrEmpty(source.rtspBad))
            {
                if (String.IsNullOrEmpty(source.rtspGood)) return; //todo: generate error message on empty bad (and good?) strings
                _badString = source.rtspGood;
                _goodString = "";
            }
            else
            {
                _badString = source.rtspBad;
                _goodString = source.rtspGood;
            }
            if (_badPlayer == null)
            {
                CreateBadSource();
            }
            _badPlayer.SetSourceString(_badString);
            _badPlayer.SetAspectRatio(source.aspectRatio);
            _badPlayer.Volume = 0;
            _badPlayer.LostRtspRetryMin = _settings.alert.email.whenDissapearMin;
            if (!String.IsNullOrEmpty(_goodString))
            {
                if (_goodPlayer == null)
                {
                    _goodPlayer = Controller.Get<PlayerPresenter>();
                    View.SetGoodPlayerControl(_goodPlayer.Control);
                    _goodPlayer.Playing += GoodPlaying;
                    _goodPlayer.Stopped += GoodStopped;
                    _goodPlayer.SoundDetected += GoodSoundDetected;
                    _goodPlayer.Buffering += GoodBuffering;
                    _goodPlayer.LostStream += SignalLostF;
                    _goodPlayer.LostStreamRestored += SignalRestoredF;
                    _goodPlayer.LostRtspRetryMin = _settings.alert.email.whenDissapearMin;
                }
                _goodPlayer.SetSourceString(_goodString);
                _goodPlayer.SetAspectRatio(source.aspectRatio);
                _goodPlayer.Volume = _badPlayer.Volume;
                _goodPlayer.LostRtspRetryMin = _settings.alert.email.whenDissapearMin;
            }
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
            if (!_badPlayer.IsPlaying) // todo: can be Buffering, SourceSet need not!
            {
                View.HidePlayer = true;
                _badH = 0;
                _badW = 0;
                _control.SourceSet();
            }
            if (_settings.autoplay_now == 1) CommandPlay();
        }


        /*****
         * Stop on invisible functions
         */
        public void Visible()
        {
            if (log) View.Log("Visible");
            View.StopOnInvisibleTimerEnabled = false;
            if (stoppedOnInvisible)
            {
                CommandPlay();
                stoppedOnInvisible = false;
            }
        }
        public void InvisibleIfMinimized()
        {
            if (log) View.Log("InvisibleIfMinimized");
            if (!View.Maximized) View.StopOnInvisibleTimerEnabled = true;
        }
        private void StopOnInvisible()
        {
            if (log) View.Log("StopOnInvisible");
            if (_shownPlayer != null && _shownPlayer.IsPlaying)
            {
                stoppedOnInvisible = true;
                CommandStop();
            }
        }

        /*****
         * Control event react functions
         */
        public void CommandPlay()
        {
            if (log) View.Log("CommandPlay");
            if (_source == null) return;
            if (_goodPlayer != null && _goodPlayer.IsPlaying)
            {
                _shownPlayer = _goodPlayer;
                View.ShowGoodPlayer();
            }
            else
            {
                _shownPlayer = _badPlayer;
                _badPlayer.Play();
            }
            CheckNeedSwitch();
        }
        private void CommandStop()
        {
            if (log) View.Log("CommandStop");
            if (_badPlayer == null) return;
            _badPlayer.Stop();
            if (_goodPlayer != null)
            {
                if (_shownPlayer == _goodPlayer) _badPlayer.Volume = _goodPlayer.Volume;
                _goodPlayer.Stop();
            }
            _shownPlayer = null;
            View.SwitchToGoodTimerEnabled = false;
            View.SwitchToBadTimerEnabled = false;
            View.StopBadTimerEnabled = false;
            View.StopGoodTimerEnabled = false;
            View.StopOnInvisibleTimerEnabled = false;
            View.HidePlayer = true;
            _badH = 0;
            _badW = 0;
        }
        private void CommandVolumeUp()
        {
            if (log) View.Log("CommandVolumeUp");
            if (_shownPlayer == null) return;
            int vol = _shownPlayer.Volume;
            vol = Math.Min(200, vol + Math.Max(vol / 3, 20));
            _shownPlayer.Volume = vol;
        }
        private void CommandVolumeDown()
        {
            if (log) View.Log("CommandVolumeDown");
            if (_shownPlayer == null) return;
            int vol = _shownPlayer.Volume;
            vol = Math.Max(0, vol - Math.Max(vol / 5, 20));
            _shownPlayer.Volume = vol;
        }
        private void CommandOpenOptions()
        {
            if (log) View.Log("CommandOpenOptions");
            _source?.Edit?.Invoke();
        }
        private void CommandMaximize()
        {
            if (log) View.Log("CommandMaximize");
            View.Maximized = !View.Maximized;
            if (View.Maximized)
            {
                _control.Maximized();
                Maximized?.Invoke();
            }
            else
            {
                _control.Minimized();
                Minimized?.Invoke();
            }
            CheckNeedSwitch();
        }
        private void CommandRemove()
        {
            if (log) View.Log("CommandRemove");
            CommandStop();
            ResetSource();
        }


        /*****
         * Player event react functions
         */
        private void BadPlaying()
        {
            if (log) View.Log("BadPlaying");
            View.HidePlayer = false;
            if (_shownPlayer == _goodPlayer)
            {
                _badPlayer.Volume = _goodPlayer.Volume;
                _goodPlayer.Volume = 0;
            }
            _shownPlayer = _badPlayer;
            View.ShowBadPlayer();
            _control.Playing();
            CheckNeedSwitch();
            View.SwitchToBadTimerEnabled = false;
            View.StopBadTimerEnabled = false;
            View.StopGoodTimerEnabled = true;
        }
        private void GoodPlaying()
        {
            if (log) View.Log("GoodPlaying");
            View.HidePlayer = false;
            _shownPlayer = _goodPlayer;
            _goodPlayer.Volume = _badPlayer.Volume;
            _badPlayer.Volume = 0;
            View.ShowGoodPlayer();
            _control.Playing();
            View.SwitchToGoodTimerEnabled = false;
            View.StopGoodTimerEnabled = false;
            View.StopBadTimerEnabled = true;
            CheckNeedSwitch();
        }
        private void BadStopped()
        {
            if (log) View.Log("BadStopped");
            if (_shownPlayer == _badPlayer)
            {
                View.HidePlayer = true;
                _control.Stopped();
            }
        }
        private void GoodStopped()
        {
            if (log) View.Log("GoodStopped");
            if (_shownPlayer == _goodPlayer)
            {
                View.HidePlayer = true;
                _control.Stopped();
            }
        }
        private void BadSoundDetected()
        {
            if (log) View.Log("BadSoundDetected");
            _control.SoundFound();
            if (_settings.unmute_now == 1) _badPlayer.Volume = 75;
        }
        private void GoodSoundDetected()
        {
            if (log) View.Log("GoodSoundDetected");
            _control.SoundFound();
        }
        private void BadBuffering()
        {
            if (log) View.Log("BadBuffering");
            if (_shownPlayer == _badPlayer) _control.Buffering();
        }
        private void GoodBuffering()
        {
            if (log) View.Log("GoodBuffering");
            if (_shownPlayer == _goodPlayer) _control.Buffering();
        }
        private void BadSizeDetected()
        {
            if (log) View.Log("BadSizeDetected");
            if (_goodString != "")
            {
                _badH = _badPlayer.SrcHeight;
                _badW = _badPlayer.SrcWidth;
                CheckNeedSwitch();
            }
        }


        /*****
         * Switch Bad/Good SourceString functions
         */
        private void CheckNeedSwitch()
        {
            if (log) View.Log("CheckNeedSwitch");
            if (_badH <= 0) return;
            if (View.Height > _badH && View.Width > _badW)
            {
                if (_shownPlayer != _goodPlayer && _goodString != "" && _goodPlayer != null)
                {
                    if (_goodPlayer.IsPlaying) GoodPlaying();
                    else View.SwitchToGoodTimerEnabled = true;
                }
            }
            else
            {
                if (_shownPlayer != _badPlayer)
                {
                    if (_badPlayer.IsPlaying) BadPlaying();
                    else View.SwitchToBadTimerEnabled = true;
                }
            }
        }
        private void SwitchToGood()
        {
            if (log) View.Log("SwitchToGood");
            //if (_goodPlayer == null) return;
            if (View.Height > _badH && View.Width > _badW)
            {
                if (_goodPlayer.IsPlaying) GoodPlaying();
                else _goodPlayer.Play();
            }
        }
        private void SwitchToBad()
        {
            if (log) View.Log("SwitchToBad");
            if (View.Height <= _badH && View.Width <= _badW)
            {
                if (_badPlayer.IsPlaying) BadPlaying();
                else _badPlayer.Play();
            }
        }
        private void StopBadPlayer()
        {
            if (log) View.Log("StopBadPlayer");
            if (_shownPlayer != _badPlayer) _badPlayer.Stop();
            else CheckNeedSwitch();
        }
        private void StopGoodPlayer()
        {
            if (log) View.Log("StopGoodPlayer");
            if (_goodPlayer == null || String.IsNullOrEmpty(_goodString)) return;
            if (_shownPlayer != _goodPlayer) _goodPlayer.Stop();
            else CheckNeedSwitch();
        }
        private void PreshowBadPlayer()
        {
            if (log) View.Log("PreshowBadPlayer");
            if (_badPlayer == null || String.IsNullOrEmpty(_badString)) return;
            /*if (_shownPlayer != _badPlayer)*/ BadPlaying();
        }
        private void PreshowGoodPlayer()
        {
            if (log) View.Log("PreshowGoodPlayer");
            if (_goodPlayer == null || String.IsNullOrEmpty(_goodString)) return;
            if (_shownPlayer != _goodPlayer) GoodPlaying();
        }


        /*****
         * Drag & Drop functions
         */
        public bool DragDropInitiator = false;
        public bool DragDropAcceptor = false;
        public void DropDragBegin()
        {
            if (log) View.Log("DropDragBegin");
            DragDropInitiator = false;
            DragDropAcceptor = false;
            View.SourceDragging = true;
        }
        public void DragDropEnd()
        {
            if (log) View.Log("DragDropEnd");
            DragDropInitiator = false;
            DragDropAcceptor = false;
            View.SourceDragging = false;
        }
        public Action DragDropInit;
        public Action DragDropInitFinish;
        private void DragDropAcceptF()
        {
            if (log) View.Log("DragDropAcceptF");
            DragDropAcceptor = true;
        }
        private void DragDropInitF()
        {
            if (log) View.Log("DragDropInitF");
            DragDropInitiator = true;
            DragDropInit?.Invoke();
        }


        /*****
         * Lost stream alerting functions
         */
        public bool signalLost = false;
        public bool signalRestored = false;
        public Action SignalLost;
        public Action SignalRestored;
        private void SignalLostF()
        {
            if (log) View.Log("SignalLostF");
            signalLost = true;
            SignalLost?.Invoke();
        }
        private void SignalRestoredF()
        {
            if (log) View.Log("SignalRestoredF");
            signalRestored = true;
            SignalRestored?.Invoke();
        }
        
        //public void Log(string msg) { View.Log(msg); }
    }
}
