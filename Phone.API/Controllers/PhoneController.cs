using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phone.API.Interfaces;
using Phone.API.Models;

namespace Phone.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PhoneController : Controller
    {
        private readonly IPhoneLogRepository _phoneLogRepository;
        private readonly IPhoneSender _phoneSender;

        public PhoneController(IPhoneLogRepository phoneLogRepository, IPhoneSender phoneSender)
        {
            _phoneLogRepository = phoneLogRepository;
            _phoneSender = phoneSender;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetPhoneLogs()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _phoneLogRepository.RetrieveAllPhoneLogs());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneLog(Guid id)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

            var phoneLog = await _phoneLogRepository.RetrievePhoneLogById(id);

            if (phoneLog == null) return NotFound(id);

            return Ok(phoneLog);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostPhoneMessage([FromBody] PhoneMessageRequest phoneMessageRequest)
        {
            if (!ModelState.IsValid || phoneMessageRequest == null) return BadRequest(ModelState);

            await _phoneSender.SendMessage(phoneMessageRequest);

            await _phoneLogRepository.LogPhoneMessage(phoneMessageRequest);

            return Accepted(phoneMessageRequest);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeletePhoneLog(Guid id)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

            await _phoneLogRepository.DeletePhoneLogById(id);

            return Accepted(id);
        }
    }
}
