using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

/********************
 * Copyright 2018 Grigory Lobkov
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 *
 * You may obtain a copy of the License at
 * https://github.com/grigory-lobkov/rtsp-camera-view/blob/master/LICENSE
 *
 *
 * TODO
 * Fill "Options" Tab (start with windows?, parameters on start with windows, parameters on start)
 * Alert e-mail when picture is disappeared.
 * When in Full Screen, remove the title bar and borders to have only the black background with the cameras?
When full screen it could be interested also if the little button for settings disappear after some seconds, and re-appear if the mouse cursor goes over it.
In this way, when full screen, only the cameras are on the screen.
 * When camera prepared too long, restart source (recreate vlc?)
 *
 * BUGS
 * When one VLC is preparing(many cameras), can't close window, or stop source
 * 
 * MEMO
 * Localization: go to designer of form, choose object "Form", check parameter "Localizable=true",
 * modify parameter "Language" to desired language to translate to
 *
 ********************/

public enum HintType { None = 0, OpenCtrl = 1, AddCamera = 2, DropCamera = 3, NewRTSP1 = 5, NewRTSP2 = 6 };
public enum TextPosition { TopLeft = 1, TopCenter = 2, TopRight = 3, BottomLeft = 4, BottomCenter = 5, BottomRight = 6 };

namespace RTSP_mosaic_VLC_player
{
    public partial class MainForm : Form
    {
        FormWindowState lastWindowState = FormWindowState.Minimized;
        AppSettings appSet;
        int arg_unmute;
        int fullScrIdx;
        RtspBadGoodControl[] gridline;
        RtspBadGoodControl[,] grid;
        ImageList cameraIconsImageList2 = new System.Windows.Forms.ImageList();
        ImageList cameraIconsImageList3 = new System.Windows.Forms.ImageList();
        bool hideCtrlPanelAfterEdit;
        private CamNameConfigForm camNameConfigForm = null;
        private Camera editCamera;
        private Point MouseDownPoint;
        private bool MouseDownFlag;
        private int maxCamShown = 0;
        private int maxKbTaken = 0;
        private int lastRestartedCamera = -1;



        /*************************************************************************************************
         *
         *                                      Main form methods
         *
         *************************************************************************************************/


        private bool AppSettingsLoad()
        {
            if (appSet == null) appSet = new AppSettings();
            if (!System.IO.File.Exists(Properties.Resources.settingsFileName)) return true;
            try
            {
                using (System.IO.Stream stream = new System.IO.FileStream(Properties.Resources.settingsFileName, System.IO.FileMode.Open))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(AppSettings));
                    appSet = (AppSettings)serializer.Deserialize(stream);
                }
            }
            catch
            {
                MessageBox.Show(errorLoadSettings.Text + "\n" + Properties.Resources.settingsFileName, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (appSet == null) appSet = new AppSettings();
                return false;
            }
            return true;
        }

