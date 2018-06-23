using System;
using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    public class NameViewSetupPresenter : BasePresener<INameViewSetupView, NameView>
    {
        public NameView _nameView;

        public NameViewSetupPresenter(IApplicationController controller, INameViewSetupView view) : base(controller, view)
        {
            View.OkClick += OkClick;
            View.CancelClick += CancelClick;
        }

        public override void Run(NameView nv)
        {
            _nameView = nv;
            ViewRefresh();
            View.Show();
        }

        private void ViewRefresh()
        {
            View.TextColor = _nameView.color;
            View.BgEnabled = _nameView.paintBg;
            View.BgColor = _nameView.bgColor;
            View.Position = (int)_nameView.position;
            View.TextSize = _nameView.size;
            View.AutoHideEnabled = _nameView.autoHide;
            View.AutoHideSec = _nameView.autoHideSec;
        }

        private void OkClick()
        {
            _nameView.color = View.TextColor;
            _nameView.paintBg = View.BgEnabled;
            _nameView.bgColor = View.BgColor;
            _nameView.position = (TextPosition)View.Position;
            _nameView.size = View.TextSize;
            _nameView.autoHide = View.AutoHideEnabled;
            _nameView.autoHideSec = View.AutoHideSec;
            View.Close();
        }

        private void CancelClick()
        {
            View.Close();
        }
    }
}