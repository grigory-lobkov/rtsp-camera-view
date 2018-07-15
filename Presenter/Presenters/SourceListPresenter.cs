using System;
using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    public class SourceListPresenter : BasePresenterControl<ISourceListView>
    {
        private AppSettings _settings = null;
        private ModifySourcePresenter _srcEdit = null;
        private Camera _camEdit = null;
        public Camera SourceEditedVar = null;
        public Camera SourceDeletedVar = null;

        public SourceListPresenter(IApplicationController controller, ISourceListView view)
            : base(controller, view)
        {
            // View localization
            View.TypeViewToolStripMenuItemText = Locale.Instance.Get("SourceList/typeViewToolStripMenuItem");
            View.LargeIconsToolStripMenuItemText = Locale.Instance.Get("SourceList/largeIconsToolStripMenuItem");
            View.SmallIconsToolStripMenuItemText = Locale.Instance.Get("SourceList/smallIconsToolStripMenuItem");
            View.LargeListToolStripMenuItemText = Locale.Instance.Get("SourceList/largeListToolStripMenuItem");
            View.SmallListToolStripMenuItemText = Locale.Instance.Get("SourceList/smallListToolStripMenuItem");
            View.SortTypeToolStripMenuItemText = Locale.Instance.Get("SourceList/sortTypeToolStripMenuItem");
            View.AscendingToolStripMenuItemText = Locale.Instance.Get("SourceList/ascendingToolStripMenuItem");
            View.DescendingToolStripMenuItemText = Locale.Instance.Get("SourceList/descendingToolStripMenuItem");
            View.DisabledToolStripMenuItemText = Locale.Instance.Get("SourceList/disabledToolStripMenuItem");
            View.NewCameraToolStripMenuItemText = Locale.Instance.Get("SourceList/newCameraToolStripMenuItem");
            View.ModifyCameraToolStripMenuItemText = Locale.Instance.Get("SourceList/modifyCameraToolStripMenuItem");

            // View actions
            View.SortChanged += SortChanged;
            View.ViewChanged += ViewChanged;
            View.NameChanged += NameChanged;
            View.DoDragDropping += DoDragDropping;
            View.DoneDragDropping += DoneDragDropping;
            View.EditClick += () => EditClick();
            View.NewClick += NewClick;
        }

        public event Action SourceModified;
        public event Action SourceDeleted;
        public event Action SourceCreated;

        public void SetSettings(AppSettings settings)
        {
            _settings = settings;
            View.Clear();
            foreach (Camera m in _settings.cams)
                View.AddItem(m, m.name, m.camIcon);
        }

        public void SortChanged()
        {
            _settings.camListSort = View.ListSort;
        }
        public void ViewChanged()
        {
            _settings.camListView = View.ListView;
        }
        public void NameChanged()
        {
            Camera c = (Camera)View.SelectedObject;
            if (c == null) return;
            c.name = View.SelectedName;
            SourceEditedVar = c;
            SourceModified?.Invoke();
        }

        private void CheckSrcEdit()
        {
            if (_srcEdit == null)
            {
                _srcEdit = Controller.Get<ModifySourcePresenter>();
                View.SetModifySourceControl(_srcEdit.Control);
                _srcEdit.SetImageList(View.GetImageList());
                _srcEdit.SetSettings(_settings);
                _srcEdit.Create += NewSrcCreated;
                _srcEdit.Save += SrcModified;
                _srcEdit.Delete += SrcDeleted;
                _srcEdit.Cancel += SrcCancelled;
            }
        }

        public void EditClick(Camera m = null)
        {
            if (m != null) View.SelectObject(m);
            _camEdit = (Camera)View.SelectedObject;
            if (_camEdit != null)
            {
                CheckSrcEdit();
                _srcEdit.Run(_camEdit);
            }
        }
        public void NewClick()
        {
            _settings.hint.Hide();
            _camEdit = new Camera();
            CheckSrcEdit();
            _srcEdit.Run(_camEdit, true);
        }
        private void NewSrcCreated()
        {
            int l = _settings.cams.Length;
            Array.Resize(ref _settings.cams, l + 1);
            _settings.cams[l] = _camEdit;
            View.AddItem(_camEdit, _camEdit.name, _camEdit.camIcon);
            View.SelectObject(_camEdit);
            SourceEditedVar = _camEdit;
            SourceCreated?.Invoke();
            bool camPosFound = false;
            foreach (Camera c in _settings.cams) if (c.position >= 0) camPosFound = true;
            if (!camPosFound) _settings.hint.Show(HintType.DropCamera);
        }
        private void SrcModified()
        {
            _settings.hint.Hide();
            SourceEditedVar = _camEdit;
            View.UpdateSelected(_camEdit.name, _camEdit.camIcon);
            SourceModified?.Invoke();
        }
        private void SrcDeleted()
        {
            _settings.hint.Hide();
            SourceDeletedVar = _camEdit;
            View.RemoveSelected();
            int i = 0;
            Camera[] tmp = new Camera[_settings.cams.Length - 1];
            foreach (Camera c in _settings.cams) if (c != SourceDeletedVar) { tmp[i] = c; i++; }
            Array.Resize(ref _settings.cams, 0);
            _settings.cams = tmp;
            SourceDeleted?.Invoke();
        }
        private void SrcCancelled()
        {
            _settings.hint.Hide();
        }

        /*****
         *      Drag & Drop functions
         */
        public event Action DoDragDrop;
        public event Action DoneDragDrop;
        private void DoDragDropping() { DoDragDrop?.Invoke(); }
        private void DoneDragDropping() { DoneDragDrop?.Invoke(); }
        public object DragObject { get => View.DragObject; }
    }
}