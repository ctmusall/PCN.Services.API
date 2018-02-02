using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Portal.Interfaces;

namespace Services.Portal.Controllers.Phone
{
    public class PhoneTokenController : Controller
    {
        private readonly IPhoneTokenUtility _phoneTokenUtility;

        public PhoneTokenController(IPhoneTokenUtility phoneTokenUtility)
        {
            _phoneTokenUtility = phoneTokenUtility;
        }

        [HttpPost]
        public async Task<IActionResult> GetPhoneToken()
        {
            return Json(await _phoneTokenUtility.GetPhoneToken());
        }
    }
}