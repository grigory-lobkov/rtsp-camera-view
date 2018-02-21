using System;

public class RtspBadGoodVLC : Panel
{
    AxAXVLC.AxVLCPlugin2 vlc1; //for bad thread
    AxAXVLC.AxVLCPlugin2 vlc2; //for good thread

    public RtspBadGoodVLC()
	{
        InitializeComponent();

        vlc1 = new AxAXVLC.AxVLCPlugin2();
        ((System.ComponentModel.ISupportInitialize)(vlc1)).BeginInit();
        vlc1.Enabled = true;
        vlc1.Dock = DockStyle.Fill;
        vlc1.MediaPlayerPositionChanged += new AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEventHandler(vlcPositionChanged);
        vlc1.MediaPlayerBuffering += new AxAXVLC.DVLCEvents_MediaPlayerBufferingEventHandler(this.vlcBuffering);
        vlc1.Tag = idx;
        this.Controls.Add(vlc1);
        ((System.ComponentModel.ISupportInitialize)(vlc1)).EndInit();
        vlc2 = new AxAXVLC.AxVLCPlugin2();
        ((System.ComponentModel.ISupportInitialize)(vlc2)).BeginInit();
        vlc2.Enabled = true;
        vlc2.Dock = DockStyle.Fill;
        vlc2.MediaPlayerPositionChanged += new AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEventHandler(vlc2PositionChanged);
        vlc2.MediaPlayerBuffering += new AxAXVLC.DVLCEvents_MediaPlayerBufferingEventHandler(this.vlc2Buffering);
        vlc2.Tag = idx;
        vlc2.Visible = false;
        this.Controls.Add(vlc2);
        ((System.ComponentModel.ISupportInitialize)(vlc2)).EndInit();
    
    }
    public class TransparentPanel : Panel
    {
        public TransparentPanel() { }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e) { }
    }
}
