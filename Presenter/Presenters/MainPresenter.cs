using System;
using Model;
using Model.Rtsp;
using Presenter.Common;
using Presenter.Views;
using Presenter.Presenters;

namespace Presenter.Presenters
{
    public class MainPresenter : BasePresener<IMainView>
    {
        private SourceListPresenter _sourceList = null;
        private SourceGridPresenter _sourceGrid = null;
        private ModifySettingsPresenter _settings = null;
        private AppSettings _appSettings = null;
        private ISettingsService _settingsService = null;

        public MainPresenter(IApplicationController controller, IMainView view, ISettingsService settingsService)
            : base(controller, view)
        {
            // View actions
            View.OpenClosePanelClick += OpenClosePanelClick;
            View.SourcesPageSelected += SourcesPageSelected;
            View.SettingsPageSelected += SettingsPageSelected;
            // Settings
            _settingsService = settingsService;
            _appSettings = settingsService.GetSettings();
            View.CtrlPanelWidth = _appSettings.controlPanelWidth;
            // Sources grid
            CreateGrid();
            //if(_appSettings.autoplay==1) _sourceGrid.PlayAll();
        }

        private void OpenClosePanelClick()
        {
            View.PanelState = !View.PanelState;
        }
        private void SourcesPageSelected()
        {
            if (_sourceList == null)
            {
                _sourceList = Controller.Get<SourceListPresenter>();
                _sourceList.SetSettings(_appSettings);
                View.SetSourceListControl(_sourceList.Control);
            }
        }
        private void SettingsPageSelected()
        {
            if (_settings == null)
            {
                _settings = Controller.Get<ModifySettingsPresenter>();
                _settings.SetSettings(_appSettings);
                View.SetSettingsControl(_settings.Control);
            }
        }
        private void CreateGrid()
        {
            if (_sourceGrid == null)
            {
                _sourceGrid = Controller.Get<SourceGridPresenter>();
                _sourceGrid.SetSettings(_appSettings);
                View.SetGridControl(_sourceGrid.Control);
            }
        }
    }
}