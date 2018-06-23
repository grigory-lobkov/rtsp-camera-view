namespace RtspCameraView
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
            this.sizeXinput = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.combineButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.showButton = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.controlPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.hideButton);
            this.controlPanel.Controls.Add(this.showButton);
            this.controlPanel.Controls.Add(this.sizeYinput);
            this.controlPanel.Controls.Add(this.divideButton);
            this.controlPanel.Controls.Add(this.sizeXinput);
            this.controlPanel.Controls.Add(this.xLabel);
            this.controlPanel.Controls.Add(this.combineButton);
            resources.ApplyResources(this.controlPanel, "controlPanel");
            this.controlPanel.Name = "controlPanel";
            // 
            // sizeYinput
            // 
            resources.ApplyResources(this.sizeYinput, "sizeYinput");
            this.sizeYinput.Name = "sizeYinput";
            this.sizeYinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.intInput_KeyDown);
            this.sizeYinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intInput_KeyPress);
            this.sizeYinput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.intInput_KeyUp);
            // 
            // sizeXinput
            // 
            resources.ApplyResources(this.sizeXinput, "sizeXinput");
            this.sizeXinput.Name = "sizeXinput";
            this.sizeXinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.intInput_KeyDown);
            this.sizeXinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.intInput_KeyPress);
            this.sizeXinput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.intInput_KeyUp);
            // 
            // xLabel
            // 
            resources.ApplyResources(this.xLabel, "xLabel");
            this.xLabel.Name = "xLabel";
            // 
            // combineButton
            // 
            resources.ApplyResources(this.combineButton, "combineButton");
            this.combineButton.Name = "combineButton";
            this.combineButton.UseVisualStyleBackColor = true;
            this.combineButton.Click += new System.EventHandler(this.combineButton_Click);
            // 
            // divideButton
            // 
            resources.ApplyResources(this.divideButton, "divideButton");
            this.divideButton.Name = "divideButton";
            this.divideButton.UseVisualStyleBackColor = true;
            this.divideButton.Click += new System.EventHandler(this.divideButton_Click);
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
            // saveButton
            // 
            resources.ApplyResources(this.saveButton, "saveButton");
            this.saveButton.Name = "saveButton";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // showButton
            // 
            resources.ApplyResources(this.showButton, "showButton");
            this.showButton.Name = "showButton";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // hideButton
            // 
            resources.ApplyResources(this.hideButton, "hideButton");
            this.hideButton.Name = "hideButton";
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // MatrixSetupForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridPanel);
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

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.TextBox sizeYinput;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.TextBox sizeXinput;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Button combineButton;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button hideButton;
        private System.Windows.Forms.Button showButton;
    }
}