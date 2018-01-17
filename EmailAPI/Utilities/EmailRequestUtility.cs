using System;
using System.Collections.Generic;
using System.Linq;
using Email.API.Common;
using Email.API.Interfaces;
using Email.API.Models;

namespace Email.API.Utilities
{
    public class EmailRequestUtility : IEmailRequestUtility
    {
        public EmailLog ConvertRequestEmailToLoggedEmail(EmailRequest emailRequest)
        {
            return new EmailLog
            {
                Subject = emailRequest.Subject,
                Body = emailRequest.Body,
                DateTimeSent = DateTime.Now,
                IsBodyHtml = emailRequest.IsBodyHtml,
                Priority = emailRequest.Priority
            };
        }

        public ICollection<EmailContact> ConvertEmailContactRequestsToEmailContacts(EmailRequest emailRequest, EmailLog emailLog)
        {
            var emailContacts = new List<EmailContact>();

            if (emailRequest.To != null) emailContacts.AddRange(CreateCollectionOfEmailContacts(emailRequest.To, emailLog, ContactTypeEnum.To));

            if (emailRequest.Cc != null) emailContacts.AddRange(CreateCollectionOfEmailContacts(emailRequest.Cc, emailLog, ContactTypeEnum.Cc));

            if (emailRequest.Bcc != null) emailContacts.AddRange(CreateCollectionOfEmailContacts(emailRequest.Bcc, emailLog, ContactTypeEnum.Bcc));

            if (emailRequest.From != null) emailContacts.Add(new EmailContact
            {
                EmailLog = emailLog,
                ContactType = ContactTypeEnum.From.ToString(),
                DisplayName = emailRequest.From.DisplayName,
                EmailAddress = emailRequest.From.EmailAddress
            });

            return emailContacts;
        }

        private static IEnumerable<EmailContact> CreateCollectionOfEmailContacts(IEnumerable<EmailContactRequest> emailContactRequests, EmailLog emailLog, ContactTypeEnum contactTypeEnum)
        {
            var emailContacts = new List<EmailContact>();
            emailContacts.AddRange(emailContactRequests.Select(contact => new EmailContact
            {
                EmailLog = emailLog,
                ContactType = contactTypeEnum.ToString(),
                DisplayName = contact.DisplayName,
                EmailAddress = contact.EmailAddress
            }));
            return emailContacts;
        }
    }
}