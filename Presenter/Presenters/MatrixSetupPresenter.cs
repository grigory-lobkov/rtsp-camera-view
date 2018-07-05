using System;
using Model;
using Presenter.Common;
using Presenter.Views;

namespace Presenter.Presenters
{
    public class MatrixSetupPresenter : BasePresener<IMatrixSetupView, Matrix>
    {
        private Matrix matrix; // contains global variable
        private Matrix _matrix = new Matrix(); // local matrix

        public MatrixSetupPresenter(IApplicationController controller, IMatrixSetupView view) : base(controller, view)
        {
            View.SaveClick += OkClick;
            View.CancelClick += CancelClick;
            View.SizeChange += SizeChange;
            View.CombineClick += CombineClick;
            View.DivideClick += DivideClick;
            View.ShowClick += ShowClick;
            View.HideClick += HideClick;
        }

        public override void Run(Matrix matrix)
        {
            matrix.SaveTo(_matrix);
            this.matrix = matrix;
            View.SizeX = _matrix.cntX;
            View.SizeY = _matrix.cntY;
            CreateGrid();
            View.Show();
        }

        private void CreateGrid()
        {
            View.Clear();  //todo: do not clear, if some _matrix already exists, using View.ModifyItem
            object obj;
            int cx = _matrix.cntX;
            int cy = _matrix.cntY;
            float mx = (float)0.02;
            float my = (float)0.04;
            int pos = 0;
            for (int y = 0; y < cy; y++)
            {
                for (int x = 0; x < cx; x++)
                {
                    obj = View.NewItem(x, y);
                    View.AddItem(obj, x, y, (x + mx) / cx, (y + my) / cy, (1 - mx - mx) / cx, (1 - my - my) / cy);
                    pos++;
                }
            }
            View.Repaint();
        }

        private void OkClick()
        {
            //_matrix.cntX = View.SizeX;
            //_matrix.cntY = View.SizeY;
            View.Close();
        }

        private void CancelClick()
        {
            View.Close();
        }

        private void SizeChange()
        {
            int x = View.SizeX;
            int y = View.SizeY;
            if (_matrix.cntX != x || _matrix.cntY != y)
            {
                _matrix.cntX = x;
                _matrix.cntY = y;
                CreateGrid();
            }
        }



        private void CombineClick() {
        }
        private void DivideClick() { }
        private void ShowClick() { }
        private void HideClick() { }
    }
}
