using System.Xml.Serialization;

namespace Model
{
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

        [XmlArrayItem(ElementName = "cam", Type = typeof(Camera))]
        public Camera[] cams;

        [XmlIgnore]
        public Hint hint;
    }

    public class Matrix
    {
        public int cntX = 2;
        public int cntY = 2;
    }
}