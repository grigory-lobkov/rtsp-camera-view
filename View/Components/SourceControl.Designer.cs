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
            this.switchToBadTimer = new System.Windows.Forms.Timer(this.components);
            this.switchToGoodTimer = new System.Windows.Forms.Timer(this.components);
            this.stopBadTimer = new System.Windows.Forms.Timer(this.components);
            this.stopGoodTimer = new System.Windows.Forms.Timer(this.components);
            this.stopOnInvisibleTimer = new System.Windows.Forms.Timer(this.components);
            this.srcName = new System.Windows.Forms.Label();
            this.log = new System.Windows.Forms.ListBox();
            this.topPanel = new View.Components.TopPanel();
            this.hidePlayerPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // controlHideTimer
            // 
            this.controlHideTimer.Interval = 10000;
            // 
            // nameHideTimer
            // 
            this.nameHideTimer.Interval = 20000;
            // 
            // switchToBadTimer
            // 
            this.switchToBadTimer.Interval = 10000;
            // 
            // switchToGoodTimer
            // 
            this.switchToGoodTimer.Interval = 5000;
            // 
            // stopBadTimer
            // 
            this.stopBadTimer.Interval = 60000;
            // 
            // stopGoodTimer
            // 
            this.stopGoodTimer.Interval = 120000;
            // 
            // stopOnInvisibleTimer
            // 
            this.stopOnInvisibleTimer.Interval = 240000;
            // 
            // srcName
            // 
            this.srcName.AutoSize = true;
            this.srcName.BackColor = System.Drawing.Color.Black;
            this.srcName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.srcName.ForeColor = System.Drawing.Color.White;
            this.srcName.Location = new System.Drawing.Point(46, 18);
            this.srcName.Name = "srcName";
            this.srcName.Size = new System.Drawing.Size(59, 14);
            this.srcName.TabIndex = 0;
            this.srcName.Text = "nameLabel";
            // 
            // log
            // 
            this.log.FormattingEnabled = true;
            this.log.Location = new System.Drawing.Point(124, 84);
            this.log.Name = "log";
            this.log.ScrollAlwaysVisible = true;
            this.log.Size = new System.Drawing.Size(80, 108);
            this.log.TabIndex = 0;
            this.log.Visible = false;
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
            // hidePlayerPanel
            // 
            this.hidePlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hidePlayerPanel.ForeColor = System.Drawing.Color.White;
            this.hidePlayerPanel.Location = new System.Drawing.Point(0, 0);
            this.hidePlayerPanel.Name = "hidePlayerPanel";
            this.hidePlayerPanel.Size = new System.Drawing.Size(150, 150);
            this.hidePlayerPanel.TabIndex = 2;
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
        private Timer switchToGoodTimer;
        private Timer switchToBadTimer;
        private Timer stopBadTimer;
        private Timer stopGoodTimer;
        private Timer stopOnInvisibleTimer;
        private Label srcName;
        private TopPanel topPanel;
        private ListBox log;
        private Panel hidePlayerPanel;
    }
}
