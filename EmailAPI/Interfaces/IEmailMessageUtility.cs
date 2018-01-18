using System.Net.Mail;
using Email.API.Models;

namespace Email.API.Interfaces
{
    public interface IEmailMessageUtility
    {
        MailMessage CreateMailMessageFromEmailRequest(EmailRequest emailRequest);
    }
}
