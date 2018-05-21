using System;
using System.Windows.Forms;
using System.Collections.Generic;
using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    public class SourceGridPresenter : BasePresenterControl<ISourceGridView>
    {
        private AppSettings _settings = null;
        List<SourcePresenter> _srcs = new List<SourcePresenter>();
        private int watchdogCountMax = -1;
        private int watchdogKbTaken = 999999999;
        private int watchdogRestartedLast = 0;

        public SourceGridPresenter(IApplicationController controller, ISourceGridView view)
            : base(controller, view)
        {
            View.WatchDog += WatchDog;
        }

        public void SetSettings(AppSettings settings)
        {
            _settings = settings;
            CreateGrid();
            FillWithSources();
            View.WatchDogTimerEnabled = true;
        }

        private void CreateGrid()
        {
            View.Clear(); _srcs.Clear(); //todo: do not clear, if some SourcePresenter already exists, using View.ModifyItem, saving same position number
            SourcePresenter s;
            int cx = _settings.matrix.cntX;
            int cy = _settings.matrix.cntY;
            int pos = 0;
            for (int y = 0; y < cy; y++)
            {
                for (int x = 0; x < cx; x++)
                {
                    s = Controller.Get<SourcePresenter>();
                    s.SetSettings(_settings);
                    s.Position = pos;
                    _srcs.Add(s);
                    View.AddItem(s.Control, (float)x / cx, (float)y / cy, (float)1 / cx, (float)1 / cy);
                    s.Maximized += OneSourceMaximized;
                    s.Minimized += OneSourceMinimized;
                    s.DragDropInit += () => SourceDoDragDrop();
                    s.DragDropInitFinish += SourceDoneDragDrop;
                    if (pos == 0) s.CreateBadSource(); // try to create player for catch error
                    pos++;
                }
            }
            View.Repaint();
        }

        private void FillWithSources()
        {
            foreach (Camera c in _settings.cams)
                if (c.position >= 0 && c.position < _srcs.Count)
                    _srcs[c.position].Source = c;
        }
        public void PlayAll()
        {
            foreach (SourcePresenter s in _srcs) if (s.Source != null) s.CommandPlay();
        }
        private void OneSourceMaximized()
        {
            View.OneMaximized = true;
            foreach (SourcePresenter s in _srcs) s.InvisibleIfMinimized();
        }
        private void OneSourceMinimized()
        {
            View.OneMaximized = false;
            foreach (SourcePresenter s in _srcs) s.Visible();
        }
        public void SourceRefreshed(Camera edited)
        {
            foreach (Camera c in _settings.cams)
                if (c == edited && c.position >= 0 && c.position < _srcs.Count)
                    _srcs[c.position].Source = c;
        }
        public void SourceDeleted(Camera deleted)
        {
            foreach (Camera c in _settings.cams)
                if (c == deleted && c.position >= 0 && c.position < _srcs.Count)
                    _srcs[c.position].Source = null;
        }
        public void GlobalNameViewChanged()
        {
            FillWithSources();
        }

        /*****
         *      Drag & Drop functions
         */
        private Camera _draggedSource = null;
        public void SourceDoDragDrop(Camera camera = null)
        {
            _draggedSource = camera;
            foreach (SourcePresenter s in _srcs)
                if (_draggedSource is null) if (!s.DragDropInitiator) s.DropDragBegin(); else { }
                else if (s.Source != _draggedSource) s.DropDragBegin();

        }
        public void SourceDoneDragDrop()
        {
            _settings.hint.Hide();
            SourcePresenter fp = null, tp = null;
            foreach (SourcePresenter s in _srcs)
            {
                if (_draggedSource != null && s.Source == _draggedSource || s.DragDropInitiator) fp = s;
                if (s.DragDropAcceptor) tp = s;
                s.DragDropEnd();
            }
            if (tp != null)
            {
                if (fp != null)
                {
                    int p = fp.Position;
                    fp.Position = tp.Position;
                    tp.Position = p;
                    View.SwapItems(fp.Control, tp.Control);
                    if (_draggedSource != null) tp.Source = null;
                }
                else if (_draggedSource != null) tp.Source = _draggedSource;
            }
            _draggedSource = null;
        }

        private void WatchDog()
        {
            System.Diagnostics.Process currentProc = System.Diagnostics.Process.GetCurrentProcess();
            int kbTaken = (int)(currentProc.PrivateMemorySize64 / 1024); // app size in KB
            int playingCount = 0;
            //_srcs[0].Log(kbTaken.ToString());
            foreach (SourcePresenter s in _srcs) if (s.IsPlaying) playingCount = playingCount + 1;
            if (watchdogCountMax < playingCount)
            {
                watchdogCountMax = playingCount;
                watchdogKbTaken = kbTaken;
            }
            else if (watchdogCountMax > 0 && kbTaken > watchdogKbTaken * 1.2)
            {
                int restartNow = watchdogRestartedLast + 1;
                if (restartNow >= _srcs.Count) restartNow = 0;
                for (int i = restartNow; i < _srcs.Count; i++)
                {
                    SourcePresenter s = _srcs[i];
                    if (s != null && s.IsPlaying)
                    {
                        s.IsPlaying = false;
                        s.IsPlaying = true;
                        restartNow = i;
                        break;
                    }
                }
                watchdogRestartedLast = restartNow;
            }
            View.WatchDogTimerEnabled = true;
        }
    }
}