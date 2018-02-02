using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Services.Portal.Config;
using Services.Portal.Interfaces;

namespace Services.Portal.Utilities
{
    public class PhoneApplicationUtility : IPhoneApplicationUtility
    {
        private readonly ApiConfig _apiConfig;

        public PhoneApplicationUtility(IOptions<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig.Value;
        }

        public async Task<string> GetPhoneApplications(string token)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_apiConfig.PhoneApi.ServerUri);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync(_apiConfig.PhoneApi.ApplicationsUri);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException httpRequestException)
                {
                    return httpRequestException.Message;
                }
            }
        }

        public async Task<string> AddPhoneApplication(string applicationName)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_apiConfig.PhoneApi.ServerUri);
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("applicationName", applicationName)
                    });
                    var response = await client.PostAsync(_apiConfig.PhoneApi.ApplicationsUri, content);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException httpRequestException)
                {
                    return httpRequestException.Message;
                }
            }
        }

        public async Task<string> DeletePhoneApplication(Guid applicationId, string token)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(_apiConfig.PhoneApi.ServerUri);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.DeleteAsync($"{_apiConfig.PhoneApi.ApplicationsUri}/{applicationId.ToString()}");
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
