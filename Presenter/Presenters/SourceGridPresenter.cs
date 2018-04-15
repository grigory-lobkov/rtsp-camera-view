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

        public SourceGridPresenter(IApplicationController controller, ISourceGridView view)
            : base(controller, view)
        {
        }

        public void SetSettings(AppSettings settings)
        {
            _settings = settings;
            CreateGrid();
            FillWithSources();
        }

        private void CreateGrid()
        {
            View.Clear(); _srcs.Clear(); //todo: do not clear, if some SourcePresenter already exists, using View.ModifyItem, saving same position number
            SourcePresenter s;
            int cx = _settings.matrix.cntX;
            int cy = _settings.matrix.cntY;
            int pos = 0;
            for (int x = 0; x < cx; x++)
            {
                for (int y = 0; y < cy; y++)
                {
                    s = Controller.Get<SourcePresenter>();
                    s.SetSettings(_settings);
                    s.position = pos;
                    _srcs.Add(s);
                    View.AddItem(s.Control, (float)x / cx, (float)y / cy, (float)1 / cx, (float)1 / cy);
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

        /*public void PlayAll()
        {
            foreach (SourcePresenter p in _srcs) p.Play();
        }*/
    }
}