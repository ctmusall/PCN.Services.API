using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Phone.API.Models;

namespace Phone.API.Interfaces
{
    public interface IPhoneLogRepository
    {
        Task<List<PhoneLog>> RetrieveAllPhoneLogs();
        Task<PhoneLog> RetrievePhoneLogById(Guid id);
        Task<int> DeletePhoneLogById(Guid id);
        Task<int> LogPhoneMessage(PhoneMessageRequest phoneMessageRequest);
    }
}
