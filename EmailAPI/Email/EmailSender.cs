using System.Net.Mail;
using System.Threading.Tasks;
using Email.API.Interfaces;
using Email.API.Models;
using Microsoft.Extensions.Options;

namespace Email.API.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfig _emailConfig;
        private readonly IEmailMessageUtility _emailMessageUtility;

        public EmailSender(IOptions<EmailConfig> emailConfig, IEmailMessageUtility emailMessageUtility)
        {
            _emailConfig = emailConfig.Value;
            _emailMessageUtility = emailMessageUtility;
        }

        public Task SendEmail(EmailRequest emailRequest)
        {
            var emailMessage = _emailMessageUtility.CreateMailMessageFromEmailRequest(emailRequest);

            var client = new SmtpClient(_emailConfig.MailServerAddress, _emailConfig.MailServerPort);
            
            return client.SendMailAsync(emailMessage);
        }
    }
}