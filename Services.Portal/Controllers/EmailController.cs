﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Services.Portal.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Log()
        {
            return PartialView("_LogPartial");
        }

        public IActionResult Contacts()
        {
            return PartialView("_ContactsPartial");
        }

        public IActionResult Applications()
        {
            return PartialView("_ApplicationsPartial");
        }

        [HttpPost]
        public async Task<IActionResult> GetToken()
        {
            // TODO - Retrieve token from API
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://localhost:11100"); // TODO - Move to appsettings and load in config object
                    var content = new FormUrlEncodedContent(new []
                    {
                        new KeyValuePair<string, string>("applicationName", "Service.Portal") 
                    });
                    var response = await client.PostAsync("/token", content); // TODO - Move to appsettings and load in config object
                    response.EnsureSuccessStatusCode();

                    var x = response.Content.ReadAsStringAsync().Result;

                    return Json(x);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting emails from Email API: {httpRequestException.Message}");
                }
            }

            // TODO - Sent Get request to API

            // TODO - Return email data
        }
    }
}