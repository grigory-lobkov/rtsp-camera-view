using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Views;

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
            foreach (GridItem i in _items)
            {
                Controls.Remove(i.control);
                i.control.Dispose();
            }
            _items.Clear();
        }

        public void AddItem(object obj, float x, float y, float w, float h, int jw, int jh)
        {
            this.SuspendLayout();
            Control control = (Control)obj;
            Controls.Add(control);
            _items.Add(new GridItem(control, x, y, w, h, jw, jh));
            this.ResumeLayout(false);
        }

        public void ModifyItem(object obj, float x, float y, float w, float h, int jw, int jh)
        {
            foreach (GridItem i in _items)
            {
                if (i.control == obj)
                {
                    i.x = x;
                    i.y = y;
                    i.w = w;
                    i.h = h;
                    i.jw = jw;
                    i.jh = jh;
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
                    i.control.MinimumSize = new Size(i.jw, i.jh);
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

        public string EmLostSignalTitle { get => EmailOnLostSignalTitle.Text; }
        public string EmLostSignalSubject { get => EmailOnLostSignalSubject.Text; }
        public string EmRestoreSignalTitle { get => EmailOnRestoreSignalTitle.Text; }
        public string EmRestoreSignalSubject { get => EmailOnRestoreSignalSubject.Text; }

        // Localization
        public string EmailOnLostSignalTitleText { set { if (value != "") EmailOnLostSignalTitle.Text = value; } }
        public string EmailOnLostSignalSubjectText { set { if (value != "") EmailOnLostSignalSubject.Text = value; } }
        public string EmailOnRestoreSignalTitleText { set { if (value != "") EmailOnRestoreSignalTitle.Text = value; } }
        public string EmailOnRestoreSignalSubjectText { set { if (value != "") EmailOnRestoreSignalSubject.Text = value; } }

    }

    public class GridItem
    {
        public Control control;
        public float x;
        public float y;
        public float w;
        public float h;
        public int jw;
        public int jh;
        public GridItem(Control Obj, float X, float Y, float W, float H, int JW, int JH)
        {
            control = Obj;
            x = X;
            y = Y;
            w = W;
            h = H;
            jw = JW;
            jh = JH;
        }
    }
}