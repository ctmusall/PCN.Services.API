using System;
using System.Threading.Tasks;

namespace Services.Portal.Interfaces
{
    public interface IEmailApplicationUtility
    {
        Task<string> GetEmailApplications(string token);
        Task<string> AddEmailApplication(string applicationName);
        Task<string> DeleteEmailApplication(Guid applicationId, string token);
    }
}
