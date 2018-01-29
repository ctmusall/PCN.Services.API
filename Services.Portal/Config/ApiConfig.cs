using Services.Portal.Config.Email;

namespace Services.Portal.Config
{
    public class ApiConfig
    {
        public string ServerUri { get; set; }

        public EmailApiConfig EmailApi { get; set; }
    }
}
