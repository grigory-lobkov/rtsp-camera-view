using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Views;

namespace View
{
    public partial class MatrixSetupForm : Form, IMatrixSetupView
    {
        int _sizeMaxX = 10;
        int _sizeMaxY = 10;
        //int _lastX;
        //int _lastY;

        public event Action SaveClick;
        public event Action CancelClick;
        public event Action SizeChange;
        public event Action CombineClick;
        public event Action DivideClick;
        public event Action ShowClick;
        public event Action HideClick;

        public MatrixSetupForm()
        {
            InitializeComponent();
            saveButton.Click += (sender, args) => Invoke(SaveClick);
            cancelButton.Click += (sender, args) => Invoke(CancelClick);
            this.Resize += MatrixSetupForm_Resize;
            gridPanel.Dock = DockStyle.Fill;
            topPanel.Dock = DockStyle.Fill;
            topPanel.BringToFront();
            topPanel.RepaintBackground += gridPanel.Refresh;
            topPanel.FinishSelect += FinishSelect;
            combineButton.Click += (sender, args) => Invoke(CombineClick);
            divideButton.Click += (sender, args) => Invoke(DivideClick);
            showButton.Click += (sender, args) => Invoke(ShowClick);
            hideButton.Click += (sender, args) => Invoke(HideClick);
        }

        public new void Show()
        {
            ShowDialog();
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public int SizeMaxX
        {
            set { _sizeMaxX = value; }
        }

        public int SizeMaxY
        {
            set { _sizeMaxY = value; }
        }

        public int SizeX
        {
            get { return Convert.ToInt32(sizeXinput.Text); }
            set { sizeXinput.Text = value.ToString(); /*_lastX = value;*/ }
        }

        public int SizeY
        {
            get { return Convert.ToInt32(sizeYinput.Text); }
            set { sizeYinput.Text = value.ToString(); /*_lastY = value;*/ }
        }

        private void IntInput_KeyDown(object sender, KeyEventArgs e)
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

        private void IntInput_KeyUp(object sender, KeyEventArgs e)
        {
            //ResizeGrid();
            Invoke(SizeChange);
        }

        private void IntInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) { e.Handled = true; }
        }

        /*public void ResizeGrid()
        {
            try
            {
                int x, y;
                x = Convert.ToInt32(sizeXinput.Text);
                y = Convert.ToInt32(sizeYinput.Text);
                if (!(x > 0 && y > 0 && (x != _lastX || y != _lastY) && x <= _sizeMaxX && y <= _sizeMaxY)) return; try { _lastX = Convert.ToInt32(sizeXinput.Text); } catch { }
                gridPanel.SuspendLayout();
                gridPanel.Controls.Clear();
                int sx = gridPanel.ClientSize.Width / x,
                    sy = gridPanel.ClientSize.Height / y;
                Size bsize = new Size (sx * 98 / 99 - 1, sy * 79 / 80 - 1);
                for (int ix = x - 1; ix >= 0; ix--)
                    for (int iy = y - 1; iy >= 0; iy--)
                    {
                        Button b = new Button
                        {
                            Size = bsize,
                            Location = new Point(ix * sx, iy * sy),
                            Text = "(" + ix.ToString() + "," + iy.ToString() + ")",
                        };
                        gridPanel.Controls.Add(b);
                    }
                gridPanel.ResumeLayout();
                _lastX = x;
                _lastY = y;
            }
            catch { }
        }*/

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CombineButton_Click(object sender, EventArgs e)
        {

        }

        private void DivideButton_Click(object sender, EventArgs e)
        {

        }

        private void ShowButton_Click(object sender, EventArgs e)
        {

        }

        private void HideButton_Click(object sender, EventArgs e)
        {

        }

        private void MatrixSetupForm_Shown(object sender, EventArgs e)
        {
            // resize height of window, to gridPanel be proportional screen size
        }

        List<GridItem> _items = new List<GridItem>();

        public object NewItem(int x, int y)
        {
            Button b = new Button
            {
                Text = "(" + x.ToString() + "," + y.ToString() + ")",
                //BackColor = Color.Red,
                //ForeColor = Color.Green,
            };
            return b;
        }

        public void Clear()
        {
            foreach (GridItem i in _items)
            {
                Controls.Remove(i.control);
                i.control.Dispose();
            }
            _items.Clear();
        }

