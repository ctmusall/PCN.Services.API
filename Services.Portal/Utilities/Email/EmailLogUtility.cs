using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Services.Portal.Config;
using Services.Portal.Interfaces;

namespace Services.Portal.Utilities.Email
{
    public class EmailLogUtility : IEmailLogUtility
    {
        private readonly ApiConfig _apiConfig;

        public EmailLogUtility(IOptions<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig.Value;
        }

        public async Task<string> GetEmails(string token)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_apiConfig.EmailApi.ServerUri);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(_apiConfig.EmailApi.EmailUri);
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