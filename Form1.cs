using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

/********************
 * TODO:
 * Fill "Options" Tab (matrix dimensions, start with windows?, parameters on start with windows, parameters on start)
 * 
 ********************/

public enum HintType { None = 0, OpenCtrl = 1, AddCamera = 2, DropCamera = 3, NewRTSP1 = 5, NewRTSP2 = 6};

namespace RTSP_mosaic_VLC_player
{
    public partial class Form1 : Form
    {
        FormWindowState lastWindowState = FormWindowState.Minimized;
        appSettings appSet;
        int arg_unmute;
        int fullScrIdx;
        RtspBadGoodControl[] gridline;
        RtspBadGoodControl[,] grid;
        ImageList cameraIconsImageList2 = new System.Windows.Forms.ImageList();
        ImageList cameraIconsImageList3 = new System.Windows.Forms.ImageList();
        bool hideCtrlPanelAfterEdit;

        public class appSettings
        {
            public int screen = -1; // screen number to open window on start
            public int fullscreen = 0; // expand window: 0-no, 1-yes
            public int autoplay = 0; // auto start all sources: 0-no, 1-auto play
            public int priority = -1; // application base priority: 0-Idle, 1-BelowNormal, 2-Normal, 3-AboveNormal, 4-High
            public int unmute = 0; // do not mute audio: 0-silent, 1-enable sounds
            public int controlPanelWidth = 0; // width of control panel

            public matrix matrix = new matrix(); // matrix parameters (rows and columns count)

            [System.Xml.Serialization.XmlArrayItem(ElementName = "cam", Type = typeof(Camera))]
            public Camera[] cams;
        }

        public class matrix
        {
            public int cntX = 2;
            public int cntY = 2;
        }

