using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Services.Portal.Config;
using Services.Portal.Interfaces;

namespace Services.Portal.Utilities.Email
{
    public class EmailTokenUtility : IEmailTokenUtility
    {
        private readonly ApiConfig _apiConfig;

        public EmailTokenUtility(IOptions<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig.Value;
        }

        public async Task<string> GetEmailToken()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_apiConfig.ServerUri);
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("applicationName", "Service.Portal")
                    });
                    var response = await client.PostAsync(_apiConfig.EmailApi.TokenUri, content);
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
