namespace Email.API.Email
{
    public class EmailConfig
    {
        public string LocalDomain { get; set; }

        public string MailServerAddress { get; set; }
        public int MailServerPort { get; set; }
    }
}
