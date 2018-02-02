using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Services.Portal.Config;
using Services.Portal.Interfaces;

namespace Services.Portal.Utilities.Phone
{
    public class PhoneTokenUtility : IPhoneTokenUtility
    {
        private readonly ApiConfig _apiConfig;

        public PhoneTokenUtility(IOptions<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig.Value;
        }

        public async Task<string> GetPhoneToken()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_apiConfig.PhoneApi.ServerUri);
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("applicationName", "Service.Portal")
                    });
                    var response = await client.PostAsync(_apiConfig.PhoneApi.TokenUri, content);
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
