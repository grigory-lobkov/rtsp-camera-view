using System;
using System.Windows.Forms;

namespace RTSP_mosaic_VLC_player
{
    partial class RtspBadGoodControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing)
            {
                sizeChangedTimer.Dispose();
                hideControlTimer.Dispose();
                bgvlc.Dispose();
                btnPlayStop.Dispose();
                btnVolMinus.Dispose();
                btnVolPlus.Dispose();
                nameLabel.Dispose();
                btnClose.Dispose();
                btnMaxMin.Dispose();
                btnOptions.Dispose();
                controlPanelR.Dispose();
                controlPanel.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            hideControlTimer = new Timer();
            sizeChangedTimer = new Timer();
            bgvlc = new RtspBadGoodVLC();
            controlPanel = new Panel();
            btnPlayStop = new Panel();
            btnVolMinus = new Panel();
            btnVolPlus = new Panel();
            nameLabel = new Label();
            controlPanel = new Panel();
            controlPanel.SuspendLayout();
            btnClose = new Panel();
            btnMaxMin = new Panel();
            btnOptions = new Panel();
            controlPanelR = new Panel();
            controlPanelR.SuspendLayout();
            this.SuspendLayout();
            this.ForeColor = System.Drawing.Color.White;
            this.BackColor = System.Drawing.Color.Black;
            //
            // nameLabel
            //
            this.Controls.Add(nameLabel);
            nameLabel.AutoSize = true;
            nameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            nameLabel.Text = "Camera Name";
            controlPanel.Anchor = ((AnchorStyles)(AnchorStyles.Top));
            nameLabel.BringToFront();
            //
            // controlPanel
            //
            this.Controls.Add(controlPanel);
            controlPanel.BackColor = System.Drawing.Color.Gray;
            controlPanel.MouseEnter += new EventHandler(this.controlPanel_MouseEnter);
            controlPanel.Height = 20;
            controlPanel.Visible = false;
            controlPanel.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) | AnchorStyles.Right)));
            controlPanel.BringToFront();
            //
            // bgvlc
            //
            this.Controls.Add(bgvlc);
            bgvlc.onStop += new EventHandlerWObject(this.bgvlc_Stop);
            bgvlc.onPlay += new EventHandlerWObject(this.bgvlc_Play);
            bgvlc.onSoundtrackFound += new EventHandlerWObject(this.bgvlc_SoundTrackFound);
            bgvlc.onBeforeRtspSwitch += new EventHandlerWObject(this.bgvlc_BeforeRtspSwitch);
            bgvlc.Anchor = ((AnchorStyles)((((AnchorStyles.Bottom | AnchorStyles.Left) | AnchorStyles.Right) | AnchorStyles.Top)));
            bgvlc.MouseEnter += new EventHandler(this.bgvlc_MouseEnter);
            bgvlc.MouseDoubleClick += new MouseEventHandler(this.bgvlc_MouseDoubleClick);
            bgvlc.DragEnter += new DragEventHandler(this.bgvlc_DragEnter);
            bgvlc.DragDrop += new DragEventHandler(this.bgvlc_DragDrop);
            bgvlc.SendToBack();
            //
            // hideControlTimer
            //
            hideControlTimer.Interval = Convert.ToInt32(Properties.Resources.hideControlTimer);
            hideControlTimer.Tick += new EventHandler(this.hideControlTimer_Tick);
            //
            // sizeChangedTimer
            //
            sizeChangedTimer.Interval = 500;
            sizeChangedTimer.Tick += new EventHandler(this.hideControlTimer_Tick);
            //
            // btnPlayStop
            //
            btnPlayStop.BackgroundImage = Properties.Resources.btn_eject;
            btnPlayStop.BackgroundImageLayout = ImageLayout.Stretch;
            btnPlayStop.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnPlayStop.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnPlayStop.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnPlayStop.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnPlayStop.MouseClick += new MouseEventHandler(this.btnPlayStop_MouseClick);
            btnPlayStop.Tag = "0";
            btnPlayStop.Size = new System.Drawing.Size(20, 20);
            controlPanel.Controls.Add(btnPlayStop);
            //
            // btnPlayStop
            //
            btnVolMinus.BackgroundImage = Properties.Resources.btn_vol_minus;
            btnVolMinus.BackgroundImageLayout = ImageLayout.Stretch;
            btnVolMinus.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnVolMinus.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnVolMinus.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnVolMinus.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnVolMinus.Click += new EventHandler(this.btnVolMinus_Click);
            btnVolMinus.Visible = false;
            btnVolMinus.Size = btnPlayStop.Size;
            btnVolMinus.Tag = "0";
            controlPanel.Controls.Add(btnVolMinus);
            //
            // btnVolPlus
            //
            btnVolPlus.BackgroundImage = Properties.Resources.btn_vol_plus;
            btnVolPlus.BackgroundImageLayout = ImageLayout.Stretch;
            btnVolPlus.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnVolPlus.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnVolPlus.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnVolPlus.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnVolPlus.Click += new EventHandler(this.btnVolPlus_Click);
            btnVolPlus.Visible = false;
            btnVolPlus.Size = btnPlayStop.Size;
            btnVolPlus.Tag = "0";
            controlPanel.Controls.Add(btnVolPlus);
            //
            // controlPanelR
            //
            controlPanel.Controls.Add(controlPanelR);
            controlPanelR.MouseEnter += new EventHandler(this.controlPanel_MouseEnter);
            controlPanelR.Width = 60;
            controlPanelR.Dock = DockStyle.Right;
            controlPanelR.Visible = false;
            controlPanelR.BringToFront();
            //
            // btnClose
            //
            btnClose.BackgroundImage = Properties.Resources.btn_close;
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
            btnClose.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnClose.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnClose.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnClose.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnClose.Click += new EventHandler(this.btnClose_Click);
            btnClose.Size =  new System.Drawing.Size(15, 15);
            btnClose.Tag = "0";
            controlPanelR.Controls.Add(btnClose);
            //
            // btnMaxMin
            //
            btnMaxMin.BackgroundImage = Properties.Resources.btn_maximize;
            btnMaxMin.BackgroundImageLayout = ImageLayout.Stretch;
            btnMaxMin.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnMaxMin.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnMaxMin.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnMaxMin.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnMaxMin.Click += new EventHandler(this.btnMaxMin_Click);
            btnMaxMin.Size = btnClose.Size;
            btnMaxMin.Tag = "0";
            controlPanelR.Controls.Add(btnMaxMin);
            //
            // btnOptions
            //
            btnOptions.BackgroundImage = Properties.Resources.btn_options;
            btnOptions.BackgroundImageLayout = ImageLayout.Stretch;
            btnOptions.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnOptions.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnOptions.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnOptions.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnOptions.Click += new EventHandler(this.btnOptions_Click);
            btnOptions.Size = btnClose.Size;
            btnOptions.Tag = "0";
            controlPanelR.Controls.Add(btnOptions);

            controlPanel.ResumeLayout(false);
            controlPanelR.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private RtspBadGoodVLC bgvlc;
        private Timer hideControlTimer;
        private Panel controlPanel;
        private Panel btnPlayStop, btnVolMinus, btnVolPlus;
        private Panel controlPanelR;
        private Panel btnClose, btnMaxMin, btnOptions;
        private Label nameLabel;
        private Timer sizeChangedTimer;
    }
}
