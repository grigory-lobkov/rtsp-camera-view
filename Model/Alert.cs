using System.Xml.Serialization;

namespace Model
{
    public class Alert
    {
        public EmailAlert email = new EmailAlert();

        public void SaveTo(Alert alert)
        {
            email.SaveTo(alert.email);
        }
        public bool Equals(Alert alert)
        {
            return email.Equals(alert.email);
        }
    }

    public class EmailAlert
    {
        public int whenDissapearMin = 30;
        [XmlIgnore]
        public bool onSignalLost = false;
        [XmlElement("onSignalLost")]
        public int OnSignalLostBit
        {
            get => onSignalLost ? 1 : 0;
            set => onSignalLost = value == 1;
        }
        [XmlIgnore]
        public bool onSignalRecover = false;
        [XmlElement("onSignalRecover")]
        public int OnSignalRecoverBit
        {
            get => onSignalRecover ? 1 : 0;
            set => onSignalRecover = value == 1;
        }
        public string serverUrl = "gmail.com";
        public int serverPort = 587;
        public string emailFrom = "noreply-alert@rtsp-camera-view.app";
        public string emailTo = "";
        public string authUser = "";
        public string authPassword = "";

        public void SaveTo(EmailAlert alert)
        {
            alert.serverPort = this.serverPort;
            alert.emailFrom = this.emailFrom;
            alert.onSignalLost = this.onSignalLost;
            alert.whenDissapearMin = this.whenDissapearMin;
            alert.authPassword = this.authPassword;
            alert.onSignalRecover = this.onSignalRecover;
            alert.serverUrl = this.serverUrl;
            alert.emailTo = this.emailTo;
            alert.authUser = this.authUser;
        }
        public bool Equals(EmailAlert alert)
        {
            return (alert.serverPort == this.serverPort) &&
                (alert.emailFrom == this.emailFrom) &&
                (alert.onSignalLost == this.onSignalLost) &&
                (alert.whenDissapearMin == this.whenDissapearMin) &&
                (alert.authPassword == this.authPassword) &&
                (alert.onSignalRecover == this.onSignalRecover) &&
                (alert.serverUrl == this.serverUrl) &&
                (alert.emailTo == this.emailTo) &&
                (alert.authUser == this.authUser);
        }
    }
}
