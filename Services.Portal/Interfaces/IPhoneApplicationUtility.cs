using System;
using System.Threading.Tasks;

namespace Services.Portal.Interfaces
{
    public interface IPhoneApplicationUtility
    {
        Task<string> GetPhoneApplications(string token);
        Task<string> AddPhoneApplication(string applicationName);
        Task<string> DeletePhoneApplication(Guid applicationId, string token);
    }
}
