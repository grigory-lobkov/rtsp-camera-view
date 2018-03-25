namespace Model.Rtsp
{
    public class VlcRtspService : IRtspService
    {
        public bool Login(User user)
        {
            return !string.IsNullOrEmpty(user.Name);
        }
    }
}