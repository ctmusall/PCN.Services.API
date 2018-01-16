using System.Collections.Generic;
using Email.API.Models;

namespace Email.API.Interfaces
{
    public interface ILoggedEmailRepository
    {
        List<LoggedEmail> RetrieveAllLoggedEmails();
    }
}
