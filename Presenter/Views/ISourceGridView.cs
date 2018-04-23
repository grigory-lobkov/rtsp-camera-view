using Presenter.Common;

namespace Presenter.Views
{
    public interface ISourceGridView : IViewControl
    {
        void Clear();
        void AddItem(object obj, float x, float y, float w, float h);
        void ModifyItem(object obj, float x, float y, float w, float h);
        void SwapItems(object obj1, object obj2);
        void Repaint();
        bool OneMaximized { get; set; }
    }
}