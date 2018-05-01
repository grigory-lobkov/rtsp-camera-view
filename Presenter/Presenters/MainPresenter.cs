using System;
using Model;
using Model.Rtsp;
using Presenter.Common;
using Presenter.Views;
using Presenter.Presenters;
using Microsoft.Win32;

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
            View.SplitterMoved += SplitterMoved;
            // Settings
            _settingsService = settingsService;
            try { _appSettings = settingsService.GetSettings(); }
            catch (UnauthorizedAccessException e) { View.ErrorAccessSettings(e.Message); }
            catch (Exception e) { View.ErrorOnLoadSettings(e.Message); }

            View.CtrlPanelWidth = _appSettings.controlPanelWidth;
            // Sources grid
            try { CreateGrid(); }
            catch (System.IO.FileNotFoundException e) { View.ErrorOnCreateGridNoLib(e.Message); } //no VLC or ActiveX lib
            catch (System.NotSupportedException e) { View.ErrorOnCreateGridBadVer(e.Message); } //bad VLC version
            catch (System.InvalidCastException e) { View.ErrorOnCreateGridBadVer(e.Message); } //bad VLC version
            catch (Exception e) { View.ErrorOnCreateGridOther(e.Message); }
            foreach (Camera m in _appSettings.cams) { m.Edit += () => EditSrcClick(m); }
            // Process command line arguments
            ProcessCommandLine(Environment.GetCommandLineArgs());
        }

        private void ProcessCommandLine(string[] args)
        {
            int screen = _appSettings.screen, fullscreen = _appSettings.fullscreen, autoplay = _appSettings.autoplay;
            int unmute = _appSettings.unmute, maximize = _appSettings.maximize, priority = _appSettings.priority;
            bool f;
            foreach (string arg in args)
            {
                int l = arg.Length;
                if (l >= 10) if (arg.Substring(0, 10).Equals("fullscreen")) if (l > 10) f = int.TryParse(arg.Substring(11), out fullscreen); else fullscreen = 1;
                if (l >= 8)
                {
                    string s = arg.Substring(0, 8);
                    if (s.Equals("autoplay"))      { if (l > 8) f = int.TryParse(arg.Substring(9), out autoplay); else autoplay = 1; }
                    else if (s.Equals("priority")) { if (l > 8) f = int.TryParse(arg.Substring(9), out priority); }
                    else if (s.Equals("maximize")) { if (l > 8) f = int.TryParse(arg.Substring(9), out maximize); else maximize = 1; }
                }
                if (l >= 6)
                {
                    string s = arg.Substring(0, 8);
                    if (s.Equals("unmute")) if (l > 6) f = int.TryParse(arg.Substring(7), out unmute); else unmute = 1;
                    if (s.Equals("screen")) if (l > 6) f = int.TryParse(arg.Substring(7), out screen);
                }
            }
            _appSettings.unmute_now = unmute;
            if (screen > -1) View.MoveToScreen(screen);
            if (maximize > 0) View.Maximize();
            if (fullscreen > 0) View.DoFullscreen();
            if (autoplay > 0) { _appSettings.autoplay_now = autoplay; _sourceGrid.PlayAll(); }
            if (priority >= 0) View.SetPriority(priority);
            View.SetAppCaption();
        }

        private void SaveSettings()
        {
            try { _settingsService.Save(); }
            catch (UnauthorizedAccessException e) { View.ErrorAccessSettings(e.Message); }
            catch (Exception e) { View.ErrorOnSaveSettings(e.Message); }
        }

        private void OpenClosePanelClick()
        {
            View.PanelState = !View.PanelState;
        }
        private void SplitterMoved()
        {
            _appSettings.controlPanelWidth = View.CtrlPanelWidth;
        }
        private void SourcesPageSelected()
        {
            if (_sourceList == null)
            {
                _sourceList = Controller.Get<SourceListPresenter>();
                _sourceList.SetSettings(_appSettings);
                _sourceList.SourceCreated += SourceCreated;
                _sourceList.SourceModified += SourceModified;
                _sourceList.SourceDeleted += SourceDeleted;
                _sourceList.DoDragDrop += SourceDoDragDrop;
                _sourceList.DoneDragDrop += SourceDoneDragDrop;
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
                _settings.NameViewChanged += NameViewChanged;
                _settings.MatrixSizeChanged += MatrixSizeChanged;
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
        private void EditSrcClick(Camera s)
        {
            View.PanelState = true;
            _sourceList.EditClick(s);
        }
        private void SourceCreated()
        {
            _sourceList.SourceEditedVar.Edit += () => EditSrcClick(_sourceList.SourceEditedVar);
            SaveSettings();
        }
        private void SourceModified()
        {
            _sourceGrid.SourceRefreshed(_sourceList.SourceEditedVar);
            SaveSettings();
        }
        private void SourceDeleted()
        {
            _sourceGrid.SourceDeleted(_sourceList.SourceDeletedVar);
        }
        private void SourceDoDragDrop()
        {
            _sourceGrid.SourceDoDragDrop((Camera)_sourceList.DragObject);
        }
        private void SourceDoneDragDrop()
        {
            _sourceGrid.SourceDoneDragDrop();
        }
        private void NameViewChanged()
        {
            _sourceGrid.GlobalNameViewChanged();
        }
        private void MatrixSizeChanged()
        {
            _sourceGrid.SetSettings(_appSettings);
        }
    }
}