using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Email.API.Models;

namespace Email.API.Interfaces
{
    public interface ILoggedEmailRepository
    {
        Task<List<LoggedEmail>> RetrieveAllLoggedEmails();
        Task<LoggedEmail> RetrieveLoggedEmailById(Guid id);
    }
}