        public bool appSettingsLoad()
        {
            if (appSet == null) appSet = new appSettings();
            if (!System.IO.File.Exists(Properties.Resources.settingsFileName)) return true;
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
                MessageBox.Show(errorLoadSettings.Text + "\n" + Properties.Resources.settingsFileName, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(errorSaveSettings.Text + "\n" + Properties.Resources.settingsFileName, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public Form1()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            int i;

            #if !DEBUG
            appSettingsLoad();
            #endif
            if (appSet == null) appSet = new appSettings();
            if (appSet.cams == null) appSet.cams = new Camera[0];
            #if DEBUG
            if (appSet.cams == null || appSet.cams.Length == 0)
            {
                Camera c1 = new Camera(), c2 = new Camera(), c3 = new Camera(), c4 = new Camera();
                //c1.rtspGood = "rtsp://admin:1111@192.168.40.4:554/live/main"; c2.rtspGood = c1.rtspGood; c3.rtspGood = c1.rtspGood; c4.rtspGood = c1.rtspGood;
                //c1.rtspBad = "rtsp://admin:1111@192.168.40.4:554/live/sub"; c2.rtspBad = c1.rtspBad; c3.rtspBad = c1.rtspBad; c4.rtspBad = c1.rtspBad;
                c1.position = 0; c2.position = 1; c3.position = 2; c4.position = 3;
                c1.rtspBad = "rtsp://op:rock@46.254.25.8:10554/live/sub"; //c1.rtspGood = "rtsp://op:rock@46.254.25.8:10554/live/main";
                c2.rtspBad = "rtsp://op:rand@46.254.25.8:10555/live/sub"; //c2.rtspGood = "rtsp://op:rand@46.254.25.8:10555/live/main";
                c3.rtspBad = "rtsp://46.254.25.8:10556/av0_1&user=op&password=musc"; //c3.rtspGood = "rtsp://46.254.25.8:10556/av0_0&user=op&password=musc";
                c4.rtspBad = "rtsp://46.254.25.8:10557/av0_1&user=op&password=metl"; //c4.rtspGood = "rtsp://46.254.25.8:10557/av0_0&user=op&password=metl";
                c1.name = "Холл1"; c2.name = "Холл2"; c3.name = "Улица1"; c4.name = "Улица2";
                Camera[] c= { c1, c2, c3, c4 };
                appSet.cams = c;
            }
            #endif
            if (appSet.controlPanelWidth > splitter1.MinSize) ctrlPanel.Width = appSet.controlPanelWidth;
            i = 0;
            camerasListView.Clear();
            foreach (Camera m in appSet.cams)
            {
                camerasListView.Items.Add(m.name, m.camIcon);
                camerasListView.Items[i].Tag = m;
                i++;
            }

            if (createMatrix())
            {
                fillMatrix();

                cameraIconsImageList2.Images.Clear();
                cameraIconsImageList2.ImageSize = new Size(50, 50);
                cameraIconsImageList3.Images.Clear();
                cameraIconsImageList3.ImageSize = new Size(25, 25);
                camerasIconListView.LargeImageList = cameraIconsImageList2;
                camerasIconListView.SmallImageList = cameraIconsImageList2;
                camerasIconListView.TileSize = new Size(camerasIconListView.LargeImageList.ImageSize.Width + 10, camerasIconListView.LargeImageList.ImageSize.Height + 2);
                foreach (string ikey in cameraIconsImageList.Images.Keys)
                {
                    i = cameraIconsImageList.Images.IndexOfKey(ikey);
                    cameraIconsImageList2.Images.Add(ikey, (Bitmap)cameraIconsImageList.Images[i]);
                    cameraIconsImageList3.Images.Add(ikey, (Bitmap)cameraIconsImageList.Images[i]);
                    camerasIconListView.Items.Add("", i);
                }

                splitLabel_MouseLeave(null, null);
                //typeViewStripMenuItem_Click(1);
                sortToolStripMenuItem_Click(3);
                splitter1_SplitterMoved(null, null);

                string[] args = Environment.GetCommandLineArgs();
                //fullscreen screen=1 autoplay unmute priority=0
                int screen = appSet.screen, fullscreen = appSet.fullscreen, autoplay = appSet.autoplay, priority = appSet.priority;
                bool f;
                for (i = 0; i < args.Length; i++)
                {
                    if (args[i].Length >= 10) if (args[i].Substring(0, 10).Equals("fullscreen")) if (args[i].Length > 10) f = int.TryParse(args[i].Substring(11), out fullscreen); else fullscreen = 1;
                    if (args[i].Length >= 8) if (args[i].Substring(0, 8).Equals("autoplay")) if (args[i].Length > 8) f = int.TryParse(args[i].Substring(9), out autoplay); else autoplay = 1;
                    if (args[i].Length >= 8) if (args[i].Substring(0, 8).Equals("priority")) if (args[i].Length > 8) f = int.TryParse(args[i].Substring(9), out priority);
                    if (args[i].Length >= 6) if (args[i].Substring(0, 6).Equals("unmute")) if (args[i].Length > 6) f = int.TryParse(args[i].Substring(7), out arg_unmute); else arg_unmute = 1;
                    if (args[i].Length >= 6) if (args[i].Substring(0, 6).Equals("screen")) if (args[i].Length > 6) f = int.TryParse(args[i].Substring(7), out screen);
                }

                Screen[] sc = Screen.AllScreens;
                if (screen > -1 && sc.Length > screen)
                {
                    this.Location = new Point(sc[screen].Bounds.Location.X, sc[screen].Bounds.Location.Y);
                    this.Size = new Size(sc[screen].Bounds.Width, sc[screen].Bounds.Height);
                }
                if (fullscreen > 0)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                if (autoplay > 0)
                    foreach (RtspBadGoodControl c in gridline) if (c.isCameraSet) c.play(this);
                if (priority >= 0)
                    switch (priority)
                    {
                        case 0: System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Idle; break;
                        case 1: System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.BelowNormal; break;
                        case 2: System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.Normal; break;
                        case 3: System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.AboveNormal; break;
                        case 4: System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High; break;
                    }
                this.Text = Application.ProductName + " " + Application.ProductVersion
                    + "  /  gg81@ya.ru  /  "
                    + (Application.CurrentCulture.TwoLetterISOLanguageName == "ru" ? "решениеготово.рф  /  Григорий Лобков" : "Gregory Lobkov");
                Form1_ResizeEnd(null, null);
                showHintTimer.Tag = 0;
                f = true;
                foreach (RtspBadGoodControl c in gridline) if (c.isCameraSet) f = false;
                if (f) showHintWithWait(HintType.OpenCtrl);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grid == null) return;
            foreach (RtspBadGoodControl c in gridline) c.Dispose();
            appSettingsSave();
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            for (int x = 0; x < appSet.matrix.cntX; x++)
                for (int y = 0; y < appSet.matrix.cntY; y++) if (grid[x, y] != null)
                        grid[x, y].resizeEnd(this);
            int s = Math.Min(Math.Max((camPanel.ClientRectangle.Width + (sender == null || ctrlPanel.Visible ? ctrlPanel.Width : 0)) / 70, 6), 18);
            splitLabel.Font = new Font(splitLabel.Font.Name, s, splitLabel.Font.Style, splitLabel.Font.Unit);
            splitLabel.Width = s;
            splitLabel.Height = s * 4;
            splitLabel.Top = (camPanel.ClientRectangle.Height - splitLabel.Height) / 2;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (fullScrIdx == -1)
            {
                int stepw = camPanel.ClientRectangle.Width / appSet.matrix.cntX,
                    steph = camPanel.ClientRectangle.Height / appSet.matrix.cntY;
                Size ps = new Size(stepw, steph);
                int xl = 0;
                if (grid != null)
                    for (int x = 0; x < appSet.matrix.cntX; x++)
                    {
                        for (int y = 0; y < appSet.matrix.cntY; y++) if (grid[x, y] != null)
                            {
                                grid[x, y].Location = new Point(xl, y * steph);
                                grid[x, y].Size = ps;
                            }
                        xl += stepw;
                    }
            }
            if (WindowState != lastWindowState)
            {
                lastWindowState = WindowState;
                Form1_ResizeEnd(this, null);
            }
        }

        private void commandLineHelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(commandLineHelp.Text, commandLineHelpButton.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Form1_Resize(this, null);
        }

        private bool createMatrix()
        {
            if (grid != null) // dispose of old data
                for (int x = grid.GetLowerBound(0); x <= grid.GetUpperBound(0); x++)
                    for (int y = grid.GetLowerBound(1); y <= grid.GetUpperBound(1); y++)
                        if (grid[x, y] != null) grid[x, y].Dispose();
            //TODO: не пересоздавать область, вновь видимую пользователем
            RtspBadGoodControl item;
            int idx = 0;
            grid = new RtspBadGoodControl[appSet.matrix.cntX, appSet.matrix.cntY];
            gridline = new RtspBadGoodControl[appSet.matrix.cntX * appSet.matrix.cntY];
            try
            {
                for (int y = 0; y < appSet.matrix.cntY; y++)
                    for (int x = 0; x < appSet.matrix.cntX; x++)
                    {
                        item = new RtspBadGoodControl();
                        item.Volume = arg_unmute == 0 ? 0 : 50;
                        item.MouseDoubleClick += new MouseEventHandler(this.RtspBadGoodControl_DoubleClick);
                        item.Tag = idx;
                        item.Visible = true;
                        item.AllowDrop = true;
                        item.DragDrop += new DragEventHandler(this.RtspBadGoodControl_DragDrop);
                        item.DragEnter += new DragEventHandler(this.RtspBadGoodControl_DragEnter);
                        item.onOptionsClick += new EventHandler(this.RtspBadGoodControl_OptionsClick);
                        this.camPanel.Controls.Add(item);
                        grid[x, y] = item;
                        gridline[idx] = item;
                        idx++;
                    }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                DialogResult a = MessageBox.Show(//ex.Message + "\n\n" + ex.StackTrace,
                    ex.Message + "\n\n" + errorInitVLCnoLib.Text + "\n\n" + errorInitVLC.Text,
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (a == DialogResult.Yes) System.Diagnostics.Process.Start(Properties.Resources.downloadVlcUrl);
                try { Environment.Exit(101); }
                catch { Application.Exit(); this.Close(); }
                return false;
            }
            catch (System.NotSupportedException ex)
            {
                DialogResult a = MessageBox.Show(ex.Message + "\n\n" + errorInitVLCbadLibVer.Text + "\n\n" + errorInitVLC.Text,
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (a == DialogResult.Yes) System.Diagnostics.Process.Start(Properties.Resources.downloadVlcUrl);
                try { Environment.Exit(101); }
                catch { Application.Exit(); this.Close(); }
                return false;
            }
            catch (Exception ex)
            {
                DialogResult a = MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n\n" + errorInitVLCbadLib.Text + "\n\n" + errorInitVLC.Text,
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (a == DialogResult.Yes) System.Diagnostics.Process.Start(Properties.Resources.downloadVlcUrl);
                try { Environment.Exit(101); }
                catch { Application.Exit(); this.Close(); }
                return false;
            }
            //Form1_ResizeEnd(this, null);
            fullScrIdx = -1;
            return true;
        }

        private void fillMatrix()
        {
            // clear windows, which won't be set
            bool f;
            for (int i = gridline.GetLowerBound(0); i <= gridline.GetUpperBound(0); i++)
            {
                f = true;
                foreach (Camera m in appSet.cams) if (m.position == i) { f = false; break; }
                if (f) gridline[i].resetCamera();
            }
            // show the cams, which is set
            foreach (Camera m in appSet.cams)
                if ((gridline.Length > m.position) && (m.position >= 0))
                    gridline[m.position].setCamera(m);
        }

        private void RtspBadGoodControl_DoubleClick(object sender, MouseEventArgs e)
        {
            int t = Convert.ToInt32((sender as Control).Tag);
            RtspBadGoodControl c = gridline[t];
            if (c.Dock == DockStyle.Fill)
            {
                c.Dock = DockStyle.None;
                for (int i = gridline.GetLowerBound(0); i <= gridline.GetUpperBound(0); i++)
                    if (i != t) gridline[i].Visible = true;
                fullScrIdx = -1;
                Form1_Resize(this, null);
            }
            else
            {
                c.Dock = DockStyle.Fill;
                c.BringToFront();
                splitLabel.BringToFront();
                for (int i = gridline.GetLowerBound(0); i <= gridline.GetUpperBound(0); i++)
                    if (i != t) gridline[i].Visible = false;
                fullScrIdx = t;
            }
            Form1_ResizeEnd(this, null);
        }

        private void splitLabel_MouseEnter(object sender, EventArgs e) { splitLabel.Left = splitter1.Visible ? splitter1.Width : 0; }

        private void splitLabel_MouseLeave(object sender, EventArgs e) { splitLabel.Left = (splitter1.Visible ? splitter1.Width : 0) - 3; }

        private void splitLabel_Click(object sender, EventArgs e)
        {
            ctrlPanel.Visible = !ctrlPanel.Visible;
            splitter1.Visible = ctrlPanel.Visible;
            splitLabel.Text = ctrlPanel.Visible ? "<<" : ">>";
            Form1_Resize(this, null);
            Form1_ResizeEnd(this, null);
            splitLabel.Left = (splitter1.Visible ? splitter1.Width : 0) - 6;
            if (ctrlPanel.Visible) showHintWithWait(HintType.AddCamera);
            else hideHintNow();
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            modifyCameraToolStripMenuItem.Enabled = camerasListView.SelectedItems.Count > 0;
            hideHintNow();
        }

        private void typeViewStripMenuItem_Click(int i)
        {
            camerasListView.LargeImageList = i < 2 ? cameraIconsImageList : i > 3 ? cameraIconsImageList3 : cameraIconsImageList2;
            camerasListView.SmallImageList = camerasListView.LargeImageList;
            camerasListView.View = i < 3 ? View.LargeIcon : View.List;
            largeIconsToolStripMenuItem.Checked = i == 1;
            smallIconsToolStripMenuItem.Checked = i == 2;
            largeListToolStripMenuItem.Checked = i == 3;
            smallListToolStripMenuItem.Checked = i == 4;
        }
        private void largeIconsToolStripMenuItem_Click(object sender, EventArgs e) { typeViewStripMenuItem_Click(1); }
        private void smallIconsToolStripMenuItem_Click(object sender, EventArgs e) { typeViewStripMenuItem_Click(2); }
        private void largeListToolStripMenuItem_Click(object sender, EventArgs e) { typeViewStripMenuItem_Click(3); }
        private void smallListToolStripMenuItem_Click(object sender, EventArgs e) { typeViewStripMenuItem_Click(4); }

        private void sortToolStripMenuItem_Click(int i)
        {
            camerasListView.Sorting = i == 1 ? SortOrder.Ascending : i == 2 ? SortOrder.Descending : SortOrder.None;
            ascendingToolStripMenuItem.Checked = i == 1;
            descendingToolStripMenuItem.Checked = i == 2;
            disabledToolStripMenuItem.Checked = i == 3;
        }
        private void ascendingToolStripMenuItem_Click(object sender, EventArgs e) { sortToolStripMenuItem_Click(1); }
        private void descendingToolStripMenuItem_Click(object sender, EventArgs e) { sortToolStripMenuItem_Click(2); }
        private void disabledToolStripMenuItem_Click(object sender, EventArgs e) { sortToolStripMenuItem_Click(3); }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Form1_Resize(this, null);
            Form1_ResizeEnd(this, null);
            appSet.controlPanelWidth = ctrlPanel.Width;
            //tabControl1.Invalidate(); camerasListView.Invalidate(); splitLabel.Invalidate(); // if splitter1_SplitterMoving()
        }

        private void splitter1_SplitterMoving(object sender, SplitterEventArgs e) { /*Form1_Resize(this,null);ctrlPanel.Width=e.SplitX;*/ }

        private void newCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editCamPanel.Visible = true;
            editCamPanel.BringToFront();
            delCamLabel.Visible = false;
            if (camNameTextBox.ForeColor == SystemColors.WindowText)
            {
                camNameTextBox.Text = "";
                rtsp1TextBox.Text = "";
                rtsp2TextBox.Text = "";
            }
            camerasIconListView.Items[0].Focused = true;
            camerasIconListView.Items[0].Selected = true;
            aspectRatioTextBox.Text = Properties.Resources.defaultAspectRatio;
            rtsp1TextBox.Tag = null;
            if (hintAddCamera.Visible) hideHintNow();
            hideCtrlPanelAfterEdit = false;
        }

        private void modifyCameraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editCamPanel.Visible = true;
            editCamPanel.BringToFront();
            delCamLabel.Visible = true;
            Camera m = (Camera)(camerasListView.FocusedItem.Tag);
            camNameTextBox.Text = m.name;
            rtsp1TextBox.Text = m.rtspBad;
            rtsp2TextBox.Text = m.rtspGood;
            if (camNameTextBox.ForeColor != SystemColors.WindowText)
            {
                camNameTextBox.ForeColor = SystemColors.WindowText;
                rtsp1TextBox.ForeColor = SystemColors.WindowText;
                rtsp2TextBox.ForeColor = SystemColors.WindowText;
            }
            camerasIconListView.Items[m.camIcon].Focused = true;
            camerasIconListView.Items[m.camIcon].Selected = true;
            aspectRatioTextBox.Text = m.aspectRatio;
            rtsp1TextBox.Tag = m;
            hideCtrlPanelAfterEdit = false;
        }

        private void delCamLabel_Click(object sender, EventArgs e)
        {
            if (rtsp1TextBox.Text == "" && rtsp2TextBox.Text == "")
                if (MessageBox.Show(cameraDeleteConfirm1.Text + " ''" + camNameTextBox.Text + "''?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != DialogResult.Yes) return;
            if (rtsp1TextBox.Tag == null) cancelCamButton_Click(null, null);
            else
            {
                Camera m = (Camera)(rtsp1TextBox.Tag);
                if (m.position >= 0) {
                    if (MessageBox.Show(cameraDeleteConfirm2.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        != DialogResult.Yes) return;
                    gridline[m.position].resetCamera();
                    m.position = -1;
                }
                camerasListView.FocusedItem.Remove();
                appSet.cams = Array.FindAll(appSet.cams, x => x != m);
                cancelCamButton_Click(null, null);
            }
        }

        private void saveCamButton_Click(object sender, EventArgs e)
        {
            Camera m = (Camera)(rtsp1TextBox.Tag);
            if (m == null) {
                int l = appSet.cams.Length;
                Array.Resize(ref appSet.cams, l+1);
                m = new Camera();
                appSet.cams[l] = m;
                ListViewItem vi = new ListViewItem();
                camerasListView.Items.Add(vi);
                vi.Focused = true;
                vi.Selected = true;
                vi.Tag = m;
            }
            RtspBadGoodControl c = m.position >= 0 ? gridline[m.position] : null;
            if(m.name != camNameTextBox.Text) { 
                m.name = camNameTextBox.Text;
                camerasListView.FocusedItem.Text = m.name;
                if(c != null) c.Title=m.name;
            }
            if(m.camIcon != camerasIconListView.FocusedItem.Index) {
                m.camIcon = camerasIconListView.FocusedItem.Index;
                camerasListView.FocusedItem.ImageIndex = m.camIcon;
            }
            if(m.rtspBad != rtsp1TextBox.Text || m.rtspGood != rtsp2TextBox.Text || m.aspectRatio != aspectRatioTextBox.Text)
            {
                m.rtspBad = rtsp1TextBox.Text;
                m.rtspGood = rtsp2TextBox.Text;
                m.aspectRatio = aspectRatioTextBox.Text;
                if (c != null) {
                    VlcStatus s=c.Status;
                    c.setCamera(m);
                    if (s != VlcStatus.Stopped) c.play(this);
                }
            }
            cancelCamButton_Click(null, null);
        }

        private void cancelCamButton_Click(object sender, EventArgs e)
        {
            hideHintNow();
            editCamPanel.SendToBack();
            editCamPanel.Visible = false;
            if (camerasListView.Items.Count == 0) showHintWithWait(HintType.AddCamera);
            else
            {
                bool f = true;
                foreach (RtspBadGoodControl c in gridline) if (c.isCameraSet) f = false;
                if (f) showHintWithWait(HintType.DropCamera);
                else if (hideCtrlPanelAfterEdit)
                {
                    ctrlPanel.Visible = false;
                    Form1_Resize(this, null);
                    Form1_ResizeEnd(this, null);
                }
            }
        }

        private void camerasListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == "" || e.Label == null) { e.CancelEdit = true; return; }
            Camera m = (Camera)(camerasListView.FocusedItem.Tag);
            m.name = e.Label;
            gridline[m.position].Title = m.name;
        }

        private void camerasListView_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(typeof(Camera))) e.Effect = DragDropEffects.Move; else e.Effect = DragDropEffects.None;
            e.Effect = e.Data.GetDataPresent(typeof(Camera)) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void camerasListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ListViewItem vi = camerasListView.GetItemAt(e.X, e.Y);
            if (vi == null) return;
            vi.Focused = true;
            vi.Selected = true;
            camerasListView.DoDragDrop((Camera)(camerasListView.FocusedItem.Tag), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void RtspBadGoodControl_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetData(typeof(Camera)) != null)
            {
                Camera m = (Camera)(e.Data.GetData(typeof(Camera)));
                if (m != null)
                {
                    int t = Convert.ToInt32((sender as Control).Tag);
                    RtspBadGoodControl c = gridline[t];
                    if (m.position >= 0) gridline[m.position].resetCamera();
                    foreach (Camera v in appSet.cams) if (v.position == t) v.position = -1;
                    m.position = t;
                    gridline[t].setCamera(m);
                    gridline[t].play(this);
                    if (hintDropCamera.Visible) hideHintNow();
                }
            }
        }

