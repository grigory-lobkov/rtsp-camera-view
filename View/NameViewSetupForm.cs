using System;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Views;

namespace View
{
    public partial class NameViewSetupForm : Form, INameViewSetupView
    {
        private readonly ApplicationContext _context;

        private int _position;
        public int Position {
            get { return _position; }
            set { _position = value; RefreshPositionBottons(); }
        }

        public Color TextColor {
            get { return textColorPanel.BackColor; }
            set { textColorPanel.BackColor = value; RefreshPositionBottons(); }
        }

        public bool BgEnabled
        {
            get { return backgroundCheckBox.Checked; }
            set { backgroundCheckBox.Checked = value; RefreshPositionBottons(); }
        }

        public Color BgColor {
            get { return backgroundPanel.BackColor; }
            set { backgroundPanel.BackColor = value; RefreshPositionBottons(); }
        }

        public int TextSize
        {
            get { return textSizeTrackBar.Value; }
            set { textSizeTrackBar.Value = value; }
        }

        public bool AutoHideEnabled
        {
            get { return autoHideCheckBox.Checked; }
            set
            {
                autoHideCheckBox.Checked = value;
                autoHideTrackBar.Enabled = value;
            }
        }

        public int AutoHideSec
        {
            get { return autoHideTrackBar.Value; }
            set { autoHideTrackBar.Value = value; }
        }

        public event Action OkClick;
        public event Action CancelClick;

        public NameViewSetupForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            okButton.Click += (sender, args) => Invoke(OkClick);
            cancelButton.Click += (sender, args) => Invoke(CancelClick);
            backgroundCheckBox.CheckedChanged += (sender, args) => RefreshPositionBottons();
            topLeftButton.Click += (sender, args) => RefreshPositionBottons(1);
            topCenterButton.Click += (sender, args) => RefreshPositionBottons(2);
            topRightButton.Click += (sender, args) => RefreshPositionBottons(3);
            bottomLeftButton.Click += (sender, args) => RefreshPositionBottons(7);
            bottomCenterButton.Click += (sender, args) => RefreshPositionBottons(8);
            bottomRightButton.Click += (sender, args) => RefreshPositionBottons(9);
            textColorPanel.MouseDoubleClick += (sender, args) => TextColorButton_Click(sender, null);
            backgroundPanel.MouseDoubleClick += (sender, args) => BackgroundButton_Click(sender, null);
        }

        public new void Show()
        {
            ShowDialog();
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }



        /*****
         *      Positioning area actions
         */
        private void RefreshPositionBottons(int position = 0)
        {
            if (position > 0) _position = position;
            if (_position > 0)
            {
                RefreshPositionBotton(topLeftButton, _position == 1);
                RefreshPositionBotton(topCenterButton, _position == 2);
                RefreshPositionBotton(topRightButton, _position == 3);
                RefreshPositionBotton(bottomLeftButton, _position == 7);
                RefreshPositionBotton(bottomCenterButton, _position == 8);
                RefreshPositionBotton(bottomRightButton, _position == 9);
            }
        }

        private void RefreshPositionBotton(Button b, bool selected)
        {
            b.Text = selected ? camNameLabel.Text : null;
            if (backgroundCheckBox.Checked)
                b.BackColor = selected ? backgroundPanel.BackColor : Color.Transparent;
            else b.BackColor = Color.Transparent;
            b.ForeColor = selected ? textColorPanel.BackColor : SystemColors.ControlText;
        }
        
        /*****
         *      Color area actions
         */
        private void TextColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = textColorPanel.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textColorPanel.BackColor = colorDialog.Color;
                RefreshPositionBottons();
            }
        }

        private void BackgroundButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = backgroundPanel.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                backgroundPanel.BackColor = colorDialog.Color;
                RefreshPositionBottons();
            }
        }

        private void AutoHideCheckBox_Click(object sender, EventArgs e)
        {
            autoHideTrackBar.Enabled = autoHideCheckBox.Checked;
        }

        // Localization
        public string ThisText { set { if (value != "") this.Text = value; } }
        public string PositioningLabelText { set { if (value != "") positioningLabel.Text = value; } }
        public string CamNameLabelText { set { if (value != "") camNameLabel.Text = value; } }
        public string TextColorLabelText { set { if (value != "") textColorLabel.Text = value; } }
        public string BackgroundCheckBoxText { set { if (value != "") backgroundCheckBox.Text = value; } }
        public string TextSizeLabelText { set { if (value != "") textSizeLabel.Text = value; } }
        public string AutoHideCheckBoxText { set { if (value != "") autoHideCheckBox.Text = value; } }
        public string OkButtonText { set { if (value != "") okButton.Text = value; } }
        public string CancelButtonText { set { if (value != "") cancelButton.Text = value; } }

    }
}
