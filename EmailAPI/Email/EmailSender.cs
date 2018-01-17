using System.Net.Mail;
using System.Threading.Tasks;
using Email.API.Interfaces;
using Email.API.Models;

namespace Email.API.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfig _emailConfig;

        public EmailSender(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public Task SendEmail(EmailRequest emailRequest)
        {
            var emailMessage = BuildEmailMessage(emailRequest);

            using (var client = new SmtpClient(_emailConfig.MailServerAddress, _emailConfig.MailServerPort))
            {
                return client.SendMailAsync(emailMessage);
            }
        }

        private static MailMessage BuildEmailMessage(EmailRequest emailRequest)
        {
            return new MailMessage
            {
                // To
                //From = new MailAddress(),
                //Bcc = { },
                //CC = { },
                //Subject = ,
                //Body = ,
                //IsBodyHtml = ,
                //Attachments = { },

            };
        }

    }
}
