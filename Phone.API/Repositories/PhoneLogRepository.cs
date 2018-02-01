using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phone.API.Data;
using Phone.API.Interfaces;
using Phone.API.Models;

namespace Phone.API.Repositories
{
    public class PhoneLogRepository : IPhoneLogRepository
    {
        private readonly PhoneContext _phoneContext;
        private readonly IPhoneRequestUtility _phoneRequestUtility;

        public PhoneLogRepository(PhoneContext phoneContext, IPhoneRequestUtility phoneRequestUtility)
        {
            _phoneContext = phoneContext;
            _phoneRequestUtility = phoneRequestUtility;
        }

        public async Task<List<PhoneLog>> RetrieveAllPhoneLogs()
        {
            return await _phoneContext.PhoneLogs.Include(contact => contact.PhoneContacts).ToListAsync();
        }

        public async Task<PhoneLog> RetrievePhoneLogById(Guid id)
        {
            return await _phoneContext.PhoneLogs.Include(contact => contact.PhoneContacts).FirstOrDefaultAsync(log => log.Id == id);
        }

        public async Task<int> DeletePhoneLogById(Guid id)
        {
            var phoneLogToDelete = await _phoneContext.PhoneLogs.Include(contact => contact.PhoneContacts).FirstOrDefaultAsync(phone => phone.Id == id);

            if (phoneLogToDelete == null) return 0;

            _phoneContext.PhoneLogs.Remove(phoneLogToDelete);

            var phoneContacts = await _phoneContext.PhoneContacts.Where(contact => contact.PhoneLogId == id).ToListAsync();
            _phoneContext.PhoneContacts.RemoveRange(phoneContacts);

            return await _phoneContext.SaveChangesAsync();
        }

        public Task<int> LogPhoneMessage(PhoneMessageRequest phoneMessageRequest)
        {
            var loggedPhoneMessage = _phoneRequestUtility.ConvertPhoneMessageRequestToPhoneLog(phoneMessageRequest);
            _phoneContext.Add(loggedPhoneMessage);

            var phoneContacts = _phoneRequestUtility.ConvertPhoneContactRequestsToPhoneContacts(phoneMessageRequest, loggedPhoneMessage);
            _phoneContext.AddRange(phoneContacts);

            return _phoneContext.SaveChangesAsync();
        }
    }
}
