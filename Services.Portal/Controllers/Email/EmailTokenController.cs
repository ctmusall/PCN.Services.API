using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Portal.Interfaces;

namespace Services.Portal.Controllers.Email
{
    public class EmailTokenController : Controller
    {
        private readonly IEmailTokenUtility _emailTokenUtility;

        public EmailTokenController(IEmailTokenUtility emailTokenUtility)
        {
            _emailTokenUtility = emailTokenUtility;
        }

        [HttpPost]
        public async Task<IActionResult> GetEmailToken()
        {
            return Json(await _emailTokenUtility.GetEmailToken());
        }
    }
}