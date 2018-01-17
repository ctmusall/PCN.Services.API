using System.Collections.Generic;
using Email.API.Models;

namespace Email.API.Interfaces
{
    public interface IEmailRequestUtility
    {
        EmailLog ConvertRequestEmailToLoggedEmail(EmailRequest emailRequest);
        ICollection<EmailContact> ConvertEmailContactRequestsToEmailContacts(EmailRequest emailRequest, EmailLog emailLog);
    }
}
