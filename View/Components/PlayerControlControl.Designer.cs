using System;
using System.Windows.Forms;

namespace View.Components
{
    partial class PlayerControlControl
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
                btnPlayStop.Dispose();
                btnVolMinus.Dispose();
                btnVolPlus.Dispose();
                controlPanelR.Dispose();
                btnClose.Dispose();
                btnMaxMin.Dispose();
                btnOptions.Dispose();
                btnOptions.Dispose();
                controlPanelR.Dispose();
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
            btnPlayStop = new Panel();
            btnVolMinus = new Panel();
            btnVolPlus = new Panel();
            btnClose = new Panel();
            btnMaxMin = new Panel();
            btnOptions = new Panel();
            controlPanelR = new Panel();
            controlPanelR.SuspendLayout();
            this.SuspendLayout();
            this.ForeColor = System.Drawing.Color.White;
            this.BackColor = System.Drawing.Color.Gray;
            this.Height = 20;
            //
            // btnPlayStop
            //
            btnPlayStop.BackgroundImage = RtspCameraView.Properties.Resources.btn_eject;
            btnPlayStop.BackgroundImageLayout = ImageLayout.Stretch;
            btnPlayStop.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnPlayStop.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnPlayStop.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnPlayStop.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnPlayStop.MouseClick += new MouseEventHandler(this.btnPlayStop_MouseClick);
            btnPlayStop.Tag = null;
            btnPlayStop.Size = new System.Drawing.Size(20, 20);
            this.Controls.Add(btnPlayStop);
            //
            // btnPlayStop
            //
            btnVolMinus.BackgroundImage = RtspCameraView.Properties.Resources.btn_vol_minus;
            btnVolMinus.BackgroundImageLayout = ImageLayout.Stretch;
            btnVolMinus.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnVolMinus.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnVolMinus.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnVolMinus.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnVolMinus.Visible = false;
            btnVolMinus.Size = btnPlayStop.Size;
            btnVolMinus.Tag = null;
            this.Controls.Add(btnVolMinus);
            //
            // btnVolPlus
            //
            btnVolPlus.BackgroundImage = RtspCameraView.Properties.Resources.btn_vol_plus;
            btnVolPlus.BackgroundImageLayout = ImageLayout.Stretch;
            btnVolPlus.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnVolPlus.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnVolPlus.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnVolPlus.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnVolPlus.Visible = false;
            btnVolPlus.Size = btnPlayStop.Size;
            btnVolPlus.Tag = null;
            this.Controls.Add(btnVolPlus);
            //
            // controlPanelR
            //
            this.Controls.Add(controlPanelR);
            controlPanelR.Width = 60;
            controlPanelR.Dock = DockStyle.Right;
            controlPanelR.Visible = false;
            controlPanelR.BringToFront();
            //
            // btnClose
            //
            btnClose.BackgroundImage = RtspCameraView.Properties.Resources.btn_close;
            btnClose.BackgroundImageLayout = ImageLayout.Stretch;
            btnClose.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnClose.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnClose.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnClose.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnClose.Size = new System.Drawing.Size(15, 15);
            btnClose.Tag = null;
            controlPanelR.Controls.Add(btnClose);
            //
            // btnMaxMin
            //
            btnMaxMin.BackgroundImage = RtspCameraView.Properties.Resources.btn_maximize;
            btnMaxMin.BackgroundImageLayout = ImageLayout.Stretch;
            btnMaxMin.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnMaxMin.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnMaxMin.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnMaxMin.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnMaxMin.Size = btnClose.Size;
            btnMaxMin.Tag = null;
            controlPanelR.Controls.Add(btnMaxMin);
            //
            // btnOptions
            //
            btnOptions.BackgroundImage = RtspCameraView.Properties.Resources.btn_options;
            btnOptions.BackgroundImageLayout = ImageLayout.Stretch;
            btnOptions.MouseEnter += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnOptions.MouseLeave += new EventHandler(this.btn_MouseEnterLeaveInvert);
            btnOptions.MouseDown += new MouseEventHandler(this.btn_MouseDown);
            btnOptions.MouseUp += new MouseEventHandler(this.btn_MouseUp);
            btnOptions.Size = btnClose.Size;
            btnOptions.Tag = null;
            controlPanelR.Controls.Add(btnOptions);

            controlPanelR.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private Panel btnPlayStop, btnVolMinus, btnVolPlus;
        private Panel controlPanelR;
        private Panel btnClose, btnMaxMin, btnOptions;
    }
}
