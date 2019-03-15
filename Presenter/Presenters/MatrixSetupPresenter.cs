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
            // View localization
            View.ThisText = Locale.Instance.Get("MatrixSetup/this");
            View.JoinButtonText = Locale.Instance.Get("MatrixSetup/joinButton");
            View.SplitButtonText = Locale.Instance.Get("MatrixSetup/splitButton");
            View.SaveButtonText = Locale.Instance.Get("MatrixSetup/saveButton");
            View.CancelButtonText = Locale.Instance.Get("MatrixSetup/cancelButton");

            // View actions
            View.SaveClick += OkClick;
            View.CancelClick += CancelClick;
            View.SizeChange += SizeChange;
            View.JoinClick += JoinClick;
            View.SplitClick += SplitClick;
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
            int cx = _matrix.cntX;
            int cy = _matrix.cntY;
            float mx = (float)0.02;
            float my = (float)0.04;
            for (int y = 0; y < cy; y++)
                for (int x = 0; x < cx; x++)
                    View.AddItem(x, y, 1, 1,
                        (x + mx) / cx, (y + my) / cy, (1 - mx - mx) / cx, (1 - my - my) / cy);
            // Do joins
            MatrixJoin j;
            int i = _matrix.joins.Length;
            while (i > 0)
            {
                i--;
                j = _matrix.joins[i];
                if (j.w + j.x > cx) j.w = cx - j.x; // shrink if too big width
                if (j.h + j.y > cy) j.h = cy - j.y; // shrink if too big height
                if (j.h <= 1 && j.w <= 1)
                { // remove join if size = 1x1
                    _matrix.joins = (MatrixJoin[])RemoveArrayItem(_matrix.joins, i);
                }
                else
                { // stretch block
                    View.ModifyItem(j.x, j.y, j.w - 1, j.h - 1,
                    (j.x + mx) / cx, (j.y + my) / cy, (j.w - mx - mx) / cx, (j.h - my - my) / cy);
                }
            }
            View.Repaint();
        }

        private void OkClick()
        {
            _matrix.SaveTo(matrix);
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


        public static Array RemoveArrayItem(Array source, int index, int add = 0)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            if (0 > index || index >= source.Length)
                throw new ArgumentOutOfRangeException("index", index, "index is outside the bounds of source array");

            Array dest = Array.CreateInstance(source.GetType().GetElementType(), source.Length - 1 + add);
            Array.Copy(source, 0, dest, 0, index);
            Array.Copy(source, index + 1, dest, index, source.Length - index - 1);

            return dest;
        }
        private void CleanMatrixAtRect(int x1, int y1, int x2, int y2, int add = 0)
        {
            MatrixJoin j;
            bool added = add == 0;
            int i = _matrix.joins.Length;
            while (i > 0)
            {
                i--;
                j = _matrix.joins[i];
                if (j.x >= x1 && j.x <= x2 && j.y >= y1 && j.y <= y2)
                {
                    _matrix.joins = (MatrixJoin[])RemoveArrayItem(_matrix.joins, i, added ? 0 : add);
                    added = true;
                }
            }
            if (!added) Array.Resize(ref _matrix.joins, _matrix.joins.Length + add);
        }
        private void JoinClick()
        {
            int cx = _matrix.cntX;
            int cy = _matrix.cntY;
            float mx = (float)0.02;
            float my = (float)0.04;
            int x1 = View.SelX1;
            int y1 = View.SelY1;
            int x2 = View.SelX2;
            int y2 = View.SelY2;
            int w = x2 - x1 + 1;
            int h = y2 - y1 + 1;
            if (w > 1 || h > 1)
            {
                View.ModifyItem(x1, y1, w, h,
                    (x1 + mx) / cx, (y1 + my) / cy, (w - mx - mx) / cx, (h - my - my) / cy);
                View.Repaint();
                CleanMatrixAtRect(x1, y1, x2, y2, 1);
                _matrix.joins[_matrix.joins.Length - 1] = new MatrixJoin(x1, y1, w, h);
            }
        }
        private void SplitClick()
        {
            int cx = _matrix.cntX;
            int cy = _matrix.cntY;
            float mx = (float)0.02;
            float my = (float)0.04;
            int x1 = View.SelX1;
            int y1 = View.SelY1;
            int x2 = View.SelX2;
            int y2 = View.SelY2;
            for (int y = y1; y <= y2; y++)
                for (int x = x1; x <= x2; x++)
                    View.ModifyItem(x, y, 1, 1,
                        (x + mx) / cx, (y + my) / cy, (1 - mx - mx) / cx, (1 - my - my) / cy);
            View.Repaint();
            CleanMatrixAtRect(x1, y1, x2, y2);
        }
    }
}
