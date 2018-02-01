using System.Collections.Generic;
using System.Threading.Tasks;
using Phone.API.Models;

namespace Phone.API.Interfaces
{
    public interface IPhoneLogRepository
    {
        Task<List<PhoneLog>> RetrieveAllPhoneLogs();
    }
}
