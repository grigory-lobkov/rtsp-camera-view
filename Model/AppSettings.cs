using System;
using System.Xml.Serialization;

namespace Model
{
    [XmlRoot(ElementName = "appSettings")]
    public class AppSettings
    {
        public int screen = -1; // screen number to open window on start
        public int fullscreen = 0; // fullscreen: 0-no, 1-yes
        public int maximize = 0; // expand window: 0-no, 1-yes
        public int autoplay = 1; // auto start all sources: 0-no, 1-auto play
        [XmlIgnore]
        public int autoplay_now = -1; // runtime(can be set by command line)
        public int priority = -1; // application base priority: 0-Idle, 1-BelowNormal, 2-Normal, 3-AboveNormal, 4-High
        public int unmute = 0; // do not mute audio: 0-silent, 1-enable sounds
        [XmlIgnore]
        public int unmute_now = -1; // runtime(can be set by command line)
        public int controlPanelWidth = 250; // width of control panel
        public int camListView = 1; // cameras list type of view (1-4:largeIcon/smallIcon/largeList/smallList)
        public int camListSort = 3; // cameras list sort type (1-3:asc/desc/none)

        public Matrix matrix = new Matrix(); // matrix parameters (rows and columns count)
        public NameView nameView = new NameView(); // camera name show global option
        public Alert alert = new Alert(); // alert messages

        [XmlArrayItem(ElementName = "cam", Type = typeof(Camera))]
        public Camera[] cams;

        [XmlIgnore]
        public Hint hint;
    }

    public class Matrix
    {
        public int cntX = 2;
        public int cntY = 2;
        public void SaveTo(Matrix m)
        {
            m.cntX = cntX;
            m.cntY = cntY;
            m.joins = new MatrixJoin[joins.Length];
            Array.Copy(joins, m.joins, joins.Length);
        }
        public bool Equals(Matrix m)
        {
            if ((m.cntX == cntX) && (m.cntY == cntY) && (
                m.joins == joins || joins != null && m.joins != null && joins.Length == m.joins.Length
                ))
            {
                int i = joins.Length - 1;
                for (; i >= 0; i--)
                    if (!joins[i].Equals(m.joins[i])) break;
                if (i < 0) return true;
            }
            return false;
        }
        [XmlArrayItem(ElementName = "join", Type = typeof(MatrixJoin))]
        public MatrixJoin[] joins = { };
    }
    public class MatrixJoin
    {
        public int x;
        public int y;
        public int w;
        public int h;
        public MatrixJoin() { }
        public MatrixJoin(int X, int Y, int W, int H)
        {
            x = X;
            y = Y;
            w = W;
            h = H;
        }
        public void SaveTo(MatrixJoin j)
        {
            j.x = x;
            j.y = y;
            j.w = w;
            j.h = h;
        }
        public bool Equals(MatrixJoin j)
        {
            return (j.x == x) && (j.y == y) && (j.w == w) && (j.h == h);
        }
    }
}