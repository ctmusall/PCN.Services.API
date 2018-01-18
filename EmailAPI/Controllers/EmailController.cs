using System;
using System.Threading.Tasks;
using Email.API.Interfaces;
using Email.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Email.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ILoggedEmailRepository _loggedEmailRepository;

        public EmailController(ILoggedEmailRepository loggedEmailRepository, IEmailSender emailSender)
        {
            _loggedEmailRepository = loggedEmailRepository;
            _emailSender = emailSender;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _loggedEmailRepository.RetrieveAllLoggedEmails());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

            var loggedEmail = await _loggedEmailRepository.RetrieveLoggedEmailById(id);

            if (loggedEmail == null) return NotFound(id);

            return Ok(loggedEmail);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmailRequest emailRequest)
        {
            if (!ModelState.IsValid || emailRequest == null) return BadRequest(ModelState);

            await _emailSender.SendEmail(emailRequest);

            await _loggedEmailRepository.LogEmail(emailRequest);

            return Accepted(emailRequest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

            await _loggedEmailRepository.DeleteEmailFromLog(id);

            return Accepted(id);
        }
    }
}