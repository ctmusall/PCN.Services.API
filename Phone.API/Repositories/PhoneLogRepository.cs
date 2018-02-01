using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phone.API.Data;
using Phone.API.Interfaces;
using Phone.API.Models;

namespace Phone.API.Repositories
{
    internal class PhoneLogRepository : IPhoneLogRepository
    {
        private readonly PhoneContext _phoneContext;

        internal PhoneLogRepository(PhoneContext phoneContext)
        {
            _phoneContext = phoneContext;
        }

        public async Task<List<PhoneLog>> RetrieveAllPhoneLogs()
        {
            return await _phoneContext.PhoneLogs.Include(contact => contact.PhoneContacts).ToListAsync();
        }
    }
}
