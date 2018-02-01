using System.Collections.Generic;
using Phone.API.Models;

namespace Phone.API.Interfaces
{
    public interface IPhoneRequestUtility
    {
        PhoneLog ConvertPhoneMessageRequestToPhoneLog(PhoneMessageRequest phoneMessageRequest);

        ICollection<PhoneContact> ConvertPhoneContactRequestsToPhoneContacts(PhoneMessageRequest phoneMessageRequest, PhoneLog phoneLog);
    }
}
