namespace Model.Rtsp
{
    public class VlcRtspService : IRtspService
    {
        public bool Login(Camera user)
        {
            return !string.IsNullOrEmpty(user.name);
        }
    }
}