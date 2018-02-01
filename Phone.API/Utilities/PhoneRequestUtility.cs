using System.Collections.Generic;
using System.Linq;
using Phone.API.Interfaces;
using Phone.API.Models;

namespace Phone.API.Utilities
{
    public class PhoneRequestUtility : IPhoneRequestUtility
    {
        public PhoneLog ConvertPhoneMessageRequestToPhoneLog(PhoneMessageRequest phoneMessageRequest)
        {
            return new PhoneLog
            {
                Message = phoneMessageRequest.Message
            };
        }

        public ICollection<PhoneContact> ConvertPhoneContactRequestsToPhoneContacts(PhoneMessageRequest phoneMessageRequest, PhoneLog phoneLog)
        {
            return phoneMessageRequest.PhoneContacts.Select(contact => new PhoneContact
            {
                PhoneLog = phoneLog,
                Name = contact.Name,
                PhoneNumber = contact.PhoneNumber
            }).ToList();
        }
    }
}
