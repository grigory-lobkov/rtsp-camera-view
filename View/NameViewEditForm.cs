using System;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Views;

namespace View
{
    public partial class NameViewEditForm : Form, INameViewEditView
    {
        private readonly ApplicationContext _context;

        private int _position;
        public int Position {
            get { return _position; }
            set { _position = value; refreshPositionBottons(); }
        }

        public Color TextColor {
            get { return textColorPanel.BackColor; }
            set { textColorPanel.BackColor = value; refreshPositionBottons(); }
        }

        public bool BgEnabled
        {
            get { return backgroundCheckBox.Checked; }
            set { backgroundCheckBox.Checked = value; refreshPositionBottons(); }
        }

        public Color BgColor {
            get { return backgroundPanel.BackColor; }
            set { backgroundPanel.BackColor = value; refreshPositionBottons(); }
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

        public NameViewEditForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();
            okButton.Click += (sender, args) => Invoke(OkClick);
            cancelButton.Click += (sender, args) => Invoke(CancelClick);
            backgroundCheckBox.CheckedChanged += (sender, args) => refreshPositionBottons();
            topLeftButton.Click += (sender, args) => refreshPositionBottons(1);
            topCenterButton.Click += (sender, args) => refreshPositionBottons(2);
            topRightButton.Click += (sender, args) => refreshPositionBottons(3);
            bottomLeftButton.Click += (sender, args) => refreshPositionBottons(7);
            bottomCenterButton.Click += (sender, args) => refreshPositionBottons(8);
            bottomRightButton.Click += (sender, args) => refreshPositionBottons(9);
            textColorPanel.MouseDoubleClick += (sender, args) => textColorButton_Click(sender, null);
            backgroundPanel.MouseDoubleClick += (sender, args) => backgroundButton_Click(sender, null);
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
        private void refreshPositionBottons(int position = 0)
        {
            if (position > 0) _position = position;
            if (_position > 0)
            {
                refreshPositionBotton(topLeftButton, _position == 1);
                refreshPositionBotton(topCenterButton, _position == 2);
                refreshPositionBotton(topRightButton, _position == 3);
                refreshPositionBotton(bottomLeftButton, _position == 7);
                refreshPositionBotton(bottomCenterButton, _position == 8);
                refreshPositionBotton(bottomRightButton, _position == 9);
            }
        }

        private void refreshPositionBotton(Button b, bool selected)
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
        private void textColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = textColorPanel.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textColorPanel.BackColor = colorDialog.Color;
                refreshPositionBottons();
            }
        }

        private void backgroundButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = backgroundPanel.BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                backgroundPanel.BackColor = colorDialog.Color;
                refreshPositionBottons();
            }
        }

        private void autoHideCheckBox_Click(object sender, EventArgs e)
        {
            autoHideTrackBar.Enabled = autoHideCheckBox.Checked;
        }

    }
}
