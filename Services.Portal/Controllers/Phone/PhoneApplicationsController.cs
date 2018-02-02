using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Portal.Interfaces;

namespace Services.Portal.Controllers.Phone
{
    public class PhoneApplicationsController : Controller
    {
        private readonly IPhoneApplicationUtility _phoneApplicationUtility;

        public PhoneApplicationsController(IPhoneApplicationUtility phoneApplicationUtility)
        {
            _phoneApplicationUtility = phoneApplicationUtility;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneApplications(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return BadRequest("Token cannot be null or empty");

            return Json(await _phoneApplicationUtility.GetPhoneApplications(token));
        }

        [HttpPost]
        public async Task<IActionResult> AddPhoneApplication(string applicationName)
        {
            if (string.IsNullOrWhiteSpace(applicationName)) return BadRequest("Application name cannot be null or empty");

            return Json(await _phoneApplicationUtility.AddPhoneApplication(applicationName));
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePhoneApplication(Guid applicationId, string token)
        {
            if (applicationId == Guid.Empty) return BadRequest("Application Id cannot be null or empty");
            if (string.IsNullOrWhiteSpace(token)) return BadRequest("Token cannot be null or empty");

            return Json(await _phoneApplicationUtility.DeletePhoneApplication(applicationId, token));
        }
    }
}
