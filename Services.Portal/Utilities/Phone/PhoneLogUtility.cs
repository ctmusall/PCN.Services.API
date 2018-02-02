using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Services.Portal.Config;
using Services.Portal.Interfaces;

namespace Services.Portal.Utilities.Phone
{
    public class PhoneLogUtility : IPhoneLogUtility
    {
        private readonly ApiConfig _apiConfig;

        public PhoneLogUtility(IOptions<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig.Value;
        }

        public async Task<string> GetMessages(string token)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_apiConfig.PhoneApi.ServerUri);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(_apiConfig.PhoneApi.MessagesUri);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException httpRequestException)
                {
                    return httpRequestException.Message;
                }
            }
        }
    }
}
