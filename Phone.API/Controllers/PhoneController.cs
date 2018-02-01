using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phone.API.Interfaces;

namespace Phone.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PhoneController : Controller
    {
        private readonly IPhoneLogRepository _phoneLogRepository;

        public PhoneController(IPhoneLogRepository phoneLogRepository)
        {
            _phoneLogRepository = phoneLogRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhoneLogs()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _phoneLogRepository.RetrieveAllPhoneLogs());
        }
    }
}
