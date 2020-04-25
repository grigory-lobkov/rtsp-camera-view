using System;
using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    class ModifySourcePresenter : BasePresenterControl<IModifySourceView>
    {
        private AppSettings _settings = null;
        private Camera _camera = null;
        private NameView _nameView = null;

        public ModifySourcePresenter(IApplicationController controller, IModifySourceView view)
            : base(controller, view)
        {
            // View localization
            View.CamNameLabelText = Locale.Instance.Get("ModifySource/camNameLabel");
            View.CamNameText = Locale.Instance.Get("ModifySource/camName");
            View.CamNameShowText = Locale.Instance.Get("ModifySource/camNameShow");
            View.CamNameInheritText = Locale.Instance.Get("ModifySource/camNameInherit");
            View.CamNameModifyText = Locale.Instance.Get("ModifySource/camNameModify");
            View.CamEditRtsp1LabelText = Locale.Instance.Get("ModifySource/camEditRtsp1Label");
            View.RtspBadText = Locale.Instance.Get("ModifySource/rtspBad");
            View.CamEditRtsp2LabelText = Locale.Instance.Get("ModifySource/camEditRtsp2Label");
            View.RtspGoodText = Locale.Instance.Get("ModifySource/rtspGood");
            View.CamEditIconLabelText = Locale.Instance.Get("ModifySource/camEditIconLabel");
            View.AspectRatioLabelText = Locale.Instance.Get("ModifySource/aspectRatioLabel");
            View.AspectRatioText = Locale.Instance.Get("ModifySource/aspectRatio");
            View.CreateCamButtonText = Locale.Instance.Get("ModifySource/createCamButton");
            View.SaveCamButtonText = Locale.Instance.Get("ModifySource/saveCamButton");
            View.CancelCamButtonText = Locale.Instance.Get("ModifySource/cancelCamButton");
            View.DelCamLabelText = Locale.Instance.Get("ModifySource/delCamLabel");
            View.CameraDeleteConfirm1Text = Locale.Instance.Get("ModifySource/cameraDeleteConfirm1");
            View.CameraDeleteConfirm2Text = Locale.Instance.Get("ModifySource/cameraDeleteConfirm2");
            View.RtspGoodOnlyInFullviewText = Locale.Instance.Get("ModifySource/rtspGoodOnlyInFullview");

            // View actions
            View.CreateClick += SaveClick;
            View.SaveClick += SaveClick;
            View.CancelClick += CancelClick;
            View.DeleteClick += DeleteClick;
            View.NameViewClick += ModifyNameView;
            View.RtspBadEnter += RtspBadEnter;
            View.RtspGoodEnter += RtspGoodEnter;
            View.Hide();
        }

        public void SetImageList(object imageList)
        {
            View.SetImges(imageList);
        }
        public void SetSettings(AppSettings settings)
        {
            _settings = settings;
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
            View.IsGoodOnlyInFullview = _camera.goodOnlyInFullview;
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
                _camera.goodOnlyInFullview == View.IsGoodOnlyInFullview &&
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
                _camera.goodOnlyInFullview = View.IsGoodOnlyInFullview;
                if (View.IsNewSource) Create?.Invoke(); else Save?.Invoke();
                View.Hide();
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
            Controller.Run<NameViewSetupPresenter, NameView>(_nameView);
        }

        private void RtspBadEnter()
        {
            bool camPosFound = false;
            foreach (Camera c in _settings.cams) if (c.position >= 0) camPosFound = true;
            if (!camPosFound) _settings.hint.Show(HintType.NewRtspBad);
        }
        private void RtspGoodEnter()
        {
            bool camPosFound = false;
            foreach (Camera c in _settings.cams) if (c.position >= 0) camPosFound = true;
            if (!camPosFound) _settings.hint.Show(HintType.NewRtspGood);
        }
    }
}
