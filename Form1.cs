using System;//System needed
using System.Drawing;//System.Drawing needed
using System.Windows.Forms;//System.Windows.Forms needed
using AxAXVLC;

/********************
 * TODO: Если не установлен Framework, то вывести понятную ошибку
 * TODO: Если установленный Framework не поддерживается, то вывести понятную ошибку
 * TODO: Если vlc не установлен, то вывести понятную ошибку
 * TODO: Если установленный vlc не поддерживается, то вывести понятную ошибку
 * TODO: Если библиотека libvlc.dll не найдена, то вывести понятную ошибку
 ********************/

public enum VlcStatus { Stopped=0,Playing=1,Buffering=2,Preparing=3 };

namespace RTSP_mosaic_VLC_player
{
    public partial class Form1 : Form
    {
        FormWindowState lastWindowState = FormWindowState.Minimized;
        appSettings appSet;
        int arg_unmute;
        grid1[] gridline;
        grid1[,] grid;

        public class appSettings
        {
            public int screen = -1; // screen number to open window on start
            public int fullscreen = 0; // expand window: 0-no, 1-yes
            public int autoplay = 0; // auto start all sources: 0-no, 1-auto play
            public int priority = -1; // application base priority: 0-Idle, 1-BelowNormal, 2-Normal, 3-AboveNormal, 4-High
            public int unmute = 0; // do not mute audio: 0-silent, 1-enable sounds

            public matrix matrix = new matrix(); // matrix parameters (rows and columns count)

            [System.Xml.Serialization.XmlArrayItem(ElementName = "cam", Type = typeof(Camera))]
            public Camera[] cams;
        }

        public class Camera
        {
            public string name = "";
            public string rtspBad = "";
            public string rtspGood = "";
            public string aspectRatio = "16:9";//"auto"
            public int position = -1;
            //[System.Xml.Serialization.XmlIgnoreAttribute]
        }
        public class matrix
        {
            public int cntX = 2;
            public int cntY = 2;
        }
        public class grid1
        {
            public Panel subPanel;
            public AxAXVLC.AxVLCPlugin2 vlc1;
            public AxAXVLC.AxVLCPlugin2 vlc2;
            public VlcStatus vlc1Status;
            public VlcStatus vlc2Status;
            public int vlcH;
            public int vlcW;
            public TransparentPanel topPanel;
            public Label nameLabel;
            public Timer hideControlTimer;
            public Panel controlPanel;
            public Panel btnPlayStop, btnVolMinus, btnVolPlus;
            public Timer lostRtsp1Timer;
            public Timer lostRtsp2Timer;
            public Camera cam;
            public int idx;
            public Timer switchToRtsp2Timer;
            public Timer switchToRtsp1Timer;
            public bool isSoundPresent;
            public bool isRtsp2Shown;
            public Timer stopRtsp1Timer;
            public Timer stopRtsp2Timer;
            public Timer stopOtherRtspTimer;
        }

        public bool appSettingsLoad()
        {
            if (appSet == null) appSet = new appSettings();
            try
            {
                using (System.IO.Stream stream = new System.IO.FileStream(Properties.Resources.settingsFileName, System.IO.FileMode.Open))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(appSettings));
                    appSet = (appSettings)serializer.Deserialize(stream);
                }
            }
            catch
            {
                MessageBox.Show("Can't Load settings. No file?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (appSet == null) appSet = new appSettings();
                return false;
            }
            return true;
        }

