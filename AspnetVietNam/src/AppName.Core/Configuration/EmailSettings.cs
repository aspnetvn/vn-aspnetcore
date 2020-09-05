namespace AppName.Core.Configuration
{
    public class EmailSettings
    {
        public string YourEmail { get; set; }
        public string YourEmailPassWord { get; set; }
        public SmtpSettings SmtpSettings { get; set; }
    }

    public class SmtpSettings
    {
        public Gmail Gmail { get; set; }
        public Yahoo Yahoo { get; set; }
        public Hotmail Hotmail { get; set; }
    }

    public abstract class SmtpConfigs
    {
        public string Host { get; set; }
        public int PortNumber { get; set; }
        public bool EnabledSsl { get; set; }
    }

    public class Gmail : SmtpConfigs
    {
    }

    public class Yahoo : SmtpConfigs
    {
    }

    public class Hotmail : SmtpConfigs
    {
    }
}
