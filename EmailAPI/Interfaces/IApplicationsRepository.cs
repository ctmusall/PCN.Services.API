using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Email.API.Models;

namespace Email.API.Interfaces
{
    public interface IApplicationsRepository
    {
        Task<List<Application>> RetrieveAllApplications();
        Task<Application> RetrieveApplicationById(Guid id);
        Task<Application> RetrieveApplicationByName(string name);
        Task<int> AddApplication(string applicationName);
        Task<int> UpdateApplication(Application application);
        Task<int> DeleteApplication(Guid id);
        Task<bool> ApplicationExists(Guid id);
        Task<bool> ApplicationExists(string name);
    }
}
