using System;
using Presenter.Common;

namespace Presenter.Views
{
    public interface ISourceGridView : IViewControl
    {
        void Clear();
        void AddItem(object obj, float x, float y, float w, float h, int jw, int jh);
        void ModifyItem(object obj, float x, float y, float w, float h, int jw, int jh);
        void SwapItems(object obj1, object obj2);
        void Repaint();
        bool OneMaximized { get; set; }

        event Action WatchDog;
        bool WatchDogTimerEnabled { get; set; }

        string EmLostSignalTitle { get; }
        string EmLostSignalSubject { get; }
        string EmRestoreSignalTitle { get; }
        string EmRestoreSignalSubject { get; }

        // Localization
        string EmailOnLostSignalTitleText { set; }
        string EmailOnLostSignalSubjectText { set; }
        string EmailOnRestoreSignalTitleText { set; }
        string EmailOnRestoreSignalSubjectText { set; }
    }
}