        private void RtspBadGoodControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Camera))) e.Effect = DragDropEffects.Copy;
        }

        private void RtspBadGoodControl_OptionsClick(object sender, EventArgs e)
        {
            Camera n = (sender as RtspBadGoodControl).camera;
            int i = camerasListView.Items.Count - 1;
            for (; i >= 0; i--) 
                if (camerasListView.Items[i].Tag == n)
                {
                    bool autoHide = !ctrlPanel.Visible;
                    ctrlPanel.Visible = true;
                    tabControl1.SelectedTab = tabPage1;
                    camerasListView.Items[i].Focused = true;
                    camerasListView.Items[i].Selected = true;
                    modifyCameraToolStripMenuItem_Click(null, null);
                    hideCtrlPanelAfterEdit = autoHide;
                    Form1_Resize(this, null);
                    Form1_ResizeEnd(this, null);
                    break;
                }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://решениеготово.рф");
            (sender as LinkLabel).LinkVisited = true;
        }

        private void showHintTimer_Tick(object sender, EventArgs e)
        {
            showHintTimer.Enabled = false;
            switch ((int)(showHintTimer.Tag))
            {
                case (int)HintType.OpenCtrl:
                    hintOpenCtrl.Location = new Point(splitLabel.Location.X + splitLabel.Width + 4, splitLabel.Location.Y + 5);
                    hintOpenCtrl.Visible = true;
                    splitLabel.BackColor = Color.Red;
                    break;
                case -(int)HintType.OpenCtrl:
                    hintOpenCtrl.Visible = false;
                    splitLabel.BackColor = SystemColors.ControlDark;
                    break;
                case (int)HintType.AddCamera:
                    hintAddCamera.Parent = camerasListView;
                    hintAddCamera.Location = new Point(15,15);
                    hintAddCamera.Visible = true;
                    newCameraToolStripMenuItem.BackColor = Color.Red;
                    break;
                case -(int)HintType.AddCamera:
                    hintAddCamera.Visible = false;
                    newCameraToolStripMenuItem.BackColor = SystemColors.Control;
                    break;
                case (int)HintType.DropCamera:
                    hintDropCamera.Location = new Point(40,30);
                    hintDropCamera.Visible = true;
                    break;
                case -(int)HintType.DropCamera: hintDropCamera.Visible = false; break;
                case (int)HintType.NewRTSP1:
                    hintRTSP1.Location = new Point(7, rtsp1TextBox.Location.Y + 30);
                    hintRTSP1.Visible = true;
                    break;
                case -(int)HintType.NewRTSP1: hintRTSP1.Visible = false; break;
                case (int)HintType.NewRTSP2:
                    hintRTSP2.Location = new Point(7, rtsp2TextBox.Location.Y + 30);
                    hintRTSP2.Visible = true;
                    break;
                case -(int)HintType.NewRTSP2: hintRTSP2.Visible = false; break;
                default: break;
            }
            if ((int)showHintTimer.Tag <= 0) showHintTimer.Tag = 0;
            else
            {
                showHintTimer.Interval = 30000;
                showHintTimer.Tag = -(int)showHintTimer.Tag;
                if ((int)showHintTimer.Tag < 0) showHintTimer.Enabled = true;
            }
        }

        private void camNameTextBox_Enter(object sender, EventArgs e)
        {
            if(camNameTextBox.ForeColor!=SystemColors.WindowText) {
                camNameTextBox.ForeColor = SystemColors.WindowText;
                camNameTextBox.Text = "";
            }
        }
        private void rtsp1TextBox_Enter(object sender, EventArgs e)
        {
            if (rtsp1TextBox.ForeColor != SystemColors.WindowText)
            {
                rtsp1TextBox.ForeColor = SystemColors.WindowText;
                rtsp1TextBox.Text = "";
            }
            bool f = true;
            foreach (RtspBadGoodControl c in gridline) if (c.isCameraSet) f = false;
            if (f) showHintWithWait(HintType.NewRTSP1);
        }
        private void rtsp2TextBox_Enter(object sender, EventArgs e)
        {
            if (rtsp2TextBox.ForeColor != SystemColors.WindowText)
            {
                rtsp2TextBox.ForeColor = SystemColors.WindowText;
                rtsp2TextBox.Text = "";
            }
            bool f = true;
            foreach (RtspBadGoodControl c in gridline) if (c.isCameraSet) f = false;
            if (f) showHintWithWait(HintType.NewRTSP2);
        }
        private void showHintWithWait(HintType hintType)
        {
            if ((int)showHintTimer.Tag < 0) showHintTimer_Tick(null, null);
            showHintTimer.Interval = Convert.ToInt32(Properties.Resources.showHintTimer);
            showHintTimer.Tag = hintType;
            showHintTimer.Enabled = false;
            showHintTimer.Enabled = true;
        }
        private void hideHintNow()
        {
            if ((int)showHintTimer.Tag < 0) showHintTimer_Tick(null, null);
            else showHintTimer.Enabled = false;
        }
    }
    public class Camera
    {
        public string name = "";
        public string rtspBad = "";
        public string rtspGood = "";
        public string aspectRatio = Properties.Resources.defaultAspectRatio;//"auto"
        public int camIcon = 1;
        public int position = -1;
        //[System.Xml.Serialization.XmlIgnoreAttribute]
    }
}