
using System;
using System.Threading;
using System.Windows.Forms;
using Presenter.Views;
using Presenter.Common;
//using AxAXVLC;

namespace ViewVlc215
{
    public class Player : UserControl, IPlayerView
    {
        public enum VlcStatus { Stopped = 0, Playing = 1, Buffering = 2, PositionFound = 3, Preparing = 4 };
        private AxAXVLC.AxVLCPlugin2 vlc1;
        private System.Windows.Forms.Timer lostTimer;
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing)
            {
                vlc1.Dispose();
                lostTimer.Dispose();
            }
            base.Dispose(disposing);
        }
        //private void InitInThread(object sender) { }
        private void InitializeComponent()
        {
            vlc1 = new AxAXVLC.AxVLCPlugin2();
            ((System.ComponentModel.ISupportInitialize)(vlc1)).BeginInit();
            //try { ((System.ComponentModel.ISupportInitialize)(vlc1)).BeginInit(); }
            //catch { };
            //ThreadPool.QueueUserWorkItem(InitInThread, new object[] { this });
            //Thread.Sleep(1000);
            //InitInThread(this);

            this.SuspendLayout();
            vlc1.Enabled = false;
            vlc1.Dock = DockStyle.Fill;
            vlc1.MediaPlayerPositionChanged += (sender,args) => Vlc1PositionChanged();
            vlc1.MediaPlayerBuffering += (sender, args) => Vlc1Buffering();
            this.Controls.Add(vlc1);
            lostTimer = new System.Windows.Forms.Timer();
            lostTimer.Tick += new EventHandler(this.LostRtsp1Timer_Tick);
            ((System.ComponentModel.ISupportInitialize)(vlc1)).EndInit(); //no vlc: System.IO.FileNotFoundException: 'Не найден указанный модуль. (Исключение из HRESULT: 0x8007007E)'
            //try { ((System.ComponentModel.ISupportInitialize)(vlc1)).EndInit(); }
            //catch { };
            this.ResumeLayout(false);
        }


        private string sourceString;
        private string aspectRatio;
        private VlcStatus vlc1Status;
        private int vlcH;
        public int SrcHeight { get => vlcH; }
        private int vlcW;
        public int SrcWidth { get => vlcW; }
        private int volume = 0;
        private bool isSoundPresent;
        public event Action Stopped;
        public event Action Buffering;
        public event Action Playing;
        public event Action SoundDetected;
        public event Action SizeDetected;
        public event Action LostStream;
        private string playlistAddOptions = null;//":no-audio"
        private string defaultAspectRatio = "auto";
        private int lostRtspOnStartTimer = 30000;
        private int lostRtspTimer = 5000;

        public bool IsPlaying { get => vlc1Status == VlcStatus.Playing; }

        public Player()
        {
            InitializeComponent();
            vlc1.playlist.stop(); // to generate error InvalidCastException on bad VLC version on grid creation
            vlc1Status = VlcStatus.Preparing;
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public int Volume
        {
            get => volume;
            set
            {
                try { vlc1.audio.Volume = value; } catch { }
                volume = value;
            }
        }
        public bool SoundPresent
        {
            get => isSoundPresent;
        }
        public string SourceString
        {
            get => sourceString;
            set
            {
                if (sourceString == null || !sourceString.Equals(value))
                {
                    Stop();
                    vlc1.playlist.items.clear();
                    if (value != "" && value != null) vlc1.playlist.add(value, null, playlistAddOptions);
                    vlc1.Toolbar = false;
                    sourceString = value;
                }
            }
        }
        public string AspectRatio
        {
            get => aspectRatio;
            set
            {
                if (aspectRatio == null || !aspectRatio.Equals(value))
                {
                    Stop();
                    try
                    {
                        if (value != "" && value != null) aspectRatio = value;
                        else aspectRatio = defaultAspectRatio;
                        vlc1.video.aspectRatio = aspectRatio;
                    }
                    catch { }
                }
            }
        }

        public VlcStatus Status
        {
            get => vlc1Status;
        }



        public bool Stop()
        {
            if (vlc1Status != VlcStatus.Stopped)
            {
                lostTimer.Enabled = false;
                vlcH = 0;
                vlcW = 0;
                vlc1.playlist.stop();
                isSoundPresent = false;
                vlc1Status = VlcStatus.Stopped;
                Invoke(Stopped);
                return true;
            }
            return false;
        }

        public bool Play()
        {
            if (vlc1Status == VlcStatus.Stopped && vlc1.playlist.items.count > 0)
            {
                vlc1Status = VlcStatus.Buffering;
                lostTimer.Interval = lostRtspOnStartTimer;
                lostTimer.Enabled = true;
                vlc1.playlist.play();
                vlc1.audio.Volume = this.volume; // important for user movies
                Invoke(Buffering);
                return true;
            }
            return false;
        }

        private void Vlc1Buffering()
        {
            if (vlc1Status == VlcStatus.Buffering)
            {
                vlc1.audio.Volume = this.volume; // for user movies and rtsp sources
                if (vlc1.audio.track > 0 && !isSoundPresent)
                {
                    isSoundPresent = true;
                    Invoke(SoundDetected);
                }
            }
        }
        private int PosChangedTimes = 0;
        private void Vlc1PositionChanged()
        {
            lostTimer.Enabled = false;
            lostTimer.Enabled = true;
            if (vlc1Status == VlcStatus.Buffering)
            {
                vlc1Status = VlcStatus.PositionFound;
                PosChangedTimes = 1;
            }
            else if (vlc1Status == VlcStatus.PositionFound)
            {
                PosChangedTimes++;
                if (PosChangedTimes == 5)
                {
                    vlc1Status = VlcStatus.Playing;
                    Invoke(Playing);
                    lostTimer.Interval = lostRtspTimer;
                }
            }
            if (vlcH <= 0)
            {
                vlc1.audio.Volume = this.volume; // important for user movies
                if (vlc1.video.height > 0)
                {
                    vlcH = vlc1.video.height;
                    vlcW = vlc1.video.width;
                    Invoke(SizeDetected);
                }
                else
                {
                    vlcH -= 1;
                    if (vlcH < -3) { vlcH = 576; vlcW = 704; Invoke(SizeDetected); }
                }
            }
        }

        private void LostRtsp1Timer_Tick(object sender, EventArgs e)
        {
            lostTimer.Enabled = false;
            Invoke(LostStream);
        }
    }
}
