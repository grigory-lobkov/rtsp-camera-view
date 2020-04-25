using System;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Views;

namespace View.Components
{
    public partial class ModifySourceControl : UserControl, IModifySourceView
    {
        string emptySrcName;
        string emptyRtspBad;
        string emptyRtspGood;
        string emptyAspectRatio;
        Color emptyColor;
        Color textColor;

        public ModifySourceControl()
        {
            InitializeComponent();
            createCamButton.Location = saveCamButton.Location;
            camNameModify.Click += (sender, args) => Invoke(NameViewClick);
            createCamButton.Click += (sender, args) => Invoke(CreateClick);
            saveCamButton.Click += (sender, args) => Invoke(SaveClick);
            cancelCamButton.Click += (sender, args) => Invoke(CancelClick);
            emptySrcName = SrcName;
            emptyRtspBad = RtspBad;
            emptyRtspGood = RtspGood;
            emptyAspectRatio = AspectRatio;
            emptyColor = camName.ForeColor;
            textColor = SystemColors.WindowText;
            camName.Enter += (sender, args) => TextBoxEnter((TextBox)sender);
            rtspBad.Enter += (sender, args) => TextBoxEnter((TextBox)sender);
            rtspGood.Enter += (sender, args) => TextBoxEnter((TextBox)sender);
            aspectRatio.Enter += (sender, args) => TextBoxEnter((TextBox)sender);
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public string SrcName
        {
            get { return camName.ForeColor == emptyColor ? "" : camName.Text; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    { camName.ForeColor = emptyColor; camName.Text = emptySrcName; }
                else { camName.ForeColor = textColor; camName.Text = value; }
            }
        }
        public event Action NameViewClick;
        public string RtspBad
        {
            get { return rtspBad.ForeColor == emptyColor ? "" : rtspBad.Text; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    { rtspBad.ForeColor = emptyColor; rtspBad.Text = emptyRtspBad; }
                else { rtspBad.ForeColor = textColor; rtspBad.Text = value; }
            }
        }
        public string RtspGood
        {
            get { return rtspGood.ForeColor == emptyColor ? "" : rtspGood.Text; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    { rtspGood.ForeColor = emptyColor; rtspGood.Text = emptyRtspGood; }
                else { rtspGood.ForeColor = textColor; rtspGood.Text = value; }
            }
        }
        public string AspectRatio
        {
            get { return aspectRatio.ForeColor == emptyColor ? "" : aspectRatio.Text; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    { aspectRatio.ForeColor = emptyColor; aspectRatio.Text = emptyAspectRatio; }
                else { aspectRatio.ForeColor = textColor; aspectRatio.Text = value; }
            }
        }
        public int CamIcon {
            get { return cameraIcon.FocusedItem.Index; }
            set
            {
                try {
                    cameraIcon.Items[value].Focused = true; cameraIcon.Items[value].Selected = true;
                } catch { };
            }
        }
        private int _position;
        public int Position { get { return _position; } set { _position = value; } }
        public bool IsNewSource {
            get { return createCamButton.Visible; }
            set
            {
                createCamButton.Visible = value;
                saveCamButton.Visible = !value;
                delCamLabel.Visible = !value;
            }
        }
        public bool IsNameShow
        {
            get { return camNameShow.Checked; }
            set { camNameShow.Checked = value; }
        }
        public bool IsNameInherit
        {
            get { return camNameInherit.Checked; }
            set { camNameInherit.Checked = value; camNameModify.Enabled = !value; }
        }
        public event Action RtspBadEnter;
        public event Action RtspGoodEnter;
        private void TextBoxEnter(TextBox sender)
        {
            if (sender.ForeColor == emptyColor)
            {
                sender.ForeColor = textColor;
                sender.Text = "";
            }
            if (sender == rtspBad) Invoke(RtspBadEnter);
            if (sender == rtspGood) Invoke(RtspGoodEnter);
        }
        public int IsGoodOnlyInFullview
        {
            get { return rtspGoodOnlyInFullview.Checked ? 1 : 0; }
            set { rtspGoodOnlyInFullview.Checked = value == 1; }
        }

        public event Action CreateClick;
        public event Action SaveClick;
        public event Action CancelClick;
        public event Action DeleteClick;

        public new void Show()
        {
            Visible = true;
        }
        public new void Hide()
        {
            Visible = false;
        }
        public void SetImges(object imageList)
        {
            ImageList list = (ImageList)imageList;
            cameraIcon.LargeImageList = list;
            cameraIcon.SmallImageList = list;
            cameraIcon.TileSize =
                new Size(cameraIcon.LargeImageList.ImageSize.Width + 10, 
                cameraIcon.LargeImageList.ImageSize.Height + 2);
            foreach (string ikey in list.Images.Keys)
            {
                cameraIcon.Items.Add("", list.Images.IndexOfKey(ikey));
            }

        }

        private void DelCam_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(cameraDeleteConfirm1.Text + " ''" + camName.Text + "''?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;
            if (_position >= 0)
            {
                if (MessageBox.Show(cameraDeleteConfirm2.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    != DialogResult.Yes) return;
                Invoke(DeleteClick);
            }
            else Invoke(DeleteClick);
        }
        private void ButtonLabel_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }
        private void ButtonLabel_MouseLeave(object sender, EventArgs e)
        {
            if (sender == delCamLabel) ((Label)sender).ForeColor = Color.Red;
            else ((Label)sender).ForeColor = SystemColors.ControlText;
        }
        private void CamNameShow_CheckedChanged(object sender, EventArgs e)
        {
            camNameInherit.Enabled = camNameShow.Checked;
        }

        private void CamNameInherit_CheckedChanged(object sender, EventArgs e)
        {
            camNameModify.Enabled = !camNameInherit.Checked;
        }

        // Localization
        public string CamNameLabelText { set { if (value != "") camNameLabel.Text = value; } }
        public string CamNameText { set { if (value != "") { camName.Text = value; emptySrcName = value; } } }
        public string CamNameShowText { set { if (value != "") camNameShow.Text = value; } }
        public string CamNameInheritText { set { if (value != "") camNameInherit.Text = value; } }
        public string CamNameModifyText { set { if (value != "") camNameModify.Text = value; } }
        public string CamEditRtsp1LabelText { set { if (value != "") camEditRtsp1Label.Text = value; } }
        public string RtspBadText { set { if (value != "") { rtspBad.Text = value; emptyRtspBad = value; } } }
        public string CamEditRtsp2LabelText { set { if (value != "") camEditRtsp2Label.Text = value; } }
        public string RtspGoodText { set { if (value != "") { rtspGood.Text = value; emptyRtspGood = value; } } }
        public string CamEditIconLabelText { set { if (value != "") camEditIconLabel.Text = value; } }
        public string AspectRatioLabelText { set { if (value != "") aspectRatioLabel.Text = value; } }
        public string AspectRatioText { set { if (value != "") { aspectRatio.Text = value; emptyAspectRatio = value; } } }
        public string CreateCamButtonText { set { if (value != "") createCamButton.Text = value; } }
        public string SaveCamButtonText { set { if (value != "") saveCamButton.Text = value; } }
        public string CancelCamButtonText { set { if (value != "") cancelCamButton.Text = value; } }
        public string DelCamLabelText { set { if (value != "") delCamLabel.Text = value; } }
        public string CameraDeleteConfirm1Text { set { if (value != "") cameraDeleteConfirm1.Text = value; } }
        public string CameraDeleteConfirm2Text { set { if (value != "") cameraDeleteConfirm2.Text = value; } }
        public string RtspGoodOnlyInFullviewText { set { if (value != "") rtspGoodOnlyInFullview.Text = value; } }

    }
}