        public bool appSettingsSave()
        {
            if (appSet == null) return false;
            try
            {
                using (System.IO.Stream writer = new System.IO.FileStream(Properties.Resources.settingsFileName, System.IO.FileMode.Create))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(appSettings));
                    serializer.Serialize(writer, appSet);
                }
            }
            catch
            {
                MessageBox.Show("Can't Save settings. No rights?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public Form1()
        {
            InitializeComponent();
            //appSettingsLoad();
            if (appSet == null) appSet = new appSettings();
            if (appSet.cams == null || appSet.cams.Length == 0)
            {
                Camera c1 = new Camera(), c2 = new Camera(), c3 = new Camera(), c4 = new Camera();
                c1.rtspGood = "rtsp://admin:1111@192.168.40.4:554/live/main"; c2.rtspGood = c1.rtspGood; c3.rtspGood = c1.rtspGood; c4.rtspGood = c1.rtspGood;
                c1.rtspBad = "rtsp://admin:1111@192.168.40.4:554/live/sub"; c2.rtspBad = c1.rtspBad; c3.rtspBad = c1.rtspBad; c4.rtspBad = c1.rtspBad;
                c1.position = 0; c2.position = 1; c3.position = 2; c4.position = 3;
                //c1.rtspBad = "rtsp://op:rocker@46.254.25.8:10554/live/sub";
                //c2.rtspBad = "rtsp://op:random@46.254.25.8:10555/live/sub";
                //c3.rtspBad = "rtsp://46.254.25.8:10556/av0_1&user=op&password=musc";
                //c4.rtspBad = "rtsp://46.254.25.8:10557/av0_1&user=op&password=metl";
                c1.name = "Холл1"; c2.name = "Холл2"; c3.name = "Улица1"; c4.name = "Улица2";
                Camera[] c = { c1, c2, c3, c4 };
                appSet.cams = c;
            }

            //grid = new gridt();
            createMatrix();
            fillMatrix();
            
            //axVLCPlugin1.addTarget(appSet.cams[0].rtspBad, null, AXVLC.VLCPlaylistMode.VLCPlayListReplaceAndGo, 0);
            //axVLCPlugin2.addTarget(appSet.cams[1].rtspBad, null, AXVLC.VLCPlaylistMode.VLCPlayListReplaceAndGo, 0);
            //axVLCPlugin3.addTarget(appSet.cams[2].rtspBad, null, AXVLC.VLCPlaylistMode.VLCPlayListReplaceAndGo, 0);
            //axVLCPlugin4.addTarget(appSet.cams[3].rtspBad, null, AXVLC.VLCPlaylistMode.VLCPlayListReplaceAndGo, 0);

            string[] args = Environment.GetCommandLineArgs();
            //fullscreen screen=1 autoplay unmute priority=0
            int screen = appSet.screen, fullscreen = appSet.fullscreen, autoplay = appSet.autoplay, priority=appSet.priority;
            bool f;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Length >= 10)
                    if (args[i].Substring(0, 10).Equals("fullscreen"))
                        if (args[i].Length > 10)
                            f = int.TryParse(args[i].Substring(11), out fullscreen);
                        else fullscreen = 1;
                if (args[i].Length >= 8)
                    if (args[i].Substring(0, 8).Equals("autoplay"))
                        if (args[i].Length > 8)
                            f = int.TryParse(args[i].Substring(9), out autoplay);
                        else autoplay = 1;
                if (args[i].Length >= 8)
                    if (args[i].Substring(0, 8).Equals("priority"))
                        if (args[i].Length > 8)
                            f = int.TryParse(args[i].Substring(9), out priority);
                if (args[i].Length >= 6)
                    if (args[i].Substring(0, 6).Equals("unmute"))
                        if (args[i].Length > 6)
                            f = int.TryParse(args[i].Substring(7), out arg_unmute);
                        else arg_unmute = 1;
                if (args[i].Length >= 6)
                    if (args[i].Substring(0, 6).Equals("screen"))
                        if (args[i].Length > 6)
                            f = int.TryParse(args[i].Substring(7), out screen);
            }
            
            Screen[] sc = Screen.AllScreens;
            if (screen > -1 && sc.Length > screen)
            {
                this.Left = sc[screen].Bounds.Width;
                this.Top = sc[screen].Bounds.Height;
                this.Location = sc[screen].Bounds.Location;
                this.Location = new Point(sc[screen].Bounds.Location.X, sc[screen].Bounds.Location.Y);
            }
            else
            {
            }
            if (fullscreen > 0)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            if (autoplay > 0)
                foreach (grid1 c in gridline)
                    if (c.cam != null) btnPlay_MouseClick(c.btnPlayStop, null);
            if (priority >= 0)
            {
                switch (priority)
                {
                    case 0: System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Idle; break;
                    case 1: System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.BelowNormal; break;
                    case 2: System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal; break;
                    case 3: System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.AboveNormal; break;
                    case 4: System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High; break;
                }
            }
            this.Text = Application.ProductName + " " + Application.ProductVersion
                + "  /  www.atom66.ru  /  shop@atom66.ru  /  +7 922 036 77 33  /  Григорий Лобков";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grid == null) return;
            foreach (grid1 c in gridline)
            {
                c.hideControlTimer.Dispose();
                c.lostRtsp1Timer.Dispose();
                c.lostRtsp2Timer.Dispose();
                c.switchToRtsp1Timer.Dispose();
                c.switchToRtsp2Timer.Dispose();
                c.stopRtsp1Timer.Dispose();
                c.stopRtsp2Timer.Dispose();
                c.stopOtherRtspTimer.Dispose();
                c.vlc1.Dispose();
                c.vlc2.Dispose();
                c.subPanel.Dispose();
            }
            appSettingsSave();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            int stepw = this.ClientRectangle.Width / appSet.matrix.cntX,
                steph = this.ClientRectangle.Height / appSet.matrix.cntY;
            int btnh = steph / 15, btnm = btnh / 7;
            if (btnh < 14) btnh = 14;
            int labelx = stepw / 2;
            int labely = steph / 10 - btnh/2;
            if (labely < 0) labely = 0;
            int btns = btnh + btnm, pnlh = btns + btnm;
            Point b0 = new Point(btns, btnm), b1 = new Point(btns * 4, btnm), b2 = new Point(btns * 5, btnm);
            int xl = 0;
            Size bs = new Size(btnh, btnh);
            Font lf = new Font(this.Font.Name, btnh / 3, this.Font.Style, this.Font.Unit);
            if (grid != null)
                for (int x = 0; x < appSet.matrix.cntX; x++)
                {
                    for (int y = 0; y < appSet.matrix.cntY; y++)
                        if (grid[x, y] != null)
                        {
                            grid[x, y].nameLabel.Font = lf;
                            grid[x, y].nameLabel.Location = new Point(labelx - grid[x, y].nameLabel.Width / 2, labely);
                            grid[x, y].controlPanel.Height = pnlh;
                            grid[x, y].btnPlayStop.Size = bs;
                            grid[x, y].btnVolMinus.Size = bs;
                            grid[x, y].btnVolPlus.Size = bs;
                            grid[x, y].btnPlayStop.Location = b0;
                            grid[x, y].btnVolMinus.Location = b1;
                            grid[x, y].btnVolPlus.Location = b2;
                        }
                    xl += stepw;
                }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (grid == null) return;
            if (WindowState != lastWindowState)
            {
                lastWindowState = WindowState;
                Form1_ResizeEnd(this, null);
            } 
            int stepw = this.ClientRectangle.Width / appSet.matrix.cntX,
                steph = this.ClientRectangle.Height / appSet.matrix.cntY;
            Size ps = new Size(stepw, steph);
            int xl=0;
            if (grid != null)
                for (int x = 0; x < appSet.matrix.cntX; x++)
                {
                    for (int y = 0; y < appSet.matrix.cntY; y++) if (grid[x, y] != null)
                    {
                        grid[x, y].subPanel.Location = new Point(xl, y * steph);
                        grid[x, y].subPanel.Size = ps;
                    }
                    xl += stepw;
                }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Form1_Resize(this, null);
        }

        private void createMatrix()
        {
            if (grid != null) // dispose of old data
                for (int x = grid.GetLowerBound(0); x <= grid.GetUpperBound(0); x++)
                    for (int y = grid.GetLowerBound(1); y <= grid.GetUpperBound(1); y++)
                        if (grid[x, y].subPanel != null)
                        {
                            grid[x, y].hideControlTimer.Dispose();
                            grid[x, y].switchToRtsp2Timer.Dispose();
                            grid[x, y].lostRtsp1Timer.Dispose();
                            grid[x, y].lostRtsp2Timer.Dispose();
                            grid[x, y].stopRtsp1Timer.Dispose();
                            grid[x, y].stopRtsp2Timer.Dispose();
                            grid[x, y].stopOtherRtspTimer.Dispose();
                            grid[x, y].switchToRtsp1Timer.Dispose();
                            grid[x, y].subPanel.Dispose();
                        }
            //TODO: не пересоздавать область, вновь видимую пользователем
            grid1 item;
            Panel p0,p2;
            AxAXVLC.AxVLCPlugin2 vlc1, vlc2;
            TransparentPanel p1;
            Label l1;
            Timer t1, t2, t3, t4, t5, t6, t7, t8;
            Panel b1, b2, b3;
            int hideControlTimer = Convert.ToInt32(Properties.Resources.hideControlTimer);
            int stopRtsp1Timer = Convert.ToInt32(Properties.Resources.stopBadRtspTimer);
            int stopRtsp2Timer = Convert.ToInt32(Properties.Resources.stopGoodRtspTimer);
            int stopOtherRtspTimer = Convert.ToInt32(Properties.Resources.stopOtherRtspTimer);
            int idx = 0;
            grid = new grid1[appSet.matrix.cntX, appSet.matrix.cntY];
            gridline = new grid1[appSet.matrix.cntX * appSet.matrix.cntY];
            for (int y = 0; y < appSet.matrix.cntY; y++)
            {
                for (int x = 0; x < appSet.matrix.cntX; x++)
                {
                    p0 = new Panel();
                    p0.Location = new Point(x * 150, y * 100);
                    p0.Size = new Size(150, 100);
                    p0.BackColor = Color.Black;
                    p0.ForeColor = Color.White;
                    this.Controls.Add(p0);
                    p1 = new TransparentPanel();
                    p0.Controls.Add(p1);
                    p1.Dock = DockStyle.Fill;
                    p1.Tag = idx;
                    p1.MouseEnter += new EventHandler(this.TransparentPanel_MouseEnter);
                    p1.DoubleClick += new EventHandler(this.TransparentPanel_DoubleClick);
                    p2 = new Panel();
                    p0.Controls.Add(p2);
                    p2.Dock = DockStyle.Bottom;
                    p2.BackColor = Color.Gray;
                    p2.Tag = idx;
                    p2.MouseEnter += new EventHandler(this.TransparentPanel_MouseEnter);
                    p2.Visible = false;

                    b1 = new Panel();
                    b1.BackgroundImage = Properties.Resources.btn_play;
                    b1.BackgroundImageLayout = ImageLayout.Stretch;
                    b1.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
                    b1.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
                    b1.MouseDown += new MouseEventHandler(this.btn_MouseDown);
                    b1.MouseUp += new MouseEventHandler(this.btn_MouseUp);
                    b1.MouseClick += new MouseEventHandler(this.btnPlay_MouseClick);
                    b1.Tag = idx;
                    p2.Controls.Add(b1);
                    b2 = new Panel();
                    b2.BackgroundImage = Properties.Resources.btn_vol_minus;
                    b2.BackgroundImageLayout = ImageLayout.Stretch;
                    b2.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
                    b2.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
                    b2.MouseDown += new MouseEventHandler(this.btn_MouseDown);
                    b2.MouseUp += new MouseEventHandler(this.btn_MouseUp);
                    b2.Click += new EventHandler(this.btnVolMinus_Click);
                    b2.Visible = false;
                    b2.Tag = idx;
                    p2.Controls.Add(b2);
                    b3 = new Panel();
                    b3.BackgroundImage = Properties.Resources.btn_vol_plus;
                    b3.BackgroundImageLayout = ImageLayout.Stretch;
                    b3.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
                    b3.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
                    b3.MouseDown += new MouseEventHandler(this.btn_MouseDown);
                    b3.MouseUp += new MouseEventHandler(this.btn_MouseUp);
                    b3.Click += new EventHandler(this.btnVolPlus_Click);
                    b3.Visible = false;
                    b3.Tag = idx;
                    p2.Controls.Add(b3);

                    l1 = new Label();
                    l1.AutoSize = true;
                    l1.TextAlign = ContentAlignment.TopCenter;
                    //l1.Visible = false;
                    p0.Controls.Add(l1);

                    t1 = new Timer();
                    t1.Interval = hideControlTimer;
                    t1.Tick += new EventHandler(this.hideControlTimer_Tick);
                    t1.Enabled = true;
                    t1.Tag = idx;
                    t2 = new Timer();
                    t2.Tick += new EventHandler(this.lostRtsp1Timer_Tick);
                    t2.Enabled = false;
                    t2.Tag = idx;
                    t3 = new Timer();
                    t3.Tick += new EventHandler(this.switchToRtsp2Timer_Tick);
                    t3.Enabled = false;
                    t3.Tag = idx;
                    t4 = new Timer();
                    t4.Tick += new EventHandler(this.lostRtsp2Timer_Tick);
                    t4.Enabled = false;
                    t4.Tag = idx;
                    t5 = new Timer();
                    t5.Tick += new EventHandler(this.switchToRtsp1Timer_Tick);
                    t5.Enabled = false;
                    t5.Tag = idx;
                    t6 = new Timer();
                    t6.Interval = stopRtsp1Timer;
                    t6.Tick += new EventHandler(this.stopRtsp1Timer_Tick);
                    t6.Enabled = false;
                    t6.Tag = idx;
                    t7 = new Timer();
                    t7.Interval = stopRtsp2Timer;
                    t7.Tick += new EventHandler(this.stopRtsp2Timer_Tick);
                    t7.Enabled = false;
                    t7.Tag = idx;
                    t8 = new Timer();
                    t8.Interval = stopOtherRtspTimer;
                    t8.Tick += new EventHandler(this.stopOtherRtspTimer_Tick);
                    t8.Enabled = false;
                    t8.Tag = idx;

                    vlc1 = new AxAXVLC.AxVLCPlugin2();
                    ((System.ComponentModel.ISupportInitialize)(vlc1)).BeginInit();
                    vlc1.Enabled = true;
                    vlc1.Dock = DockStyle.Fill;
                    vlc1.MediaPlayerPositionChanged += new AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEventHandler(vlcPositionChanged);
                    vlc1.MediaPlayerBuffering += new AxAXVLC.DVLCEvents_MediaPlayerBufferingEventHandler(this.vlc1Buffering);
                    vlc1.Tag = idx;
                    p0.Controls.Add(vlc1);
                    ((System.ComponentModel.ISupportInitialize)(vlc1)).EndInit();
                    vlc2 = new AxAXVLC.AxVLCPlugin2();
                    ((System.ComponentModel.ISupportInitialize)(vlc2)).BeginInit();
                    vlc2.Enabled = true;
                    vlc2.Dock = DockStyle.Fill;
                    vlc2.MediaPlayerPositionChanged += new AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEventHandler(vlc2PositionChanged);
                    vlc2.MediaPlayerBuffering += new AxAXVLC.DVLCEvents_MediaPlayerBufferingEventHandler(this.vlc2Buffering);
                    vlc2.Tag = idx;
                    vlc2.Visible = false;
                    p0.Controls.Add(vlc2);
                    ((System.ComponentModel.ISupportInitialize)(vlc2)).EndInit();

                    item = new grid1();
                    item.subPanel = p0;
                    item.vlc1 = vlc1;
                    item.vlc2 = vlc2;
                    item.topPanel = p1;
                    item.nameLabel = l1;
                    item.hideControlTimer = t1;
                    item.lostRtsp1Timer = t2;
                    item.switchToRtsp2Timer = t3;
                    item.lostRtsp2Timer = t4;
                    item.switchToRtsp1Timer = t5;
                    item.controlPanel = p2;
                    item.btnPlayStop = b1;
                    item.btnVolMinus = b2;
                    item.btnVolPlus = b3;
                    item.vlc1Status = VlcStatus.Stopped;
                    item.vlc2Status = VlcStatus.Stopped;
                    item.isSoundPresent = false;
                    item.stopRtsp1Timer = t6;
                    item.stopRtsp2Timer = t7;
                    item.stopOtherRtspTimer = t8;
                    item.idx = idx;
                    grid[x, y] = item;
                    gridline[idx] = item;
                    idx++;
                }
            }
        }

        private void fillMatrix()
        {
            grid1 c;
            string opt = null;//":no-audio"
            foreach (Camera m in appSet.cams)
                if ((gridline.Length > m.position) && (m.position >= 0))
                {
                    c = gridline[m.position];
                    c.vlc1.playlist.items.clear();
                    c.vlc1.playlist.add(m.rtspBad, null, opt);
                    c.nameLabel.Text = m.name;
                    c.cam = m;
                    c.vlcH = 0;
                    c.vlcW = 0;
                    c.vlc2.SendToBack();
                    c.isRtsp2Shown = false;
                    if (m.rtspGood != "" && m.rtspGood != null)
                    {
                        c.vlc2.playlist.items.clear();
                        c.vlc2.playlist.add(m.rtspGood, null, opt);
                    }
                    if (m.aspectRatio != "" && m.aspectRatio != null)
                    {
                        c.vlc1.video.aspectRatio = m.aspectRatio;
                        c.vlc2.video.aspectRatio = m.aspectRatio;
                    }
                }
            foreach (grid1 g in gridline) g.vlc1.Toolbar = false;
        }

        private void vlc1Buffering(object sender, AxAXVLC.DVLCEvents_MediaPlayerBufferingEvent e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Control).Tag)];
            if (c.vlc1Status == VlcStatus.Buffering)
            {
                if (c.vlc2Status == VlcStatus.Playing)
                {
                    c.vlc1.audio.Volume = 0;
                    return;
                }
                if (arg_unmute == 0) c.vlc1.audio.Volume = 0;
                if (c.vlc1.audio.track > 1)
                {
                    c.btnVolMinus.Visible = c.btnVolPlus.Visible = true;
                    c.isSoundPresent = c.vlc1.audio.track > 1;
                    Conrol_Show(c);
                }
            }
        }

        private void vlc2Buffering(object sender, AxAXVLC.DVLCEvents_MediaPlayerBufferingEvent e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Control).Tag)];
            if (c.vlc2Status == VlcStatus.Buffering)
            {
                c.vlc2.audio.Volume = 0;
            }
        }

        private void vlcPositionChanged(object sender, AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEvent e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Control).Tag)];
            c.lostRtsp1Timer.Enabled = false;
            c.lostRtsp1Timer.Enabled = true;
            if (c.vlc1Status == VlcStatus.Buffering)
            {
                c.vlc1Status = VlcStatus.Playing;
                c.lostRtsp1Timer.Interval = Convert.ToInt32(Properties.Resources.lostRtspTimer);
                c.switchToRtsp1Timer.Interval = 500;
                c.switchToRtsp1Timer.Enabled = true;
                hideControlTimer_Tick(c.hideControlTimer, null);
            }
            if (c.isRtsp2Shown) return;
            if (c.vlcH == 0 && c.vlc1.video.height > 0)
            {
                c.vlcH = c.vlc1.video.height;
                c.vlcW = c.vlc1.video.width;
            }
            if (c.vlcH > 0 && !c.switchToRtsp2Timer.Enabled && !(c.vlc2Status == VlcStatus.Buffering || c.vlc2Status == VlcStatus.Preparing) && c.vlc1.Height > c.vlcH * Convert.ToInt32(Properties.Resources.switchToGoodRtspPercent) / 100)
            {
                if (c.vlc2Status == VlcStatus.Playing)
                {
                    c.switchToRtsp2Timer.Interval = 50;
                    hideControlTimer_Tick(c.hideControlTimer, null);
                }
                else
                {
                    c.vlc2Status = VlcStatus.Preparing;
                    c.switchToRtsp2Timer.Interval = Convert.ToInt32(Properties.Resources.switchToGoodRtspTimer);
                }
                c.switchToRtsp2Timer.Enabled = true;
            }
        }

        private void vlc2PositionChanged(object sender, AxAXVLC.DVLCEvents_MediaPlayerPositionChangedEvent e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Control).Tag)];
            c.lostRtsp2Timer.Enabled = false;
            c.lostRtsp2Timer.Enabled = true;
            if (c.vlc2Status == VlcStatus.Buffering)
            {
                c.vlc2Status = VlcStatus.Playing;
                c.lostRtsp2Timer.Interval = Convert.ToInt32(Properties.Resources.lostGoodRtspTimer);
                c.switchToRtsp2Timer.Interval = 500;
                c.switchToRtsp2Timer.Enabled = true;
                hideControlTimer_Tick(c.hideControlTimer, null);
            }
            if (!c.isRtsp2Shown) return;
            if (c.vlcH > 0 && c.vlc1.Height <= c.vlcH && !c.switchToRtsp1Timer.Enabled && !(c.vlc1Status == VlcStatus.Buffering || c.vlc1Status == VlcStatus.Preparing))
            {
                if (c.vlc1Status == VlcStatus.Playing)
                {
                    c.switchToRtsp1Timer.Interval = 50;
                    hideControlTimer_Tick(c.hideControlTimer, null);
                }
                else
                {
                    c.vlc1Status = VlcStatus.Preparing;
                    c.switchToRtsp1Timer.Interval = Convert.ToInt32(Properties.Resources.switchToBadRtspTimer);
                }
                c.switchToRtsp1Timer.Enabled = true;
            }
        }

        private void hideControlTimer_Tick(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Timer).Tag)];
            c.hideControlTimer.Enabled = false;
            c.nameLabel.Visible = false;
            c.controlPanel.Visible = false;
        }

        private void lostRtsp1Timer_Tick(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Timer).Tag)];
            c.lostRtsp1Timer.Enabled = false;
            if (c.vlc1Status == VlcStatus.Playing)
            {
                c.vlc2.playlist.stop();
                c.vlc2Status = VlcStatus.Stopped;
                c.vlc2.SendToBack();
                c.isRtsp2Shown = false;
            }
        }

        private void lostRtsp2Timer_Tick(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Timer).Tag)];
            c.lostRtsp2Timer.Enabled = false;
            if (c.vlc2Status == VlcStatus.Playing)
            {
                c.vlc2.playlist.stop();
                c.vlc2Status = VlcStatus.Stopped;
                c.vlc2.SendToBack();
                c.isRtsp2Shown = false;
            }
        }

        private void Conrol_Show(grid1 c)
        {
            c.nameLabel.Visible = true;
            c.controlPanel.Visible = true;
            c.hideControlTimer.Enabled = false;
            c.hideControlTimer.Enabled = true;
        }

        private void TransparentPanel_MouseEnter(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Control).Tag)];
            Conrol_Show(c);
        }
        
        public Bitmap InvertImage(Image source)
        {
            Bitmap newBitmap = new Bitmap(source.Width, source.Height);
            Graphics g = Graphics.FromImage(newBitmap);
            System.Drawing.Imaging.ColorMatrix colorMatrix = new System.Drawing.Imaging.ColorMatrix(
               new float[][]
               {
                  new float[] {-1, 0, 0, 0, 0},
                  new float[] {0, -1, 0, 0, 0},
                  new float[] {0, 0, -1, 0, 0},
                  new float[] {0, 0, 0, 1, 0},
                  new float[] {1, 1, 1, 0, 1}
               });
            colorMatrix.Matrix00 = colorMatrix.Matrix11 = colorMatrix.Matrix22 = -1f;
            colorMatrix.Matrix33 = colorMatrix.Matrix44 = 1f;
            System.Drawing.Imaging.ImageAttributes attributes = new System.Drawing.Imaging.ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(source, new Rectangle(0, 0, source.Width, source.Height),
                        0, 0, source.Width, source.Height, GraphicsUnit.Pixel, attributes);
            g.Dispose();
            return newBitmap;
        }

        private void btn_MouseEnterLeaveInvert(object sender, EventArgs e)
        {
            (sender as Panel).BackgroundImage = InvertImage((sender as Panel).BackgroundImage);
        }

        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point l = (sender as Panel).Location;
                l.X += 1;
                l.Y += 1;
                (sender as Panel).Location = l;
            }
        }

        private void btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point l = (sender as Panel).Location;
                l.X -= 1;
                l.Y -= 1;
                (sender as Panel).Location = l;
            }
        }

        private void btnPlay_MouseClick(object sender, MouseEventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Control).Tag)];
            Conrol_Show(c);
            if (c.cam == null) return;
            if (c.vlc1Status == VlcStatus.Stopped)
            {
                c.lostRtsp1Timer.Interval = Convert.ToInt32(Properties.Resources.lostRtspOnStartTimer);
                c.lostRtsp1Timer.Enabled = true;
                c.vlc1Status = VlcStatus.Buffering;
                c.vlc1.playlist.play();
                c.btnPlayStop.BackgroundImage = e != null ? InvertImage(Properties.Resources.btn_stop) : Properties.Resources.btn_stop;
            }
            else
            {
                c.lostRtsp1Timer.Enabled = false;
                c.vlc1Status = VlcStatus.Stopped;
                c.vlc1.playlist.stop();
                c.btnPlayStop.BackgroundImage = e != null ? InvertImage(Properties.Resources.btn_play) : Properties.Resources.btn_play;
            }
        }

        private void TransparentPanel_DoubleClick(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Control).Tag)];
            if (c.subPanel.Dock == DockStyle.Fill)
            {
                c.subPanel.Dock = DockStyle.None;
                Form1_Resize(this, null);
                c.stopOtherRtspTimer.Enabled = false;
                foreach (grid1 g in gridline) if (g.idx != c.idx && g.vlc1Status == VlcStatus.Playing)
                    {
                        if (g.isSoundPresent && g.vlc1.Volume > 0) continue;
                        g.vlc2.playlist.stop();
                        g.vlc2Status = VlcStatus.Stopped;
                        g.vlc1.playlist.stop();
                        g.vlc1Status = VlcStatus.Stopped;
                        g.isRtsp2Shown = false;
                    }
            }
            else
            {
                c.subPanel.Dock = DockStyle.Fill;
                c.subPanel.BringToFront();
                c.stopOtherRtspTimer.Enabled = true;
            }
        }

        private void btnVolMinus_Click(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Control).Tag)];
            c.vlc1.Volume -= Math.Max(20, c.vlc1.Volume / 4);//25 if 100
            Conrol_Show(c);
        }

        private void btnVolPlus_Click(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Control).Tag)];
            c.vlc1.Volume += Math.Max(20, c.vlc1.Volume / 3);//30 if 90
            Conrol_Show(c);
        }

        private void switchToRtsp2Timer_Tick(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Timer).Tag)];
            c.switchToRtsp2Timer.Enabled = false;
            c.stopRtsp2Timer.Enabled = false;
            if (c.vlc2Status == VlcStatus.Playing)
            {
                c.vlc1.SendToBack();
                c.isRtsp2Shown = true;
                c.stopRtsp1Timer.Enabled = true;
                c.vlc2.audio.Volume = c.vlc1.audio.Volume;
            }
            else if (c.vlc2.playlist.items.count > 0)
            {
                c.vlc2.SendToBack();
                c.isRtsp2Shown = false;
                c.vlc2.Visible = true;
                c.lostRtsp2Timer.Interval = Convert.ToInt32(Properties.Resources.lostGoodRtspOnStartTimer);
                c.lostRtsp2Timer.Enabled = true;
                c.vlc2Status = VlcStatus.Buffering;
                c.vlc2.playlist.play();
            }
        }

        private void switchToRtsp1Timer_Tick(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Timer).Tag)];
            c.switchToRtsp1Timer.Enabled = false;
            c.stopRtsp1Timer.Enabled = false;
            if (c.vlc1Status == VlcStatus.Playing)
            {
                c.vlc2.SendToBack();
                c.isRtsp2Shown = false;
                c.stopRtsp2Timer.Enabled = true;
                c.vlc1.audio.Volume = c.vlc2.audio.Volume;
            }
            else
            {
                c.vlc1.SendToBack();
                c.isRtsp2Shown = true;
                c.vlc1.Visible = true;
                c.lostRtsp1Timer.Interval = Convert.ToInt32(Properties.Resources.lostGoodRtspOnStartTimer);
                c.lostRtsp1Timer.Enabled = true;
                c.vlc1Status = VlcStatus.Buffering;
                c.vlc1.playlist.play();
            }
        }

        private void stopRtsp1Timer_Tick(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Timer).Tag)];
            c.stopRtsp1Timer.Enabled = false;
            //if (!c.isRtsp2Shown) return;
            c.vlc1.playlist.stop();
            c.vlc1Status = VlcStatus.Stopped;
        }

        private void stopRtsp2Timer_Tick(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Timer).Tag)];
            c.stopRtsp2Timer.Enabled = false;
            //if (c.isRtsp2Shown) return;
            c.vlc2.playlist.stop();
            c.vlc2Status = VlcStatus.Stopped;
        }

        private void stopOtherRtspTimer_Tick(object sender, EventArgs e)
        {
            grid1 c = gridline[Convert.ToInt32((sender as Timer).Tag)];
            c.stopOtherRtspTimer.Enabled = false;
            foreach (grid1 g in gridline) if (g.idx != c.idx)
                {
                    if (g.isSoundPresent && g.vlc1.Volume > 0) continue;
                    if (g.vlc2Status == VlcStatus.Playing) g.vlc1Status = VlcStatus.Playing;
                    g.vlc2Status = VlcStatus.Stopped;
                    g.vlc2.playlist.stop();
                    g.vlc1.playlist.stop();
                    g.stopRtsp1Timer.Enabled = false;
                    g.stopRtsp2Timer.Enabled = false;
                    g.switchToRtsp1Timer.Enabled = false;
                    g.switchToRtsp2Timer.Enabled = false;
                    g.lostRtsp1Timer.Enabled = false;
                    g.lostRtsp2Timer.Enabled = false;
                    g.isRtsp2Shown = false;
                }
        }
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