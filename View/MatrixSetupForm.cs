using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RtspCameraView
{
    public partial class MatrixSetupForm : Form
    {
        int _sizeMaxX = 10;
        int _sizeMaxY = 10;
        int _lastX;
        int _lastY;

        public MatrixSetupForm()
        {
            InitializeComponent();
        }

        public int SizeMaxX
        {
            set { _sizeMaxX = value; }
        }

        public int SizeMaxY
        {
            set { _sizeMaxY = value; }
        }

        public int MatrixX
        {
            get { return Convert.ToInt32(sizeXinput.Text); }
            set { sizeXinput.Text = value.ToString(); _lastX = value; }
        }

        public int MatrixY
        {
            get { return Convert.ToInt32(sizeYinput.Text); }
            set { sizeYinput.Text = value.ToString(); _lastY = value; }
        }

        private void intInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    try
                    {
                        int v = Convert.ToInt32(((TextBox)sender).Text);
                        if (sender == sizeXinput && v < _sizeMaxX
                            || sender == sizeYinput && v < _sizeMaxY)
                        {
                            ((TextBox)sender).Text = (v + 1).ToString();
                        }
                    }
                    catch (Exception) { }
                    break;
                case Keys.Down:
                    try
                    {
                        int v = Convert.ToInt32(((TextBox)sender).Text);
                        if (v > 1) ((TextBox)sender).Text = (v - 1).ToString();
                        if (sender == sizeXinput)
                        {
                            if (v > _sizeMaxX) ((TextBox)sender).Text = _sizeMaxX.ToString();
                        }
                        else if (v > _sizeMaxY) ((TextBox)sender).Text = _sizeMaxY.ToString();
                    }
                    catch (Exception) { }
                    break;
                default:
                    base.OnKeyDown(e);
                    break;
            }
        }

        private void intInput_KeyUp(object sender, KeyEventArgs e)
        {
            ResizeGrid();
        }

        private void intInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }
        }

        public void ResizeGrid()
        {
            try
            {
                int x, y;
                x = Convert.ToInt32(sizeXinput.Text);
                y = Convert.ToInt32(sizeYinput.Text);
                if (!(x > 0 && y > 0 && (x != _lastX || y != _lastY) && x <= _sizeMaxX && y <= _sizeMaxY)) return; try { _lastX = Convert.ToInt32(sizeXinput.Text); } catch { }
                gridPanel.SuspendLayout();
                gridPanel.Controls.Clear();
                for (int ix = x - 1; ix >= 0; ix--)
                    for (int iy = y - 1; iy >= 0; iy--)
                    {
                        Button b = new Button
                        {
                            Size = new Size(100, 50),
                            Location = new Point(ix * 110, iy * 60),
                            Text = "(" + ix.ToString() + "," + iy.ToString() + ")",
                        };
                        gridPanel.Controls.Add(b);
                    }
                gridPanel.ResumeLayout();
                _lastX = x;
                _lastY = y;
            }
            catch { }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void combineButton_Click(object sender, EventArgs e)
        {

        }

        private void divideButton_Click(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {

        }

        private void hideButton_Click(object sender, EventArgs e)
        {

        }

        private void MatrixSetupForm_Shown(object sender, EventArgs e)
        {
            // resize height of window, to gridPanel be proportional screen size
        }
    }
}
