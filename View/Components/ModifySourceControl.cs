using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
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
            createCam.Location = saveCam.Location;
            camNameModify.Click += (sender, args) => Invoke(NameViewClick);
            createCam.Click += (sender, args) => Invoke(CreateClick);
            saveCam.Click += (sender, args) => Invoke(SaveClick);
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
                if (value == "") { camName.ForeColor = emptyColor; camName.Text = emptySrcName; }
                else { camName.ForeColor = textColor; camName.Text = value; }
            }
        }
        public event Action NameViewClick;
        public string RtspBad
        {
            get { return rtspBad.ForeColor == emptyColor ? "" : rtspBad.Text; }
            set
            {
                if (value == "") { rtspBad.ForeColor = emptyColor; rtspBad.Text = emptyRtspBad; }
                else { rtspBad.ForeColor = textColor; rtspBad.Text = value; }
            }
        }
        public string RtspGood
        {
            get { return rtspGood.ForeColor == emptyColor ? "" : rtspGood.Text; }
            set
            {
                if (value == "") { rtspGood.ForeColor = emptyColor; rtspGood.Text = emptyRtspGood; }
                else { rtspGood.ForeColor = textColor; rtspGood.Text = value; }
            }
        }
        public string AspectRatio
        {
            get { return aspectRatio.ForeColor == emptyColor ? "" : aspectRatio.Text; }
            set
            {
                if (value == "") { aspectRatio.ForeColor = emptyColor; aspectRatio.Text = emptyAspectRatio; }
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
            get { return createCam.Visible; }
            set
            {
                createCam.Visible = value;
                saveCam.Visible = !value;
                delCam.Visible = !value;
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
            set { camNameInherit.Checked = value; }
        }
        private void TextBoxEnter(TextBox sender)
        {
            if (sender.ForeColor == emptyColor)
            {
                sender.ForeColor = textColor;
                sender.Text = "";
            }
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

        private void delCam_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(cameraDeleteConfirm1.Text + " ''" + camName.Text + "''?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;
            if (_position >= 0)
            {
                if (MessageBox.Show(cameraDeleteConfirm2.Text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    != DialogResult.Yes) return;
                Invoke(DeleteClick);
            }
        }
        private void ButtonLabel_MouseEnter(object sender, EventArgs e)
        {
            ((Label)sender).ForeColor = Color.Blue;
        }
        private void ButtonLabel_MouseLeave(object sender, EventArgs e)
        {
            if (sender == delCam) ((Label)sender).ForeColor = Color.Red;
            else ((Label)sender).ForeColor = SystemColors.ControlText;
        }
        private void camNameShow_CheckedChanged(object sender, EventArgs e)
        {
            camNameInherit.Enabled = camNameShow.Checked;
        }

        private void camNameInherit_CheckedChanged(object sender, EventArgs e)
        {
            camNameModify.Enabled = !camNameInherit.Checked;
        }
    }
}
