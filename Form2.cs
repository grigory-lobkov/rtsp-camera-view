using System;
using System.Drawing;
using System.Windows.Forms;

/********************
 * Copyright 2018 Grigory Lobkov
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 *
 * You may obtain a copy of the License at
 * https://github.com/grigory-lobkov/rtsp-camera-view/blob/master/LICENSE
 *
 ********************/

namespace RTSP_mosaic_VLC_player
{
    public partial class CamNameConfigForm : Form
    {
        public event EventHandler onSaveClick;
        public event EventHandler onCancelClick;
        private NameView nameView;
        private NameView nameViewGlb;
        public NameView NameView { get { return getNameView(); } set { setNameView(value); } }

        public CamNameConfigForm()
        {
            InitializeComponent();
            nameView = new NameView();
        }

        private void CamNameConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            cancelButton_Click(null, null);
        }
        private void okButton_Click(object sender, EventArgs e)
        {
            onSaveClick(this, null);
            Hide();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            onCancelClick(this, null);
            nameViewGlb.SaveTo(nameView);
            Hide();
        }

        // Set Form parameters
        private void setNameView(NameView nv)
        {
            nameViewGlb = nv;
            nv.SaveTo(nameView);
            repaintView();
            autoHideCheckBox.Checked = nameView.autoHide;
            autoHideTrackBar.Enabled = nameView.autoHide;
            textSizeTrackBar.Value = nameView.size;
            autoHideTrackBar.Value = nameView.autoHideSec;
        }

        private NameView getNameView()
        {
            nameView.SaveTo(nameViewGlb);
            return nameViewGlb;
        }

        // Repaint Positioning area
        private void repaintView()
        {
            TextPosition pos = nameView.position;
            repaintPositionBotton(topLeftButton, pos == TextPosition.TopLeft);
            repaintPositionBotton(topCenterButton, pos == TextPosition.TopCenter);
            repaintPositionBotton(topRightButton, pos == TextPosition.TopRight);
            repaintPositionBotton(bottomLeftButton, pos == TextPosition.BottomLeft);
            repaintPositionBotton(bottomCenterButton, pos == TextPosition.BottomCenter);
            repaintPositionBotton(bottomRightButton, pos == TextPosition.BottomRight);
            textColorPanel.BackColor = nameView.color;
            backgroundPanel.BackColor = nameView.bgColor;
            backgroundCheckBox.Checked = nameView.paintBg;
        }
        // Repaint one botton state, used in repaintPosition()
        private void repaintPositionBotton(Button b, bool selected)
        {
            b.Text = selected ? camNameLabel.Text : null;
            if (backgroundCheckBox.Checked)
                b.BackColor = selected ? nameView.bgColor : Color.Transparent;
            else b.BackColor = Color.Transparent;
            b.ForeColor = selected ? nameView.color : SystemColors.ControlText;
        }


        /*****
         *      Positioning area actions
         */
        private void topLeftButton_Click(object sender, EventArgs e)
        {
            nameView.position = TextPosition.TopLeft;
            repaintView();
        }
        private void topCenterButton_Click(object sender, EventArgs e)
        {
            nameView.position = TextPosition.TopCenter;
            repaintView();
        }
        private void topRightButton_Click(object sender, EventArgs e)
        {
            nameView.position = TextPosition.TopRight;
            repaintView();
        }
        private void bottomLeftButton_Click(object sender, EventArgs e)
        {
            nameView.position = TextPosition.BottomLeft;
            repaintView();
        }
        private void bottomCenterButton_Click(object sender, EventArgs e)
        {
            nameView.position = TextPosition.BottomCenter;
            repaintView();
        }
        private void bottomRightButton_Click(object sender, EventArgs e)
        {
            nameView.position = TextPosition.BottomRight;
            repaintView();
        }

        /*****
         *      Color area actions
         */
        private void textColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = nameView.color;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                nameView.color = colorDialog.Color;
                repaintView();
            }
        }
        private void textColorPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textColorButton_Click(sender, null);
        }
        private void backgroundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            nameView.paintBg = backgroundCheckBox.Checked;
            repaintView();
        }
        private void backgroundButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = nameView.bgColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                nameView.bgColor = colorDialog.Color;
                repaintView();
            }
        }
        private void backgroundPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            backgroundButton_Click(sender, null);
        }

        /*****
         *      Trackbar area actions
         */
        private void textSizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            nameView.size = textSizeTrackBar.Value;
        }

        private void autoHideCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            nameView.autoHide = autoHideCheckBox.Checked;
            autoHideTrackBar.Enabled = nameView.autoHide;
        }

        private void autoHideTrackBar_ValueChanged(object sender, EventArgs e)
        {
            nameView.autoHideSec = autoHideTrackBar.Value;
        }

    }
}
