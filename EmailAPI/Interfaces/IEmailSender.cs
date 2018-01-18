using Email.API.Models;

namespace Email.API.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(EmailRequest loggedEmail);
    }
}
