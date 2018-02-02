using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Portal.Interfaces;

namespace Services.Portal.Controllers.Phone
{
    public class PhoneController : Controller
    {
        private readonly IPhoneLogUtility _phoneLogUtility;

        public PhoneController(IPhoneLogUtility phoneLogUtility)
        {
            _phoneLogUtility = phoneLogUtility;
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
        public async Task<IActionResult> GetMessages(string token)
        {
            if (string.IsNullOrWhiteSpace(token)) return BadRequest("Token cannot be null or empty");

            return Json(await _phoneLogUtility.GetMessages(token));
        }
    }
}