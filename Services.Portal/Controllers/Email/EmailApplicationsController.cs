using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Portal.Interfaces;

namespace Services.Portal.Controllers.Email
{
    public class EmailApplicationsController : Controller
    {
        private readonly IEmailApplicationUtility _emailApplicationUtility;

        public EmailApplicationsController(IEmailApplicationUtility emailApplicationUtility)
        {
            _emailApplicationUtility = emailApplicationUtility;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmailApplications(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return BadRequest("Token cannot be null or empty");

            return Json(await _emailApplicationUtility.GetEmailApplications(token));
        }

        [HttpPost]
        public async Task<IActionResult> AddEmailApplication(string applicationName)
        {
            if (string.IsNullOrWhiteSpace(applicationName)) return BadRequest("Application name cannot be null or empty");

            return Json(await _emailApplicationUtility.AddEmailApplication(applicationName));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmailApplication(Guid applicationId, string token)
        {
            if (applicationId == Guid.Empty) return BadRequest("Application Id cannot be null or empty");
            if (string.IsNullOrWhiteSpace(token)) return BadRequest("Token cannot be null or empty");

            return Json(await _emailApplicationUtility.DeleteEmailApplication(applicationId, token));
        }
    }
}
