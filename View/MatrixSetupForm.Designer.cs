using System.Windows.Forms;

namespace View
{
    partial class MatrixSetupForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatrixSetupForm));
            this.controlPanel = new System.Windows.Forms.Panel();
            this.sizeYinput = new System.Windows.Forms.TextBox();
            this.splitButton = new System.Windows.Forms.Button();
            this.sizeXinput = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.joinButton = new System.Windows.Forms.Button();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.topPanel = new View.SelectRectPanel();
            this.controlPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.sizeYinput);
            this.controlPanel.Controls.Add(this.splitButton);
            this.controlPanel.Controls.Add(this.sizeXinput);
            this.controlPanel.Controls.Add(this.xLabel);
            this.controlPanel.Controls.Add(this.joinButton);
            resources.ApplyResources(this.controlPanel, "controlPanel");
            this.controlPanel.Name = "controlPanel";
            // 
            // sizeYinput
            // 
            resources.ApplyResources(this.sizeYinput, "sizeYinput");
            this.sizeYinput.Name = "sizeYinput";
            this.sizeYinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IntInput_KeyDown);
            this.sizeYinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInput_KeyPress);
            this.sizeYinput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IntInput_KeyUp);
            // 
            // splitButton
            // 
            resources.ApplyResources(this.splitButton, "splitButton");
            this.splitButton.Name = "splitButton";
            this.splitButton.UseVisualStyleBackColor = true;
            // 
            // sizeXinput
            // 
            resources.ApplyResources(this.sizeXinput, "sizeXinput");
            this.sizeXinput.Name = "sizeXinput";
            this.sizeXinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IntInput_KeyDown);
            this.sizeXinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntInput_KeyPress);
            this.sizeXinput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.IntInput_KeyUp);
            // 
            // xLabel
            // 
            resources.ApplyResources(this.xLabel, "xLabel");
            this.xLabel.Name = "xLabel";
            // 
            // joinButton
            // 
            resources.ApplyResources(this.joinButton, "joinButton");
            this.joinButton.Name = "joinButton";
            this.joinButton.UseVisualStyleBackColor = true;
            // 
            // gridPanel
            // 
            resources.ApplyResources(this.gridPanel, "gridPanel");
            this.gridPanel.Name = "gridPanel";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.saveButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // topPanel
            // 
            resources.ApplyResources(this.topPanel, "topPanel");
            this.topPanel.Name = "topPanel";
            // 
            // MatrixSetupForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MatrixSetupForm";
            this.Shown += new System.EventHandler(this.MatrixSetupForm_Shown);
            this.controlPanel.ResumeLayout(false);
            this.controlPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel controlPanel;
        private TextBox sizeYinput;
        private Button splitButton;
        private TextBox sizeXinput;
        private Label xLabel;
        private Button joinButton;
        private Panel gridPanel;
        private Panel panel1;
        private Button cancelButton;
        private Button saveButton;
        private SelectRectPanel topPanel;
    }
}