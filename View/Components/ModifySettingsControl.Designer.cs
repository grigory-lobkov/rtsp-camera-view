using System.Windows.Forms;

namespace View.Components
{
    partial class ModifySettingsControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifySettingsControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.githubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.commandLineHelpButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.applyMatrixSize = new System.Windows.Forms.Label();
            this.matrixYinput = new System.Windows.Forms.TextBox();
            this.matrixXinput = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.matrixDimensionsLabel = new System.Windows.Forms.Label();
            this.camNameViewGlbButton = new System.Windows.Forms.Button();
            this.commandLineHelp = new System.Windows.Forms.Label();
            this.alertSetupButton = new System.Windows.Forms.Button();
            this.matrixSetupButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.githubLinkLabel);
            this.panel1.Controls.Add(this.commandLineHelpButton);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // githubLinkLabel
            // 
            resources.ApplyResources(this.githubLinkLabel, "githubLinkLabel");
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.TabStop = true;
            // 
            // commandLineHelpButton
            // 
            resources.ApplyResources(this.commandLineHelpButton, "commandLineHelpButton");
            this.commandLineHelpButton.Name = "commandLineHelpButton";
            this.commandLineHelpButton.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.applyMatrixSize);
            this.panel2.Controls.Add(this.matrixYinput);
            this.panel2.Controls.Add(this.matrixXinput);
            this.panel2.Controls.Add(this.xLabel);
            this.panel2.Name = "panel2";
            // 
            // applyMatrixSize
            // 
            resources.ApplyResources(this.applyMatrixSize, "applyMatrixSize");
            this.applyMatrixSize.Name = "applyMatrixSize";
            this.applyMatrixSize.Click += new System.EventHandler(this.ApplyMatrixSize_Click);
            this.applyMatrixSize.MouseEnter += new System.EventHandler(this.ApplyMatrixSize_MouseEnter);
            this.applyMatrixSize.MouseLeave += new System.EventHandler(this.ApplyMatrixSize_MouseLeave);
            // 
            // matrixYinput
            // 
            resources.ApplyResources(this.matrixYinput, "matrixYinput");
            this.matrixYinput.Name = "matrixYinput";
            this.matrixYinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MatrixInput_KeyDown);
            this.matrixYinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MatrixInput_KeyPress);
            this.matrixYinput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MatrixInput_KeyUp);
            // 
            // matrixXinput
            // 
            resources.ApplyResources(this.matrixXinput, "matrixXinput");
            this.matrixXinput.Name = "matrixXinput";
            this.matrixXinput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MatrixInput_KeyDown);
            this.matrixXinput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MatrixInput_KeyPress);
            this.matrixXinput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MatrixInput_KeyUp);
            // 
            // xLabel
            // 
            resources.ApplyResources(this.xLabel, "xLabel");
            this.xLabel.Name = "xLabel";
            // 
            // matrixDimensionsLabel
            // 
            resources.ApplyResources(this.matrixDimensionsLabel, "matrixDimensionsLabel");
            this.matrixDimensionsLabel.Name = "matrixDimensionsLabel";
            // 
            // camNameViewGlbButton
            // 
            resources.ApplyResources(this.camNameViewGlbButton, "camNameViewGlbButton");
            this.camNameViewGlbButton.Name = "camNameViewGlbButton";
            this.camNameViewGlbButton.UseVisualStyleBackColor = true;
            // 
            // commandLineHelp
            // 
            resources.ApplyResources(this.commandLineHelp, "commandLineHelp");
            this.commandLineHelp.Name = "commandLineHelp";
            // 
            // alertSetupButton
            // 
            resources.ApplyResources(this.alertSetupButton, "alertSetupButton");
            this.alertSetupButton.Name = "alertSetupButton";
            this.alertSetupButton.UseVisualStyleBackColor = true;
            // 
            // matrixSetupButton
            // 
            resources.ApplyResources(this.matrixSetupButton, "matrixSetupButton");
            this.matrixSetupButton.Name = "matrixSetupButton";
            this.matrixSetupButton.UseVisualStyleBackColor = true;
            // 
            // ModifySettingsControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.matrixSetupButton);
            this.Controls.Add(this.alertSetupButton);
            this.Controls.Add(this.commandLineHelp);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.matrixDimensionsLabel);
            this.Controls.Add(this.camNameViewGlbButton);
            this.Controls.Add(this.panel1);
            this.Name = "ModifySettingsControl";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private LinkLabel githubLinkLabel;
        private Button commandLineHelpButton;
        private Panel panel2;
        private Label applyMatrixSize;
        private TextBox matrixYinput;
        private TextBox matrixXinput;
        private Label xLabel;
        private Label matrixDimensionsLabel;
        private Button camNameViewGlbButton;
        private Label commandLineHelp;
        private Button alertSetupButton;
        private Button matrixSetupButton;
    }
}
