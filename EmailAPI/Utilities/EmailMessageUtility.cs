using System;
using System.Collections.Generic;
using System.Net.Mail;
using Email.API.Interfaces;
using Email.API.Models;

namespace Email.API.Utilities
{
    public class EmailMessageUtility : IEmailMessageUtility
    {
        private readonly MailMessage _mailMessage;

        public EmailMessageUtility(MailMessage mailMessage)
        {
            _mailMessage = mailMessage;
        }

        public MailMessage CreateMailMessageFromEmailRequest(EmailRequest emailRequest)
        {
            AddEmailRequestContacts(emailRequest.To, _mailMessage.To);

            AddEmailRequestContacts(emailRequest.Cc, _mailMessage.CC);

            AddEmailRequestContacts(emailRequest.Bcc, _mailMessage.Bcc);

            _mailMessage.From = new MailAddress(emailRequest.From.EmailAddress, emailRequest.From.DisplayName);
            _mailMessage.Subject = emailRequest.Subject;
            _mailMessage.Body = emailRequest.Body;
            _mailMessage.IsBodyHtml = emailRequest.IsBodyHtml;
            _mailMessage.Priority = Enum.TryParse(emailRequest.Priority, out MailPriority priority) ? priority : MailPriority.Normal;
            return _mailMessage;
        }

        private static void AddEmailRequestContacts(ICollection<EmailContactRequest> emailContactRequests, MailAddressCollection mailAddressCollection)
        {
            if (emailContactRequests == null) return;

            foreach (var contactRequest in emailContactRequests)
            {
                mailAddressCollection.Add(new MailAddress(contactRequest.EmailAddress, contactRequest.DisplayName));
            }
        }
    }
}
