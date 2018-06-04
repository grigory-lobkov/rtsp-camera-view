namespace Model
{
    public interface IEmailAlertService
    {
        void SetSettings(Alert alert);

        void SendAlert(string header, string text);

        void SendAlertRecover(string header, string text);

    }
}
