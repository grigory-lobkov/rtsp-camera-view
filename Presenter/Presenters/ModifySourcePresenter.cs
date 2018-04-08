using System;
using Model;
using Model.Rtsp;
using Presenter.Common;
using Presenter.Views;
using Presenter.Presenters;

namespace Presenter.Presenters
{
    class ModifySourcePresenter : BasePresenterControl<IModifySourceView>
    {
        private Camera _camera = null;
        private NameView _nameView = null;

        public ModifySourcePresenter(IApplicationController controller, IModifySourceView view)
            : base(controller, view)
        {
            View.CreateClick += SaveClick;
            View.SaveClick += SaveClick;
            View.CancelClick += CancelClick;
            View.DeleteClick += DeleteClick;
            View.NameViewClick += ModifyNameView;
            View.Hide();
        }

        public void SetImageList(object imageList)
        {
            View.SetImges(imageList);
        }
        public void Run(Camera camera, bool newSource = false)
        {
            _camera = camera;
            _nameView = new NameView();
            if (_camera.nameView != null) _camera.nameView.SaveTo(_nameView);
            View.Show();
            View.IsNewSource = newSource;
            View.SrcName = _camera.name;
            View.RtspBad = _camera.rtspBad;
            View.RtspGood = _camera.rtspGood;
            View.AspectRatio = _camera.aspectRatio;
            View.CamIcon = _camera.camIcon;
            View.Position = _camera.position;
            View.IsNameShow = _nameView.enabled;
            View.IsNameInherit = _nameView.inheritGlobal;
        }

        public event Action Create;
        public event Action Save;
        public event Action Cancel;
        public event Action Delete;

        private void SaveClick()
        {
            _nameView.enabled = View.IsNameShow;
            _nameView.inheritGlobal = View.IsNameInherit;
            NameView nv = _camera.nameView == null ? new NameView() : _camera.nameView;
            bool notModified = nv.Equals(_nameView) &&
                _camera.name == View.SrcName &&
                _camera.rtspBad == View.RtspBad &&
                _camera.rtspGood == View.RtspGood &&
                _camera.aspectRatio == View.AspectRatio &&
                _camera.camIcon == View.CamIcon;
            if (notModified)
            {
                View.Hide();
                Cancel?.Invoke();
            }
            else
            {
                _camera.nameView = _nameView;
                _camera.name = View.SrcName;
                _camera.rtspBad = View.RtspBad;
                _camera.rtspGood = View.RtspGood;
                _camera.aspectRatio = View.AspectRatio;
                _camera.camIcon = View.CamIcon;
                View.Hide();
                if (View.IsNewSource) Create?.Invoke(); else Save?.Invoke();
            }
        }

        private void CancelClick()
        {
            View.Hide();
            Cancel?.Invoke();
        }

        private void DeleteClick()
        {
            View.Hide();
            Delete?.Invoke();
        }

        private void ModifyNameView()
        {
            Controller.Run<NameViewEditPresenter, NameView>(_nameView);
        }

    }
}
