using System;

namespace Model
{
    public class XmlFileSettingsService: ISettingsService
    {
        private AppSettings _settings = null;
        private string storeFileName = "settings.xml";
        private bool saveThrown = false;
        private bool loadThrown = false;
        private bool hasWriteRights = false;
        public bool HasWriteRights { get => hasWriteRights; }

        public AppSettings GetSettings()
        {
            if (_settings != null) return _settings;
#if !DEBUG
            try { Load(); }
            catch {
                _settings = new AppSettings();
                _settings.cams = new Camera[0];
                throw;
            }
#endif
            if (_settings == null) _settings = new AppSettings();
#if DEBUG
            if (_settings.cams == null || _settings.cams.Length == 0)
            {
                Camera c1 = new Camera(), c2 = new Camera(), c3 = new Camera(), c4 = new Camera();
                c1.rtspGood = "rtsp://op:rocker@46.254.25.84:10554/live/main";
                c1.rtspBad = "rtsp://op:rocker@46.254.25.84:10554/live/sub";
                c2.rtspGood = "rtsp://op:random@46.254.25.84:10555/live/main";
                c2.rtspBad = "rtsp://op:random@46.254.25.84:10555/live/sub";
                c3.rtspGood = "rtsp://op:music@46.254.25.84:10556/av0_0";
                c3.rtspBad = "rtsp://op:music@46.254.25.84:10556/av0_1";
                c4.rtspGood = "rtsp://op:metal@46.254.25.84:10557/av0_0";
                c4.rtspBad = "rtsp://op:metal@46.254.25.84:10557/av0_1";
                c1.position = 0; c2.position = 1; c3.position = 2; c4.position = 3;
                c1.name = "Hall-1"; c2.name = "Hall-2"; c3.name = "Enter-1"; c4.name = "Enter-2";
                c1.camIcon = 0; c2.camIcon = 0;
                Camera[] c = { c1, c2, c3, c4 };
                _settings.cams = c;
            }
            _settings.camListView = 4;
#endif
            if (_settings.cams == null) _settings.cams = new Camera[0];
            return _settings;
        }

        ~XmlFileSettingsService()
        {
            try { Save(); } finally { }
        }

        public bool Load()
        {
            if (!System.IO.File.Exists(storeFileName)) return false;
            try
            {
                using (System.IO.Stream stream = new System.IO.FileStream(storeFileName, System.IO.FileMode.Open))
                {
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(AppSettings));
                    _settings = (AppSettings)serializer.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show(errorLoadSettings.Text + "\n" + settings.storeFileName, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //if (settings == null) settings = new AppSettings();
                //return false;
                if (!loadThrown) { loadThrown = true; throw; }//UnauthorizedAccessException - no rights to read
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
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(AppSettings));
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
            return true;
        }
    }
}
