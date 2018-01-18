using System;
using System.Threading.Tasks;
using Email.API.Interfaces;
using Email.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Email.API.Controllers
{
    [Route("api/[controller]")]
    public class EmailsController : Controller
    {
        private readonly ILoggedEmailRepository _loggedEmailRepository;
        private readonly IEmailSender _emailSender;

        public EmailsController(ILoggedEmailRepository loggedEmailRepository, IEmailSender emailSender)
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
        public async Task<IActionResult> Get(Guid id)
        {
            var loggedEmail = await _loggedEmailRepository.RetrieveLoggedEmailById(id);

            if (loggedEmail == null) return NotFound(new { message = "Logged Email not found" });

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
    }
}