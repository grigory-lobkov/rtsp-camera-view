using System;
using System.Drawing;
using System.Windows.Forms;
using Presenter.Views;
using Presenter.Common;

namespace View.Components
{
    public partial class SourceListControl : UserControl, ISourceListView
    {
        int _sort = 3;
        int _view = 1;
        ImageList cameraIconsImageList2 = new System.Windows.Forms.ImageList();
        ImageList cameraIconsImageList3 = new System.Windows.Forms.ImageList();

        public SourceListControl()
        {
            InitializeComponent();
            modifyCameraToolStripMenuItem.Click += (sender, args) => Invoke(EditClick);
            newCameraToolStripMenuItem.Click += (sender, args) => Invoke(NewClick);

            ascendingToolStripMenuItem.Click += (sender, args) => ChangeSort(1);
            ascendingToolStripMenuItem.Click += (sender, args) => Invoke(SortChanged);
            descendingToolStripMenuItem.Click += (sender, args) => ChangeSort(2);
            descendingToolStripMenuItem.Click += (sender, args) => Invoke(SortChanged);
            disabledToolStripMenuItem.Click += (sender, args) => ChangeSort(3);
            disabledToolStripMenuItem.Click += (sender, args) => Invoke(SortChanged);

            largeIconsToolStripMenuItem.Click += (sender, args) => ChangeView(1);
            largeIconsToolStripMenuItem.Click += (sender, args) => Invoke(ViewChanged);
            smallIconsToolStripMenuItem.Click += (sender, args) => ChangeView(2);
            smallIconsToolStripMenuItem.Click += (sender, args) => Invoke(ViewChanged);
            largeListToolStripMenuItem.Click += (sender, args) => ChangeView(3);
            largeListToolStripMenuItem.Click += (sender, args) => Invoke(ViewChanged);
            smallListToolStripMenuItem.Click += (sender, args) => ChangeView(4);
            smallListToolStripMenuItem.Click += (sender, args) => Invoke(ViewChanged);

            int i;
            cameraIconsImageList2.Images.Clear();
            cameraIconsImageList2.ImageSize = new Size(50, 50);
            cameraIconsImageList3.Images.Clear();
            cameraIconsImageList3.ImageSize = new Size(25, 25);
            listView.LargeImageList = cameraIconsImageList2;
            listView.SmallImageList = cameraIconsImageList2;
            listView.TileSize = new Size(listView.LargeImageList.ImageSize.Width + 10, listView.LargeImageList.ImageSize.Height + 2);
            foreach (string ikey in cameraIconsImageList.Images.Keys)
            {
                i = cameraIconsImageList.Images.IndexOfKey(ikey);
                cameraIconsImageList2.Images.Add(ikey, (Bitmap)cameraIconsImageList.Images[i]);
                cameraIconsImageList3.Images.Add(ikey, (Bitmap)cameraIconsImageList.Images[i]);
            }
        }

        private void Invoke(Action action)
        {
            action?.Invoke();
        }

        public void ClearList()
        {
            listView.Items.Clear();
        }

        public void AddItem(object obj, string name, int icoNr)
        {
            ListViewItem lvi = new ListViewItem(name, icoNr);
            lvi.Tag = obj;
            listView.Items.Add(lvi);
        }

        public object SelectedObject
        {
            get { return listView.FocusedItem == null ? null : listView.FocusedItem.Tag; }
            set { if(listView.FocusedItem != null) listView.FocusedItem.Tag = value; }
        }

        public event Action EditClick;

        public event Action NewClick;

        public int ListSort
        {
            get { return _sort; }
            set { ChangeSort(value); }
        }

        public event Action SortChanged;

        private void ChangeSort(int sort)
        {
            listView.Sorting = sort == 1 ? SortOrder.Ascending : sort == 2 ? SortOrder.Descending : SortOrder.None;
            ascendingToolStripMenuItem.Checked = sort == 1;
            descendingToolStripMenuItem.Checked = sort == 2;
            disabledToolStripMenuItem.Checked = sort == 3;
            _sort = sort;
        }

        public int ListView
        {
            get { return _view; }
            set { ChangeView(value); }
        }

        public event Action ViewChanged;

        private void ChangeView(int view)
        {
            listView.LargeImageList = view < 2 ? cameraIconsImageList : view > 3 ? cameraIconsImageList3 : cameraIconsImageList2;
            listView.SmallImageList = listView.LargeImageList;
            listView.View = view < 3 ? System.Windows.Forms.View.LargeIcon : System.Windows.Forms.View.List;
            largeIconsToolStripMenuItem.Checked = view == 1;
            smallIconsToolStripMenuItem.Checked = view == 2;
            largeListToolStripMenuItem.Checked = view == 3;
            smallListToolStripMenuItem.Checked = view == 4;
            _view = view;
        }

        public void SetModifySourceControl(IViewControl control)
        {
            UserControl _editSource = (UserControl)control;
            this.Controls.Add(_editSource);
            _editSource.Dock = DockStyle.Fill;
            _editSource.BringToFront();
        }

        public object GetImageList()
        {
            return cameraIconsImageList2;
        }

        public void SelectObject(object obj)
        {
            foreach (ListViewItem lvi in listView.Items)
            {
                if (lvi.Tag == obj) { lvi.Focused = true; lvi.Selected = true; }
            }
        }
        public void UpdateSelected(string name, int icoNr)
        {
            listView.FocusedItem.Text = name;
            listView.FocusedItem.ImageIndex = icoNr;
        }
        public void RemoveSelected()
        {
            listView.FocusedItem.Remove();
        }
    }
}
