using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface IMatrixSetupView : IView
    {
        event Action SaveClick;
        event Action CancelClick;
        event Action SizeChange;
        event Action CombineClick;
        event Action DivideClick;
        event Action ShowClick;
        event Action HideClick;

        int SizeMaxX { set; }
        int SizeMaxY { set; }
        int SizeX { get; set; }
        int SizeY { get; set; }
        //void ResizeGrid();

        void Clear();
        object NewItem(int x, int y);
        void AddItem(object obj, int gx, int gy, float x, float y, float w, float h);
        void ModifyItem(object obj, float x, float y, float w, float h);
        //void SwapItems(object obj1, object obj2);
        void Repaint();

        int SelX1 { get; }
        int SelX2 { get; }
        int SelY1 { get; }
        int SelY2 { get; }
    }
}
