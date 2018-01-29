using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Services.Portal.Controllers
{
    public class ApplicationsController : Controller
    {
        // TODO - Move logic outside of controller
        [HttpGet]
        public async Task<IActionResult> GetEmailApplications(string token)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:11100"); // TODO - Move to appsettings and load in config object
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.GetAsync("/api/Email/Applications");
                    response.EnsureSuccessStatusCode();

                    var x = response.Content.ReadAsStringAsync().Result;

                    return Json(x);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting emails from Email API: {httpRequestException.Message}");
                }
            }
        }

        // TODO - Move logic outside of controller
        [HttpPost]
        public async Task<IActionResult> AddEmailApplication(string applicationName)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:11100"); // TODO - Move to appsettings and load in config object
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("applicationName", applicationName)
                    });
                    var response = await client.PostAsync("/api/Email/Applications", content);
                    response.EnsureSuccessStatusCode();

                    var x = response.Content.ReadAsStringAsync().Result;

                    return Json(x);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting emails from Email API: {httpRequestException.Message}");
                }
            }
        }


        // TODO - Move logic outside of controller
        [HttpDelete]
        public async Task<IActionResult> DeleteEmailApplication(Guid applicationId, string token)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:11100"); // TODO - Move to appsettings and load in config object
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    var response = await client.DeleteAsync($"api/Email/Applications/{applicationId.ToString()}");
                    response.EnsureSuccessStatusCode();

                    var x = response.Content.ReadAsStringAsync().Result;

                    return Json(x);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting emails from Email API: {httpRequestException.Message}");
                }
            }
        }
    }
}
