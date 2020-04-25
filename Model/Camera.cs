using System;
using System.Xml.Serialization;

namespace Model
{
    public class Camera
    {
        public string name = ""; // name of camera
        public string rtspBad = ""; // url to stream with low resolution
        public string rtspGood = ""; // url to good stream
        public string aspectRatio = "16:9"; // camera aspect ratio
        public int camIcon = 1; // camera icon in the list
        public int position = -1; // camera position in the grid (-1-nowhere)
        public int goodOnlyInFullview = 0; // show good RTSP only when in fullview mode (0-disabled, 1-enabled)

        [XmlIgnore]
        public Action Edit;

        public NameView nameView = new NameView(); // name show parameters
    }
}