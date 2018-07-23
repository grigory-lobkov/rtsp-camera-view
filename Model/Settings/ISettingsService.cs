namespace Model
{
    public interface ISettingsService
    {
        AppSettings GetSettings();
        bool Save();
        void AddSampleCameras();
    }
}
