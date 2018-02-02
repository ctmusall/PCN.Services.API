using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Phone.API.Interfaces;
using Phone.API.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Phone.API.Phone
{
    public class PhoneSender : IPhoneSender
    {
        private readonly TwilioConfig _twilioConfig;

        public PhoneSender(IOptions<TwilioConfig> twilioConfig)
        {
            _twilioConfig = twilioConfig.Value;
        }

        public async Task SendMessage(PhoneMessageRequest phoneMessageRequest)
        {
            TwilioClient.Init(_twilioConfig.AccountSid, _twilioConfig.AuthToken);

            foreach (var contact in phoneMessageRequest.PhoneContacts)
            {
                await MessageResource.CreateAsync(
                    new PhoneNumber(contact.PhoneNumber),
                    from: new PhoneNumber(_twilioConfig.FromNumber),
                    body: phoneMessageRequest.Message);
            }
        }
    }
}
