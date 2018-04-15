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
        public Camera CamEdited = null;
        public Camera CamDeleted = null;

        public SourceListPresenter(IApplicationController controller, ISourceListView view)
            : base(controller, view)
        {
            View.SortChanged += SortChanged;
            View.ViewChanged += ViewChanged;
            View.EditClick += EditClick;
            View.NewClick += NewClick;
        }

        public event Action SourceModified;
        public event Action SourceDeleted;

        public void SetSettings(AppSettings settings)
        {
            _settings = settings;
            View.Clear();
            foreach (Camera m in _settings.cams)
            {
                View.AddItem(m, m.name, m.camIcon);
            }
        }

        public void SortChanged()
        {
            _settings.camListSort = View.ListSort;
        }
        public void ViewChanged()
        {
            _settings.camListView = View.ListView;
        }

        private void checkSrcEdit()
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

        public void EditClick()
        {
            _camEdit = (Camera)View.SelectedObject;
            if (_camEdit != null)
            {
                checkSrcEdit();
                _srcEdit.Run(_camEdit);
            }
        }
        public void NewClick()
        {
            _camEdit = new Camera();
            checkSrcEdit();
            _srcEdit.Run(_camEdit, true);
        }
        private void NewSrcCreated()
        {
            View.AddItem(_camEdit, _camEdit.name, _camEdit.camIcon);
            View.SelectObject(_camEdit);
        }
        private void SrcModified()
        {
            CamEdited = _camEdit;
            View.UpdateSelected(_camEdit.name, _camEdit.camIcon);
            SourceModified?.Invoke();
        }
        private void SrcDeleted()
        {
            CamDeleted = _camEdit;
            View.RemoveSelected();
            SourceDeleted?.Invoke();
        }
    }
}