        public void AddItem(object obj, int gx, int gy, float x, float y, float w, float h)
        {
            gridPanel.SuspendLayout();
            Control control = (Control)obj;
            gridPanel.Controls.Add(control);
            _items.Add(new GridItem(control, gx, gy, x, y, w, h));
            control.SendToBack();
            control.MouseDown += Control_MouseDown;
            control.MouseMove += Control_MouseMove;
            control.MouseUp += Control_MouseUp;
            gridPanel.ResumeLayout(false);
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ModifyItem(object obj, float x, float y, float w, float h)
        {
            foreach (GridItem i in _items)
            {
                if (i.control == obj)
                {
                    i.x = x;
                    i.y = y;
                    i.w = w;
                    i.h = h;
                }
            }
        }

        public void Repaint()
        {
            int h = gridPanel.ClientRectangle.Height, w = gridPanel.ClientRectangle.Width;
            foreach (GridItem i in _items)
            {
                i.control.Location = new Point((int)(i.x * w), (int)(i.y * h));
                i.control.Size = new Size((int)(i.w * w), (int)(i.h * h));
            }
        }

        private void MatrixSetupForm_Resize(object sender, EventArgs e)
        {
            Repaint();
        }

        private int selX1 = -1, selX2, selY1, selY2;
        public int SelX1 { get => selX1; }
        public int SelX2 { get => selX2; }
        public int SelY1 { get => selY1; }
        public int SelY2 { get => selY2; }
        public void FinishSelect()
        {
            int x1, x2, y1, y2;
            selX1 = -1;
            foreach (GridItem i in _items)
            {
                i.control.BackColor = SystemColors.ControlLight;
                if (topPanel.x1 >= 0)
                {
                    x1 = i.control.Location.X;
                    x2 = x1 + i.control.Size.Width;
                    if (x1 < topPanel.x2 && x2 > topPanel.x1)
                    {
                        y1 = i.control.Location.Y;
                        y2 = y1 + i.control.Size.Height;
                        if (y1 < topPanel.y2 && y2 > topPanel.y1)
                        {
                            i.control.BackColor = Color.Orange;
                            if (selX1 == -1)
                            {
                                selX1 = i.gx;
                                selX2 = i.gx;
                                selY1 = i.gy;
                                selY2 = i.gy;
                            } else {
                                if (selX1 > i.gx) selX1 = i.gx;
                                else if(selX2 < i.gx) selX2 = i.gx;
                                if (selY1 > i.gy) selY1 = i.gy;
                                else if (selY2 < i.gy) selY2 = i.gy;
                            }
                        }
                    }
                }
            }
        }
    }



    public class GridItem
    {
        public Control control;
        public int gx;
        public int gy;
        public float x;
        public float y;
        public float w;
        public float h;
        public GridItem(Control Obj, int GX, int GY, float X, float Y, float W, float H)
        {
            control = Obj;
            gx = GX;
            gy = GY;
            x = X;
            y = Y;
            w = W;
            h = H;
        }
    }



    public class SelectRectPanel : Panel
    {
        public Color rectColor = Color.DarkOrange;
        public int x1 = -1, y1, x2, y2;
        //private int x3 = -1, y3, x4, y4;
        private bool paintRect = false;
        public bool enableRect = true; // enable painting
        public event Action RepaintBackground;
        public event Action FinishSelect;

        protected override void OnPaintBackground(PaintEventArgs e) { } //for transparency
        protected override CreateParams CreateParams //for transparency
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return cp;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (paintRect)
            {
                //if (x3 >= 0) e.Graphics.DrawRectangle(new Pen(this.BackColor), new Rectangle(
                //    new Point(Math.Min(x3, x4), Math.Min(y3, y4)), new Size(Math.Abs(x4 - x3), Math.Abs(y4 - y3))));
                RepaintBackground?.Invoke();
                if (x1 >= 0) e.Graphics.DrawRectangle(new Pen(this.rectColor,3), new Rectangle(
                    new Point(Math.Min(x1, x2), Math.Min(y1, y2)), new Size(Math.Abs(x2 - x1), Math.Abs(y2 - y1))));
                else paintRect = false;
                //x3 = x1; x4 = x2; y3 = y1; y4 = y2;
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (enableRect)
            {
                x2 = x1 = e.X;
                y2 = y1 = e.Y;
                paintRect = true;
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (paintRect)
            {
                x2 = e.X;
                y2 = e.Y;
                Invalidate();
            }
            base.OnMouseMove(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (enableRect)
            {
                //x2 = e.X; y2 = e.Y;
                x2 = Math.Max(x1, e.X);
                x1 = Math.Min(x1, e.X);
                y2 = Math.Max(y1, e.Y);
                y1 = Math.Min(y1, e.Y);
                FinishSelect?.Invoke();
                x1 = -1;
                Invalidate();
            }
        }
    }

}