        private bool AppSettingsSave()
        {
            if (appSet == null) return false;
            try
            {
                using (System.IO.Stream writer = new System.IO.FileStream(Properties.Resources.settingsFileName, System.IO.FileMode.Create))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(AppSettings));
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

        public MainForm()
        {
            InitializeComponent();
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            int i;

            #if !DEBUG
            appSettingsLoad();
            #endif
            if (appSet == null) appSet = new AppSettings();
#if DEBUG
            if (appSet.cams == null || appSet.cams.Length == 0)
            {
                Camera c1 = new Camera()
                {
                    rtspGood = "rtsp://admin:a256@192.168.40.18:554/live/main",
                    rtspBad = "rtsp://admin:a256@192.168.40.18:554/live/sub",
                    position = 0,
                    name = "TSC-1"
                }, c2 = new Camera()
                {
                    rtspGood = "rtsp://admin:a256@192.168.40.19:554/live/main",
                    rtspBad = "rtsp://admin:a256@192.168.40.19:554/live/sub",
                    position = 1,
                    name = "TSC-2"
                }, c3 = new Camera()
                {
                    rtspGood = "rtsp://admin:a256@192.168.40.20:554/live/main",
                    rtspBad = "rtsp://admin:a256@192.168.40.20:554/live/sub",
                    position = 2,
                    name = "TSC-3"
                }, c4 = new Camera()
                {
                    rtspGood = "rtsp://admin:a256@192.168.40.5:554/live/main",
                    rtspBad = "rtsp://admin:a256@192.168.40.5:554/live/sub",
                    position = 3,
                    name = "TSC-4"
                }, c5 = new Camera()
                {
                    rtspGood = "rtsp://admin:a256@192.168.40.9:554/live/main",
                    rtspBad = "rtsp://admin:a256@192.168.40.9:554/live/sub",
                    position = 4,
                    name = "TSC-5"
                },
                c6 = new Camera()
                {
                    rtspGood = "rtsp://admin:a256@192.168.40.12:554/live/main",
                    rtspBad = "rtsp://admin:a256@192.168.40.12:554/live/sub",
                    position = 5,
                    name = "TSC-6"
                }, c7 = new Camera()
                {
                    rtspGood = "rtsp://admin:a256@192.168.40.14:554/live/main",
                    rtspBad = "rtsp://admin:a256@192.168.40.14:554/live/sub",
                    position = 6,
                    name = "TSC-7"
                }, c8 = new Camera()
                {
                    rtspGood = "rtsp://admin:1admin@192.168.40.103:554/cam/realmonitor?channel=1&subtype=1",
                    rtspBad = "rtsp://admin:1admin@192.168.40.103:554/cam/realmonitor?channel=1&subtype=0",
                    position = 7,
                    camIcon = 0,
                    aspectRatio = "4:3",
                    name = "Police-1"
                }, c9 = new Camera()
                {
                    rtspGood = "rtsp://admin:1admin@192.168.40.103:554/cam/realmonitor?channel=2&subtype=1",
                    rtspBad = "rtsp://admin:1admin@192.168.40.103:554/cam/realmonitor?channel=2&subtype=0",
                    position = 8,
                    camIcon = 0,
                    aspectRatio = "4:3",
                    name = "Police-2"
                }, c10 = new Camera()
                {
                    rtspGood = "rtsp://admin:1admin@192.168.40.103:554/cam/realmonitor?channel=3&subtype=1",
                    rtspBad = "rtsp://admin:1admin@192.168.40.103:554/cam/realmonitor?channel=3&subtype=0",
                    position = 9,
                    camIcon = 0,
                    aspectRatio = "4:3",
                    name = "Police-3"
                }, c11 = new Camera()
                {
                    rtspGood = "rtsp://admin:1admin@192.168.40.103:554/cam/realmonitor?channel=4&subtype=1",
                    rtspBad = "rtsp://admin:1admin@192.168.40.103:554/cam/realmonitor?channel=4&subtype=0",
                    position = 10,
                    camIcon = 0,
                    aspectRatio = "4:3",
                    name = "Police-4"
                }, c12 = new Camera()
                {
                    rtspGood = "rtsp://admin:1admin@192.168.40.103:554/cam/realmonitor?channel=5&subtype=1",
                    rtspBad = "rtsp://admin:1admin@192.168.40.103:554/cam/realmonitor?channel=5&subtype=0",
                    position = 11,
                    camIcon = 0,
                    aspectRatio = "4:3",
                    name = "Police-5"
                };
                Camera[] c = { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12 };
                appSet.cams = c;
            }
            appSet.camListView = 4;
            appSet.matrix.cntX = 4;
            appSet.matrix.cntY = 3;
            #endif
            
            if (appSet.cams == null) appSet.cams = new Camera[0];
            if (appSet.controlPanelWidth > tabControlSplitter.MinSize) ctrlPanel.Width = appSet.controlPanelWidth;
            matrixXinput.Text = appSet.matrix.cntX.ToString();
            matrixYinput.Text = appSet.matrix.cntY.ToString();
            i = 0;
            camerasListView.Clear();
            foreach (Camera m in appSet.cams)
            {
                camerasListView.Items.Add(m.name, m.camIcon);
                camerasListView.Items[i].Tag = m;
                i++;
            }

            //MessageBox.Show(this, "MainForm creating ...");
            if (CreateMatrix(appSet.matrix.cntX, appSet.matrix.cntY))
            {
                FillMatrix();
                
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

                SplitLabel_MouseLeave(null, null);
                TabControlSplitter_SplitterMoved(null, null);

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
                {
                    foreach (RtspBadGoodControl c in gridline) if (c.isCameraSet) c.play(this);
                }
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
                TypeViewStripMenuItem_Click(appSet.camListView);
                SortToolStripMenuItem_Click(appSet.camListSort);
                showHintTimer.Tag = 0;
                f = true;
                foreach (RtspBadGoodControl c in gridline) if (c.isCameraSet) f = false;
                if (f) ShowHintWithWait(HintType.OpenCtrl);
                watchDogTimer.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (grid == null) return;
            foreach (RtspBadGoodControl c in gridline) c.Dispose();
            AppSettingsSave();
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

        private void Form1_Shown(object sender, EventArgs e)
        {
            Form1_Resize(this, null);
            Form1_ResizeEnd(this, null);
        }



        /*************************************************************************************************
         *
         *                                      Matrix actions
         *
         *************************************************************************************************/

        private bool CreateMatrix(int newX, int newY)
        {
            int idx = 0, oldX = -1, oldY = -1;
            if (grid != null)
            {
                oldX = grid.GetUpperBound(0) + 1;
                oldY = grid.GetUpperBound(1) + 1;
            }
            RtspBadGoodControl item;
            RtspBadGoodControl[,] grid1 = new RtspBadGoodControl[newX, newY];
            RtspBadGoodControl[] gridline1 = new RtspBadGoodControl[newX * newY];
            try
            {
                for (int y = 0; y < newY; y++)
                    for (int x = 0; x < newX; x++)
                    {
                        if (x < oldX && y < oldY)
                        {
                            item = grid[x, y];
                            grid[x, y] = null;
                            item.Tag = idx;
                            if (item.Camera != null)
                                item.Camera.position = idx;
                        }
                        else
                        {
                            item = new RtspBadGoodControl()
                            {
                                Volume = arg_unmute == 0 ? 0 : 50,
                                Tag = idx,
                                Visible = true,
                                AllowDrop = true,
                                GlobalNameView = appSet.nameView
                            };
                            item.MouseDoubleClick += new MouseEventHandler(this.RtspBadGoodControl_DoubleClick);
                            item.DragDrop += new DragEventHandler(this.RtspBadGoodControl_DragDrop);
                            item.DragEnter += new DragEventHandler(this.RtspBadGoodControl_DragEnter);
                            item.onOptionsClick += new EventHandler(this.RtspBadGoodControl_OptionsClick);
                            item.MouseDown += new MouseEventHandler(this.RtspBadGoodControl_MouseDown);
                            item.MouseMove += new MouseEventHandler(this.RtspBadGoodControl_MouseMove);
                            if (grid != null) item.Camera = null;
                            this.camPanel.Controls.Add(item);
                        }
                        grid1[x, y] = item;
                        gridline1[idx] = item;
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
            if (grid != null) // dispose of old data
                for (int x = 0; x <= oldX-1; x++)
                    for (int y = 0; y <= oldY-1; y++)
                        if (grid[x, y] != null)
                        {
                            item = grid[x, y];
                            if (item.Camera != null)
                                item.Camera.position = -1;
                            this.camPanel.Controls.Remove(item);
                            item.Dispose();
                        }
            fullScrIdx = -1;
            grid = grid1;
            gridline = gridline1;
            return true;
        }

        private void FillMatrix()
        {
            // clear windows, which won't be set
            bool f;
            for (int i = gridline.GetLowerBound(0); i <= gridline.GetUpperBound(0); i++)
            {
                f = true;
                foreach (Camera m in appSet.cams) if (m.position == i) { f = false; break; }
                if (f) gridline[i].Camera = null;
            }
            try
            {
                // show the cams, which is set
                foreach (Camera m in appSet.cams)
                    if ((gridline.Length > m.position) && (m.position >= 0))
                        gridline[m.position].Camera = m;
            }
            catch (Exception ex)
            {
                DialogResult a = MessageBox.Show(ex.Message + "\n" + ex.GetType() + "\n\n" + errorSetCamera.Text + "\n\n" + errorInitVLC.Text,
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (a == DialogResult.Yes) System.Diagnostics.Process.Start(Properties.Resources.downloadVlcUrl);
                try { Environment.Exit(101); }
                catch { Application.Exit(); this.Close(); }
            }
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

        private void RtspBadGoodControl_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Camera)))
            {
                Camera m = (Camera)(e.Data.GetData(typeof(Camera)));
                if (m != null)
                {
                    int t = Convert.ToInt32((sender as Control).Tag);
                    RtspBadGoodControl c = gridline[t];
                    if (m.position >= 0) gridline[m.position].Camera = null;
                    foreach (Camera v in appSet.cams) if (v.position == t) v.position = -1;
                    m.position = t;
                    gridline[t].Camera = m;
                    gridline[t].play(this);
                    if (hintDropCamera.Visible) HideHintNow();
                }
            }
            else if (e.Data.GetDataPresent(typeof(RtspBadGoodControl)))
            {
                RtspBadGoodControl c = (RtspBadGoodControl)(e.Data.GetData(typeof(RtspBadGoodControl)));
                RtspBadGoodControl s = sender as RtspBadGoodControl;
                int f = Convert.ToInt32(c.Tag); //from position
                int t = Convert.ToInt32((sender as Control).Tag); //to position
                gridline[t] = c;
                gridline[f] = s;
                grid[t % appSet.matrix.cntX, t / appSet.matrix.cntX] = c;
                grid[f % appSet.matrix.cntX, f / appSet.matrix.cntX] = s;
                if (c.Camera != null) c.Camera.position = t;
                if (s.Camera != null) s.Camera.position = f;
                c.Tag = t.ToString();
                s.Tag = f.ToString();
                Point l = c.Location;
                c.Location = s.Location;
                s.Location = l;
                //Form1_Resize(this, null);
                //Form1_ResizeEnd(this, null); 
            }
        }

        private void RtspBadGoodControl_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Camera))) e.Effect = DragDropEffects.Copy;
            if (e.Data.GetDataPresent(typeof(RtspBadGoodControl))) e.Effect = DragDropEffects.Move;
        }
        private void RtspBadGoodControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            MouseDownFlag = true;
            MouseDownPoint = new Point(e.X, e.Y);
        }
        private void RtspBadGoodControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseDownFlag)
            {
                Point NewMouseMovePoint = new Point(e.X, e.Y);
                NewMouseMovePoint.Offset(MouseDownPoint);
                if ((NewMouseMovePoint.X > 5) || ((NewMouseMovePoint.X > -5)) || (NewMouseMovePoint.Y > 5) || (NewMouseMovePoint.Y > -5))
                {
                    if (e.Button == MouseButtons.Left) 
                        camerasListView.DoDragDrop((RtspBadGoodControl)sender, DragDropEffects.Move | DragDropEffects.Copy);
                }
            }
        }
        private void RtspBadGoodControl_OptionsClick(object sender, EventArgs e)
        {
            Camera n = (sender as RtspBadGoodControl).Camera;
            int i = camerasListView.Items.Count - 1;
            for (; i >= 0; i--)
                if (camerasListView.Items[i].Tag == n)
                {
                    bool autoHide = !ctrlPanel.Visible;
                    ctrlPanel.Visible = true;
                    tabControl1.SelectedTab = camerasPage;
                    camerasListView.Items[i].Focused = true;
                    camerasListView.Items[i].Selected = true;
                    ModifyCameraToolStripMenuItem_Click(null, null);
                    hideCtrlPanelAfterEdit = autoHide;
                    Form1_Resize(this, null);
                    Form1_ResizeEnd(this, null);
                    break;
                }
        }




        /*************************************************************************************************
         *
         *                                      Options dialog
         *
         *************************************************************************************************/

        private void CommandLineHelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(commandLineHelp.Text, commandLineHelpButton.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void DeveloperLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://xn--b1abfaar8alabm5a5e.xn--p1ai/"); //решениеготово.рф
            (sender as LinkLabel).LinkVisited = true;
        }

        private void CamNameViewGlbButton_Click(object sender, EventArgs e)
        {
            if (camNameConfigForm == null)
            {
                camNameConfigForm = new CamNameConfigForm();
                camNameConfigForm.onSaveClick += new EventHandler(this.CamNameConfigForm_SaveClick);
                camNameConfigForm.onCancelClick += new EventHandler(this.CamNameConfigForm_CancelClick);
            }
            camNameConfigForm.NameView = appSet.nameView;
            camNameConfigForm.Show();
            this.Enabled = false;
        }

        private void MatrixXinput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }
        }

        private void MatrixSaveLabel_Click(object sender, EventArgs e)
        {
            matrixSaveLabel.Visible = false;
            try
            {
                int x = Convert.ToInt32(matrixXinput.Text);
                int y = Convert.ToInt32(matrixYinput.Text);
                if (x > 0 && x <= Convert.ToInt32(Properties.Resources.matrixMaxX)
                    && y > 0 && y <= Convert.ToInt32(Properties.Resources.matrixMaxY))
                {
                    CreateMatrix(x, y);
                    appSet.matrix.cntX = x;
                    appSet.matrix.cntY = y;
                    Form1_Resize(null, null);
                    Form1_ResizeEnd(null, null);
                }
            }
            finally
            {
                matrixXinput.Text = appSet.matrix.cntX.ToString();
                matrixYinput.Text = appSet.matrix.cntY.ToString();
            }
        }

        private void MatrixXinput_TextChanged(object sender, EventArgs e)
        {
            if (grid != null)
                matrixSaveLabel.Visible = (Convert.ToInt32(matrixXinput.Text) > 0 &&
                    Convert.ToInt32(matrixYinput.Text) > 0 &&
                    (Convert.ToInt32(matrixXinput.Text) != appSet.matrix.cntX ||
                    Convert.ToInt32(matrixYinput.Text) != appSet.matrix.cntY));
        }

        private void MatrixXinput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    try
                    {
                        int v = Convert.ToInt32(((TextBox)sender).Text);
                        if (sender == matrixXinput && v < Convert.ToInt32(Properties.Resources.matrixMaxX)
                            || sender == matrixYinput && v < Convert.ToInt32(Properties.Resources.matrixMaxY))
                        {
                            ((TextBox)sender).Text = (v + 1).ToString();
                        }
                    }
                    catch (Exception) { }
                    break;
                case Keys.Down:
                    try
                    {
                        int v = Convert.ToInt32(((TextBox)sender).Text);
                        if (v > 1) ((TextBox)sender).Text = (v - 1).ToString();
                    }
                    catch (Exception) { }
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }



        /*************************************************************************************************
         *
         *                                      Edit Camera dialog
         *
         *************************************************************************************************/

        private void NewCameraToolStripMenuItem_Click(object sender, EventArgs e)
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
            editCamera = new Camera();
            aspectRatioTextBox.Text = editCamera.aspectRatio;
            camNameShowCheck.Checked = editCamera.nameView.enabled;
            camNameShowInheritCheck.Checked = editCamera.nameView.inheritGlobal;
            CamNameShowCheck_CheckedChanged(this, null);
            CamNameShowInheritCheck_CheckedChanged(this, null);
            if (camNameConfigForm != null)
            {
                camNameConfigForm.NameView = this.editCamera.nameView;
            }

            if (hintAddCamera.Visible) HideHintNow();
            hideCtrlPanelAfterEdit = false;
        }

        private void ModifyCameraToolStripMenuItem_Click(object sender, EventArgs e)
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
            this.editCamera = m;
            camNameShowCheck.Checked = m.nameView.enabled;
            camNameShowInheritCheck.Checked = m.nameView.inheritGlobal;
            CamNameShowCheck_CheckedChanged(this, null);
            CamNameShowInheritCheck_CheckedChanged(this, null);
            hideCtrlPanelAfterEdit = false;
            if (camNameConfigForm != null)
            {
                camNameConfigForm.NameView = this.editCamera.nameView;
            }
        }

        private void DelCamLabel_Click(object sender, EventArgs e)
        {
            if (rtsp1TextBox.Text == "" && rtsp2TextBox.Text == "")
                if (MessageBox.Show(cameraDeleteConfirm1.Text + " ''" + camNameTextBox.Text + "''?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    != DialogResult.Yes) return;
            if (this.editCamera == null) CancelCamButton_Click(null, null);
            else
            {
                if (this.editCamera.position >= 0)
                {
                    if (MessageBox.Show(cameraDeleteConfirm2.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        != DialogResult.Yes) return;
                    gridline[this.editCamera.position].Camera = null;
                    this.editCamera.position = -1;
                }
                camerasListView.FocusedItem.Remove();
                appSet.cams = Array.FindAll(appSet.cams, x => x != this.editCamera);
                CancelCamButton_Click(null, null);
            }
        }

        private void CamNameShowCheck_CheckedChanged(object sender, EventArgs e)
        {
            camNameShowInheritCheck.Enabled = camNameShowCheck.Checked;
        }

        private void CamNameShowInheritCheck_CheckedChanged(object sender, EventArgs e)
        {
            camNameShowModifyLabel.Enabled = !camNameShowInheritCheck.Checked;
        }

        private void SaveCamButton_Click(object sender, EventArgs e)
        {
            Camera m = this.editCamera;
            if (!delCamLabel.Visible)
            {
                int l = appSet.cams.Length;
                Array.Resize(ref appSet.cams, l+1);
                m = new Camera();
                appSet.cams[l] = m;
                ListViewItem vi = new ListViewItem();
                camerasListView.Items.Add(vi);
                vi.Focused = true;
                vi.Selected = true;
                vi.Tag = m;
                camerasListView.FocusedItem.ImageIndex = m.camIcon;
            }
            RtspBadGoodControl c = m.position >= 0 ? gridline[m.position] : null;
            if (m.name != camNameTextBox.Text)
            {
                m.name = camNameTextBox.Text;
                camerasListView.FocusedItem.Text = m.name;
                if (c != null) c.Title = m.name;
            }
            if (m.camIcon != camerasIconListView.FocusedItem.Index)
            {
                m.camIcon = camerasIconListView.FocusedItem.Index;
                camerasListView.FocusedItem.ImageIndex = m.camIcon;
            }
            if(m.rtspBad != rtsp1TextBox.Text || m.rtspGood != rtsp2TextBox.Text || m.aspectRatio != aspectRatioTextBox.Text)
            {
                m.rtspBad = rtsp1TextBox.Text;
                m.rtspGood = rtsp2TextBox.Text;
                m.aspectRatio = aspectRatioTextBox.Text;
                if (c != null)
                {
                    VlcStatus s = c.Status;
                    c.Camera = m;
                    if (s != VlcStatus.Stopped) c.play(this);
                }
            }
            if (camNameConfigForm != null)
            {
                m.nameView = camNameConfigForm.NameView;
            }
            m.nameView.enabled = camNameShowCheck.Checked;
            m.nameView.inheritGlobal = camNameShowInheritCheck.Checked;
            if (c != null) c.NameView = m.nameView;
            CancelCamButton_Click(sender, null);
        }

        private void CancelCamButton_Click(object sender, EventArgs e)
        {
            this.editCamera = null;
            HideHintNow();
            editCamPanel.SendToBack();
            editCamPanel.Visible = false;
            if (camerasListView.Items.Count == 0) ShowHintWithWait(HintType.AddCamera);
            else
            {
                bool f = true;
                foreach (RtspBadGoodControl c in gridline) if (c.isCameraSet) f = false;
                if (f) ShowHintWithWait(HintType.DropCamera);
                else if (hideCtrlPanelAfterEdit)
                {
                    ctrlPanel.Visible = false;
                    Form1_Resize(this, null);
                    Form1_ResizeEnd(this, null);
                }
            }
        }

        private void CamNameShowModifyLabel_Click(object sender, EventArgs e)
        {
            if (camNameConfigForm == null)
            {
                camNameConfigForm = new CamNameConfigForm();
                camNameConfigForm.onSaveClick += new EventHandler(this.CamNameConfigForm_SaveClick);
                camNameConfigForm.onCancelClick += new EventHandler(this.CamNameConfigForm_CancelClick);
                camNameConfigForm.NameView = this.editCamera.nameView;
            }
            camNameConfigForm.Show();
            this.Enabled = false;
        }
        private void CamNameConfigForm_SaveClick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "optionsPage")
            {
                appSet.nameView = camNameConfigForm.NameView;
                foreach (RtspBadGoodControl m in gridline)
                    m.GlobalNameView = appSet.nameView;
            }
            CamNameConfigForm_CancelClick(sender, e);
        }
        private void CamNameConfigForm_CancelClick(object sender, EventArgs e)
        {
            this.Enabled = true;
        }

        private void ButtonLabel_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }

        private void ButtonLabel_MouseLeave(object sender, EventArgs e)
        {
            if (sender == delCamLabel) ((Label)sender).ForeColor = Color.Red;
            else ((Label)sender).ForeColor = SystemColors.ControlText;
        }




        /*************************************************************************************************
         *
         *                                 List of Cameras dialog
         *
         *************************************************************************************************/

        private void CamerasListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == "" || e.Label == null) { e.CancelEdit = true; return; }
            Camera m = (Camera)(camerasListView.FocusedItem.Tag);
            m.name = e.Label;
            gridline[m.position].Title = m.name;
        }

        private void CamerasListView_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Camera))) e.Effect = DragDropEffects.Move;
        }

        private void CamerasListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ListViewItem vi = camerasListView.GetItemAt(e.X, e.Y);
            if (vi == null) return;
            vi.Focused = true;
            vi.Selected = true;
            camerasListView.DoDragDrop((Camera)(camerasListView.FocusedItem.Tag), DragDropEffects.Copy | DragDropEffects.Move);
        }

        private void ContextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            modifyCameraToolStripMenuItem.Enabled = camerasListView.SelectedItems.Count > 0;
            HideHintNow();
        }

        private void TypeViewStripMenuItem_Click(int i)
        {
            camerasListView.LargeImageList = i < 2 ? cameraIconsImageList : i > 3 ? cameraIconsImageList3 : cameraIconsImageList2;
            camerasListView.SmallImageList = camerasListView.LargeImageList;
            camerasListView.View = i < 3 ? View.LargeIcon : View.List;
            largeIconsToolStripMenuItem.Checked = i == 1;
            smallIconsToolStripMenuItem.Checked = i == 2;
            largeListToolStripMenuItem.Checked = i == 3;
            smallListToolStripMenuItem.Checked = i == 4;
            appSet.camListView = i;
        }
        private void LargeIconsToolStripMenuItem_Click(object sender, EventArgs e) { TypeViewStripMenuItem_Click(1); }
        private void SmallIconsToolStripMenuItem_Click(object sender, EventArgs e) { TypeViewStripMenuItem_Click(2); }
        private void LargeListToolStripMenuItem_Click(object sender, EventArgs e) { TypeViewStripMenuItem_Click(3); }
        private void SmallListToolStripMenuItem_Click(object sender, EventArgs e) { TypeViewStripMenuItem_Click(4); }

        private void SortToolStripMenuItem_Click(int i)
        {
            camerasListView.Sorting = i == 1 ? SortOrder.Ascending : i == 2 ? SortOrder.Descending : SortOrder.None;
            ascendingToolStripMenuItem.Checked = i == 1;
            descendingToolStripMenuItem.Checked = i == 2;
            disabledToolStripMenuItem.Checked = i == 3;
            appSet.camListSort = i;
        }
        private void AscendingToolStripMenuItem_Click(object sender, EventArgs e) { SortToolStripMenuItem_Click(1); }
        private void DescendingToolStripMenuItem_Click(object sender, EventArgs e) { SortToolStripMenuItem_Click(2); }
        private void DisabledToolStripMenuItem_Click(object sender, EventArgs e) { SortToolStripMenuItem_Click(3); }

        private void SplitLabel_MouseEnter(object sender, EventArgs e) { splitLabel.Left = tabControlSplitter.Visible ? tabControlSplitter.Width : 0; }
        private void SplitLabel_MouseLeave(object sender, EventArgs e) { splitLabel.Left = (tabControlSplitter.Visible ? tabControlSplitter.Width : 0) - 3; }
        private void SplitLabel_Click(object sender, EventArgs e)
        {
            ctrlPanel.Visible = !ctrlPanel.Visible;
            tabControlSplitter.Visible = ctrlPanel.Visible;
            splitLabel.Text = ctrlPanel.Visible ? "<<" : ">>";
            Form1_Resize(this, null);
            Form1_ResizeEnd(this, null);
            splitLabel.Left = (tabControlSplitter.Visible ? tabControlSplitter.Width : 0) - 6;
            if (ctrlPanel.Visible)
            {
                if (camerasIconListView.Items.Count == 0) ShowHintWithWait(HintType.AddCamera);
            }
            else HideHintNow();
        }
        private void TabControlSplitter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Form1_Resize(this, null);
            Form1_ResizeEnd(this, null);
            appSet.controlPanelWidth = ctrlPanel.Width;
            //tabControl1.Invalidate(); camerasListView.Invalidate(); splitLabel.Invalidate(); // if splitter1_SplitterMoving()
        }
        private void TabControlSplitter_SplitterMoving(object sender, SplitterEventArgs e)
        {
            /*Form1_Resize(this,null);ctrlPanel.Width=e.SplitX;*/
        }





        /*************************************************************************************************
         *
         *                                      Hints engine
         *
         *************************************************************************************************/

        private void ShowHintTimer_Tick(object sender, EventArgs e)
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

        private void CamNameTextBox_Enter(object sender, EventArgs e)
        {
            if(camNameTextBox.ForeColor!=SystemColors.WindowText) {
                camNameTextBox.ForeColor = SystemColors.WindowText;
                camNameTextBox.Text = "";
            }
        }
        private void Rtsp1TextBox_Enter(object sender, EventArgs e)
        {
            if (rtsp1TextBox.ForeColor != SystemColors.WindowText)
            {
                rtsp1TextBox.ForeColor = SystemColors.WindowText;
                rtsp1TextBox.Text = "";
            }
            bool f = true;
            foreach (RtspBadGoodControl c in gridline) if (c.isCameraSet) f = false;
            if (f) ShowHintWithWait(HintType.NewRTSP1);
        }
        private void Rtsp2TextBox_Enter(object sender, EventArgs e)
        {
            if (rtsp2TextBox.ForeColor != SystemColors.WindowText)
            {
                rtsp2TextBox.ForeColor = SystemColors.WindowText;
                rtsp2TextBox.Text = "";
            }
            bool f = true;
            foreach (RtspBadGoodControl c in gridline) if (c.isCameraSet) f = false;
            if (f) ShowHintWithWait(HintType.NewRTSP2);
        }
        private void ShowHintWithWait(HintType hintType)
        {
            if ((int)showHintTimer.Tag < 0) ShowHintTimer_Tick(null, null);
            showHintTimer.Interval = Convert.ToInt32(Properties.Resources.showHintTimer);
            showHintTimer.Tag = hintType;
            showHintTimer.Enabled = false;
            showHintTimer.Enabled = true;
        }
        private void HideHintNow()
        {
            if ((int)showHintTimer.Tag < 0) ShowHintTimer_Tick(null, null);
            else showHintTimer.Enabled = false;
        }

        private void WatchDogTimer_Tick(object sender, EventArgs e)
        {
            System.Diagnostics.Process currentProc = System.Diagnostics.Process.GetCurrentProcess();
            int kbTaken = (int)(currentProc.PrivateMemorySize64 / 1024); // app size in KB
            int camShown = 0;
            foreach (RtspBadGoodControl c in gridline) if (c.Status == VlcStatus.Playing) camShown = camShown + 1;
            if (maxCamShown < camShown)
            {
                maxCamShown = camShown;
                maxKbTaken = kbTaken;
            }
            else if (kbTaken / camShown > maxKbTaken * 1.4 / maxCamShown)
            {
                int restartCam = lastRestartedCamera + 1;
                if(restartCam>gridline.GetUpperBound(0))
                    restartCam = gridline.GetLowerBound(0);
                for (int i = restartCam; i <= gridline.GetUpperBound(0); i++)
                {
                    RtspBadGoodControl c = gridline[i];
                    if (c.Status != VlcStatus.Stopped)
                    {
                        c.stop(watchDogTimer);
                        c.play(watchDogTimer);
                        restartCam = i;
                        break;
                    }
                }
                lastRestartedCamera = restartCam;
            }
            watchDogTimer.Enabled = true;
        }

    }
    



    /*************************************************************************************************
     *
     *                         Settings classes and their default values
     *
     *************************************************************************************************/

    public class AppSettings
    {
        public int screen = -1; // screen number to open window on start
        public int fullscreen = 0; // expand window: 0-no, 1-yes
        public int autoplay = 1; // auto start all sources: 0-no, 1-auto play
        public int priority = -1; // application base priority: 0-Idle, 1-BelowNormal, 2-Normal, 3-AboveNormal, 4-High
        public int unmute = 0; // do not mute audio: 0-silent, 1-enable sounds
        public int controlPanelWidth = 0; // width of control panel
        public int camListView = 1; // cameras list type of view (1-4:largeIcon/smallIcon/largeList/smallList)
        public int camListSort = 3; // cameras list sort type (1-3:asc/desc/none)

        public Matrix matrix = new Matrix(); // matrix parameters (rows and columns count)
        public NameView nameView = new NameView(); // camera name show global option

        [System.Xml.Serialization.XmlArrayItem(ElementName = "cam", Type = typeof(Camera))]
        public Camera[] cams;
    }

    public class Matrix
    {
        public int cntX = 2;
        public int cntY = 2;
    }
    
    public class Camera
    {
        public string name = "";
        public string rtspBad = "";
        public string rtspGood = "";
        public string aspectRatio = Properties.Resources.defaultAspectRatio;//"auto"
        public int camIcon = 1;
        public int position = -1;

        public NameView nameView = new NameView(); // name show parameters
        //[XmlIgnoreAttribute]
    }

    public class NameView
    {
        public bool enabled = true;
        public bool inheritGlobal = true;
        public TextPosition position = TextPosition.BottomCenter;
        [XmlIgnore]
        public Color color = Color.White;
        [XmlElement("color")]
        public int ColorAsArgb
        {
            get { return color.ToArgb(); }
            set { color = Color.FromArgb(value); }
        }
        public int size = 5;
        public bool autoHide = false;
        public int autoHideSec = 4;
        public bool paintBg = true;
        [XmlIgnore]
        public Color bgColor = Color.ForestGreen;
        [XmlElement("bgColor")]
        public int BgColorAsArgb
        {
            get { return bgColor.ToArgb(); }
            set { bgColor = Color.FromArgb(value); }
        }

        public void SaveTo(NameView nv)
        {
            nv.autoHide = autoHide;
            nv.autoHideSec = autoHideSec;
            nv.bgColor = bgColor;
            nv.color = color;
            nv.enabled = enabled;
            nv.inheritGlobal = inheritGlobal;
            nv.paintBg = paintBg;
            nv.position = position;
            nv.size = size;
        }
    }
}