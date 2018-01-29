using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Portal.Interfaces;

namespace Services.Portal.Controllers.Email
{
    public class EmailController : Controller
    {
        private readonly IEmailLogUtility _emailLogUtility;

        public EmailController(IEmailLogUtility emailLogUtility)
        {
            _emailLogUtility = emailLogUtility;
        }

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
        
        [HttpGet]
        public async Task<IActionResult> GetEmails(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return BadRequest("Token cannot be null or empty");

            return Json(await _emailLogUtility.GetEmails(token));
        }
    }
}