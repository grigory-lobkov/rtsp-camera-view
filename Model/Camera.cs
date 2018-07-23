using System;
using System.Xml.Serialization;

namespace Model
{
    public class Camera
    {
        public string name = "";
        public string rtspBad = "";
        public string rtspGood = "";
        public string aspectRatio = "16:9";
        public int camIcon = 1;
        public int position = -1;

        [XmlIgnore]
        public Action Edit;

        public NameView nameView = new NameView(); // name show parameters
    }
}