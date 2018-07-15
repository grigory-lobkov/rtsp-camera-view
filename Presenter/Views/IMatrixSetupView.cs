using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IMatrixSetupView : IView
    {
        event Action SaveClick;
        event Action CancelClick;
        event Action SizeChange;
        event Action JoinClick;
        event Action SplitClick;

        int SizeMaxX { set; }
        int SizeMaxY { set; }
        int SizeX { get; set; }
        int SizeY { get; set; }
        //void ResizeGrid();

        void Clear();
        void AddItem(int gx, int gy, int gw, int gh, float x, float y, float w, float h);
        void ModifyItem(int gx, int gy, int gw, int gh, float x, float y, float w, float h);
        void Repaint();

        int SelX1 { get; }
        int SelX2 { get; }
        int SelY1 { get; }
        int SelY2 { get; }

        // Localization
        string ThisText { set; }
        string JoinButtonText { set; }
        string SplitButtonText { set; }
        string SaveButtonText { set; }
        string CancelButtonText { set; }

    }
}
