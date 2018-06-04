using System;
using System.Xml.Serialization;

namespace Model
{
    public class XmlFileSettingsService: ISettingsService
    {
        private AppSettings _settings = null;
        private string storeFileName = "settings.xml";
        private bool errorOnLoadHappen = false; // to prevent save, if error on load happen and user didn't do any changes
        private bool saveThrown = false;
        private bool loadThrown = false;
        private bool hasWriteRights = false;
        public bool HasWriteRights { get => hasWriteRights; }

        public AppSettings GetSettings()
        {
            if (_settings != null) return _settings;
            try { Load(); }
            catch {
                _settings = new AppSettings() { cams = new Camera[0], hint = new Hint() };
                throw;
            }
            if (_settings == null) _settings = new AppSettings();
            if (_settings.cams == null) _settings.cams = new Camera[0];
            _settings.hint = new Hint();
            return _settings;
        }
        public void AddSampleCameras()
        {
            foreach (Camera c in _settings.cams) c.position = -1;
            int l = _settings.cams.Length;
            Array.Resize(ref _settings.cams, l + 4);
            _settings.cams[l] = new Camera
            {
                name = "Hessdalen",
                rtspBad = "http://freja.hiof.no:1935/rtplive/_definst_/hessdalen03.stream/playlist.m3u8",
                position = 0,
                camIcon = 0,
                aspectRatio = "4:3"
            };
            _settings.cams[l + 1] = new Camera
            {
                name = "USA golf",
                rtspBad = "http://wmccpinetop.axiscam.net/mjpg/video.mjpg",
                position = 1,
                camIcon = 1
            };
            _settings.cams[l + 2] = new Camera
            {
                name = "Highway",
                rtspBad = "rtsp://170.93.143.139/rtplive/470011e600ef003a004ee33696235daa",
                position = 2,
                camIcon = 1
            };
            _settings.cams[l + 3] = new Camera
            {
                name = "Semerkand TV",
                rtspBad = "rtmp://semerkandglb.mediatriple.net:1935/semerkandliveedge/semerkand2",
                position = 3,
                camIcon = 1
            };
        }

        ~XmlFileSettingsService()
        {
            try {
                if (!errorOnLoadHappen) Save();
            } finally { }
        }

        public bool Load()
        {
            if (!System.IO.File.Exists(storeFileName)) return false;
            try {// when renaming something in xml
                // AppSettings -> appSettings beta 1.0.0.0-1.0.0.2 -> 1.0.0.3
                System.IO.File.WriteAllText(storeFileName,System.IO.File.ReadAllText(storeFileName)
                    .Replace("<AppSettings", "<appSettings").Replace("AppSettings>", "appSettings>"));
            } catch { }
            try
            {
                using (System.IO.Stream stream = new System.IO.FileStream(storeFileName, System.IO.FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    _settings = (AppSettings)serializer.Deserialize(stream);
                }
            }
            catch
            {
                //MessageBox.Show(errorLoadSettings.Text + "\n" + settings.storeFileName, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //if (settings == null) settings = new AppSettings();
                //return false;
                if (!loadThrown)
                {
                    errorOnLoadHappen = true;
                    loadThrown = true;
                    throw; //UnauthorizedAccessException - no rights to read
                }
                return false;
            }
            return true;
        }

        public bool Save()
        {
            if (_settings == null) return false;
            try
            {
                using (System.IO.Stream writer = new System.IO.FileStream(storeFileName, System.IO.FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    serializer.Serialize(writer, _settings);
                    writer.Close();
                }
            }
            catch
            {
                //MessageBox.Show(errorSaveSettings.Text + "\n" + Properties.Resources.settingsFileName, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return false;
                if (!saveThrown) { saveThrown = true; throw; }//UnauthorizedAccessException - no rights to write
                return false;
            }
            errorOnLoadHappen = false;
            return true;
        }
    }
}
