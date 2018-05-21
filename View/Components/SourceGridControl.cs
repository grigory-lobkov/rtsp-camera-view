using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presenter.Views;
using Presenter.Common;

namespace View.Components
{
    public partial class SourceGridControl : UserControl, ISourceGridView
    {
        List<GridItem> _items = new List<GridItem>();

        public SourceGridControl()
        {
            InitializeComponent();
            WatchDogTimer.Tick += (sender, args) => { WatchDogTimer.Enabled = false; Invoke(WatchDog); };
        }

        public void Clear()
        {
            foreach(GridItem i in _items) {
                Controls.Remove(i.control);
                i.control.Dispose();
            }
            _items.Clear();
        }

        public void AddItem(object obj, float x, float y, float w, float h)
        {
            this.SuspendLayout();
            Control control = (Control)obj;
            Controls.Add(control);
            _items.Add(new GridItem(control, x, y, w, h));
            this.ResumeLayout(false);
        }

        public void ModifyItem(object obj, float x, float y, float w, float h)
        {
            foreach (GridItem i in _items)
            {
                if(i.control==obj)
                {
                    i.x = x;
                    i.y = y;
                    i.w = w;
                    i.h = h;
                }
            }
        }

        public void SwapItems(object obj1, object obj2)
        {
            GridItem fi = null, ti = null;
            foreach (GridItem i in _items)
            {
                if (i.control == obj1) fi = i;
                if (i.control == obj2) ti = i;
            }
            if (fi != null && ti != null)
            {
                Control t = fi.control;
                fi.control = ti.control;
                ti.control = t;
            }
            Repaint();
        }

        public void Repaint()
        {
            if (!oneMaximized)
            {
                int h = ClientRectangle.Height, w = ClientRectangle.Width;
                foreach (GridItem i in _items)
                {
                    i.control.Location = new Point((int)(i.x * w), (int)(i.y * h));
                    i.control.Size = new Size((int)(i.w * w), (int)(i.h * h));
                }
            }
        }

        private void SourceGridControl_Resize(object sender, EventArgs e)
        {
            Repaint();
        }

        private bool oneMaximized = false;
        public bool OneMaximized
        {
            get => oneMaximized;
            set { oneMaximized = value; Repaint(); }
        }

        public event Action WatchDog;
        public bool WatchDogTimerEnabled
        {
            get => WatchDogTimer.Enabled;
            set { if (value) WatchDogTimer.Enabled = false; WatchDogTimer.Enabled = value; }
        }
    }

    public class GridItem
    {
        public Control control;
        public float x;
        public float y;
        public float w;
        public float h;
        public GridItem(Control Obj, float X, float Y, float W, float H)
        {
            control = Obj;
            x = X;
            y = Y;
            w = W;
            h = H;
        }
    }
}
