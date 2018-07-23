using System;

namespace Model
{

    public enum HintType { None = 0, OpenCtrl = 1, AddCamera = 2, DropCamera = 3, NewRtspBad = 5, NewRtspGood = 6 };

    public class Hint
    {
        public HintType lastType = HintType.None;
        private bool lastHidden = true;
        public Action onShow;
        public Action onHide;
        public void Show(HintType hintType)
        {
            if (lastType != hintType && !lastHidden) Hide(lastType);
            lastType = hintType;
            onShow?.Invoke();
            lastHidden = false;
        }
        public void Hide(HintType hintType = HintType.None)
        {
            if (lastHidden) return;
            //if (lastType != hintType) Hide(lastType);
            onHide?.Invoke();
            lastHidden = true;
        }
    }
}
