namespace View
{
    partial class AlertSetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertSetupForm));
            this.emailPage = new System.Windows.Forms.TabPage();
            this.emFromLabel = new System.Windows.Forms.Label();
            this.emToLabel = new System.Windows.Forms.Label();
            this.emFromTextBox = new System.Windows.Forms.TextBox();
            this.emToTextBox = new System.Windows.Forms.TextBox();
            this.emLostMinTextBox = new System.Windows.Forms.TextBox();
            this.emServerGroupBox = new System.Windows.Forms.GroupBox();
            this.emTestLinkLabel = new System.Windows.Forms.LinkLabel();
            this.emPasswordLabel = new System.Windows.Forms.Label();
            this.emPasswordTextBox = new System.Windows.Forms.TextBox();
            this.emUsernameLabel = new System.Windows.Forms.Label();
            this.emUsernameTextBox = new System.Windows.Forms.TextBox();
            this.emPortLabel = new System.Windows.Forms.Label();
            this.emPortTextBox = new System.Windows.Forms.TextBox();
            this.emNameTextBox = new System.Windows.Forms.TextBox();
            this.emNameLabel = new System.Windows.Forms.Label();
            this.emRecoverCheckBox = new System.Windows.Forms.CheckBox();
            this.emLostCheckBox = new System.Windows.Forms.CheckBox();
            this.typeTabControl = new System.Windows.Forms.TabControl();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.emailPage.SuspendLayout();
            this.emServerGroupBox.SuspendLayout();
            this.typeTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // emailPage
            // 
            this.emailPage.Controls.Add(this.emFromLabel);
            this.emailPage.Controls.Add(this.emToLabel);
            this.emailPage.Controls.Add(this.emFromTextBox);
            this.emailPage.Controls.Add(this.emToTextBox);
            this.emailPage.Controls.Add(this.emLostMinTextBox);
            this.emailPage.Controls.Add(this.emServerGroupBox);
            this.emailPage.Controls.Add(this.emRecoverCheckBox);
            this.emailPage.Controls.Add(this.emLostCheckBox);
            resources.ApplyResources(this.emailPage, "emailPage");
            this.emailPage.Name = "emailPage";
            this.emailPage.UseVisualStyleBackColor = true;
            // 
            // emFromLabel
            // 
            resources.ApplyResources(this.emFromLabel, "emFromLabel");
            this.emFromLabel.Name = "emFromLabel";
            // 
            // emToLabel
            // 
            resources.ApplyResources(this.emToLabel, "emToLabel");
            this.emToLabel.Name = "emToLabel";
            // 
            // emFromTextBox
            // 
            resources.ApplyResources(this.emFromTextBox, "emFromTextBox");
            this.emFromTextBox.Name = "emFromTextBox";
            // 
            // emToTextBox
            // 
            resources.ApplyResources(this.emToTextBox, "emToTextBox");
            this.emToTextBox.Name = "emToTextBox";
            // 
            // emLostMinTextBox
            // 
            resources.ApplyResources(this.emLostMinTextBox, "emLostMinTextBox");
            this.emLostMinTextBox.Name = "emLostMinTextBox";
            this.emLostMinTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumberInput_KeyDown);
            this.emLostMinTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberInput_KeyPress);
            // 
            // emServerGroupBox
            // 
            this.emServerGroupBox.Controls.Add(this.emTestLinkLabel);
            this.emServerGroupBox.Controls.Add(this.emPasswordLabel);
            this.emServerGroupBox.Controls.Add(this.emPasswordTextBox);
            this.emServerGroupBox.Controls.Add(this.emUsernameLabel);
            this.emServerGroupBox.Controls.Add(this.emUsernameTextBox);
            this.emServerGroupBox.Controls.Add(this.emPortLabel);
            this.emServerGroupBox.Controls.Add(this.emPortTextBox);
            this.emServerGroupBox.Controls.Add(this.emNameTextBox);
            this.emServerGroupBox.Controls.Add(this.emNameLabel);
            resources.ApplyResources(this.emServerGroupBox, "emServerGroupBox");
            this.emServerGroupBox.Name = "emServerGroupBox";
            this.emServerGroupBox.TabStop = false;
            // 
            // emTestLinkLabel
            // 
            resources.ApplyResources(this.emTestLinkLabel, "emTestLinkLabel");
            this.emTestLinkLabel.LinkColor = System.Drawing.Color.DarkBlue;
            this.emTestLinkLabel.Name = "emTestLinkLabel";
            this.emTestLinkLabel.TabStop = true;
            // 
            // emPasswordLabel
            // 
            resources.ApplyResources(this.emPasswordLabel, "emPasswordLabel");
            this.emPasswordLabel.Name = "emPasswordLabel";
            // 
            // emPasswordTextBox
            // 
            resources.ApplyResources(this.emPasswordTextBox, "emPasswordTextBox");
            this.emPasswordTextBox.Name = "emPasswordTextBox";
            this.emPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // emUsernameLabel
            // 
            resources.ApplyResources(this.emUsernameLabel, "emUsernameLabel");
            this.emUsernameLabel.Name = "emUsernameLabel";
            // 
            // emUsernameTextBox
            // 
            resources.ApplyResources(this.emUsernameTextBox, "emUsernameTextBox");
            this.emUsernameTextBox.Name = "emUsernameTextBox";
            // 
            // emPortLabel
            // 
            resources.ApplyResources(this.emPortLabel, "emPortLabel");
            this.emPortLabel.Name = "emPortLabel";
            // 
            // emPortTextBox
            // 
            resources.ApplyResources(this.emPortTextBox, "emPortTextBox");
            this.emPortTextBox.Name = "emPortTextBox";
            this.emPortTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumberInput_KeyDown);
            this.emPortTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberInput_KeyPress);
            // 
            // emNameTextBox
            // 
            resources.ApplyResources(this.emNameTextBox, "emNameTextBox");
            this.emNameTextBox.Name = "emNameTextBox";
            // 
            // emNameLabel
            // 
            resources.ApplyResources(this.emNameLabel, "emNameLabel");
            this.emNameLabel.Name = "emNameLabel";
            // 
            // emRecoverCheckBox
            // 
            resources.ApplyResources(this.emRecoverCheckBox, "emRecoverCheckBox");
            this.emRecoverCheckBox.Name = "emRecoverCheckBox";
            this.emRecoverCheckBox.UseVisualStyleBackColor = true;
            // 
            // emLostCheckBox
            // 
            resources.ApplyResources(this.emLostCheckBox, "emLostCheckBox");
            this.emLostCheckBox.Name = "emLostCheckBox";
            this.emLostCheckBox.UseVisualStyleBackColor = true;
            // 
            // typeTabControl
            // 
            resources.ApplyResources(this.typeTabControl, "typeTabControl");
            this.typeTabControl.Controls.Add(this.emailPage);
            this.typeTabControl.Name = "typeTabControl";
            this.typeTabControl.SelectedIndex = 0;
            // 
            // okButton
            // 
            resources.ApplyResources(this.okButton, "okButton");
            this.okButton.Name = "okButton";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // AlertSetupForm
            // 
            this.AcceptButton = this.okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.typeTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AlertSetupForm";
            this.emailPage.ResumeLayout(false);
            this.emailPage.PerformLayout();
            this.emServerGroupBox.ResumeLayout(false);
            this.emServerGroupBox.PerformLayout();
            this.typeTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage emailPage;
        private System.Windows.Forms.CheckBox emRecoverCheckBox;
        private System.Windows.Forms.CheckBox emLostCheckBox;
        private System.Windows.Forms.TabControl typeTabControl;
        private System.Windows.Forms.GroupBox emServerGroupBox;
        private System.Windows.Forms.Label emPortLabel;
        private System.Windows.Forms.TextBox emPortTextBox;
        private System.Windows.Forms.TextBox emNameTextBox;
        private System.Windows.Forms.Label emNameLabel;
        private System.Windows.Forms.Label emPasswordLabel;
        private System.Windows.Forms.TextBox emPasswordTextBox;
        private System.Windows.Forms.Label emUsernameLabel;
        private System.Windows.Forms.TextBox emUsernameTextBox;
        private System.Windows.Forms.TextBox emLostMinTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.LinkLabel emTestLinkLabel;
        private System.Windows.Forms.Label emFromLabel;
        private System.Windows.Forms.Label emToLabel;
        private System.Windows.Forms.TextBox emFromTextBox;
        private System.Windows.Forms.TextBox emToTextBox;
    }
}