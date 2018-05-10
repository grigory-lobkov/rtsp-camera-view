using System.Windows.Forms;

namespace View.Components
{
    partial class SourceControl
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
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.controlHideTimer = new System.Windows.Forms.Timer(this.components);
            this.nameHideTimer = new System.Windows.Forms.Timer(this.components);
            this.preshowBadPlayerTimer = new System.Windows.Forms.Timer(this.components);
            this.preshowGoodPlayerTimer = new System.Windows.Forms.Timer(this.components);
            this.switchToBadTimer = new System.Windows.Forms.Timer(this.components);
            this.switchToGoodTimer = new System.Windows.Forms.Timer(this.components);
            this.stopBadPlayerTimer = new System.Windows.Forms.Timer(this.components);
            this.stopGoodPlayerTimer = new System.Windows.Forms.Timer(this.components);
            this.stopOnInvisibleTimer = new System.Windows.Forms.Timer(this.components);
            this.srcName = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.ListBox();
            this.hidePlayerPanel = new System.Windows.Forms.Panel();
            this.topPanel = new View.Components.TopPanel();
            this.SuspendLayout();
            // 
            // controlHideTimer
            // 
            this.controlHideTimer.Interval = 5000;
            // 
            // nameHideTimer
            // 
            this.nameHideTimer.Interval = 5000;
            // 
            // preshowBadPlayerTimer
            // 
            this.preshowBadPlayerTimer.Interval = 2000;
            // 
            // preshowGoodPlayerTimer
            // 
            this.preshowGoodPlayerTimer.Interval = 2000;
            // 
            // switchToBadTimer
            // 
            this.switchToBadTimer.Interval = 4000;
            // 
            // switchToGoodTimer
            // 
            this.switchToGoodTimer.Interval = 3000;
            // 
            // stopBadPlayerTimer
            // 
            this.stopBadPlayerTimer.Interval = 60000;
            // 
            // stopGoodPlayerTimer
            // 
            this.stopGoodPlayerTimer.Interval = 60000;
            // 
            // stopOnInvisibleTimer
            // 
            this.stopOnInvisibleTimer.Interval = 180000;
            // 
            // srcName
            // 
            this.srcName.AutoSize = true;
            this.srcName.BackColor = System.Drawing.Color.Black;
            this.srcName.ForeColor = System.Drawing.Color.White;
            this.srcName.Location = new System.Drawing.Point(46, 18);
            this.srcName.Name = "srcName";
            this.srcName.Size = new System.Drawing.Size(59, 13);
            this.srcName.TabIndex = 0;
            this.srcName.Text = "nameLabel";
            // 
            // log
            // 
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(124, 84);
            this.log.Name = "log";
            this.log.ScrollAlwaysVisible = true;
            this.log.Size = new System.Drawing.Size(196, 329);
            this.log.TabIndex = 0;
            this.log.Visible = false;
            // 
            // hidePlayerPanel
            // 
            this.hidePlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hidePlayerPanel.ForeColor = System.Drawing.Color.White;
            this.hidePlayerPanel.Location = new System.Drawing.Point(0, 0);
            this.hidePlayerPanel.Name = "hidePlayerPanel";
            this.hidePlayerPanel.Size = new System.Drawing.Size(150, 150);
            this.hidePlayerPanel.TabIndex = 2;
            this.hidePlayerPanel.Visible = false;
            // 
            // topPanel
            // 
            this.topPanel.AllowDrop = true;
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(150, 150);
            this.topPanel.TabIndex = 1;
            this.topPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.TopPanel_DragDrop);
            this.topPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.TopPanel_DragEnter);
            this.topPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.topPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.topPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // SourceControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.log);
            this.Controls.Add(this.srcName);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.hidePlayerPanel);
            this.Name = "SourceControl";
            this.Resize += new System.EventHandler(this.SourceControl_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Timer controlHideTimer;
        private Timer nameHideTimer;
        private Timer preshowBadPlayerTimer;
        private Timer preshowGoodPlayerTimer;
        private Timer switchToGoodTimer;
        private Timer switchToBadTimer;
        private Timer stopBadPlayerTimer;
        private Timer stopGoodPlayerTimer;
        private Timer stopOnInvisibleTimer;
        private Label srcName;
        private TopPanel topPanel;
        private ListBox log;
        private Panel hidePlayerPanel;
    }
}
