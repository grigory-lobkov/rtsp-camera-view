using System.Xml.Serialization;
using System.Drawing;

namespace Model
{
    //public enum NamePosition { TopLeft = 1, TopCenter = 2, TopRight = 3, BottomLeft = 4, BottomCenter = 5, BottomRight = 6 };
    public enum TextPosition { TopLeft = 1, TopCenter = 2, TopRight = 3, MiddleLeft = 4, MiddleCenter = 5, MiddleRight = 6, BottomLeft = 7, BottomCenter = 8, BottomRight = 9 };

    public class NameView
    {
        public bool enabled = true;
        public bool inheritGlobal = true;
        public TextPosition position = TextPosition.BottomCenter;
        [XmlIgnore]
        public Color color = Color.White;
        [XmlElement("color")]
        public int colorAsArgb
        {
            get { return color.ToArgb(); }
            set { color = Color.FromArgb(value); }
        }
        public int size = 5;
        public bool autoHide = false;
        public int autoHideSec = 4;
        public bool paintBg = true;
        [XmlIgnore]
        public Color bgColor = Color.ForestGreen;
        [XmlElement("bgColor")]
        public int bgColorAsArgb
        {
            get { return bgColor.ToArgb(); }
            set { bgColor = Color.FromArgb(value); }
        }

        public void SaveTo(NameView nv)
        {
            nv.autoHide = autoHide;
            nv.autoHideSec = autoHideSec;
            nv.bgColor = bgColor;
            nv.color = color;
            nv.enabled = enabled;
            nv.inheritGlobal = inheritGlobal;
            nv.paintBg = paintBg;
            nv.position = position;
            nv.size = size;
        }
        public bool Equals(NameView nv)
        {
            return (nv.autoHide == this.autoHide) &&
                (nv.autoHideSec == this.autoHideSec) &&
                (nv.bgColor == this.bgColor) &&
                (nv.color == this.color) &&
                (nv.enabled == this.enabled) &&
                (nv.inheritGlobal == this.inheritGlobal) &&
                (nv.paintBg == this.paintBg) &&
                (nv.position == this.position) &&
                (nv.size == this.size);
        }
    }
}