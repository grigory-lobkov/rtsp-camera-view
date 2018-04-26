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
                _srcEdit.Create += NewSrcCreated;
                _srcEdit.Save += SrcModified;
                _srcEdit.Delete += SrcDeleted;
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
        }
        private void SrcModified()
        {
            SourceEditedVar = _camEdit;
            View.UpdateSelected(_camEdit.name, _camEdit.camIcon);
            SourceModified?.Invoke();
        }
        private void SrcDeleted()
        {
            SourceDeletedVar = _camEdit;
            View.RemoveSelected();
            SourceDeleted?.Invoke();
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