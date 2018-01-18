using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Email.API.Models;

namespace Email.API.Interfaces
{
    public interface ILoggedEmailRepository
    {
        Task<List<EmailLog>> RetrieveAllLoggedEmails();
        Task<EmailLog> RetrieveLoggedEmailById(Guid id);
        int LogEmail(EmailRequest loggedEmail);
        Task<int> DeleteEmailFromLog(Guid id);
    }
}
