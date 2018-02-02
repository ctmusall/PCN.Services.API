using Services.Portal.Config.Email;
using Services.Portal.Config.Phone;

namespace Services.Portal.Config
{
    public class ApiConfig
    {
        public EmailApiConfig EmailApi { get; set; }

        public PhoneApiConfig PhoneApi { get; set; }
    }
}
