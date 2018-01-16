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

        public EmailsController(ILoggedEmailRepository loggedEmailRepository)
        {
            _loggedEmailRepository = loggedEmailRepository;
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

            if (loggedEmail == null) return NotFound(id);

            return Ok(loggedEmail);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoggedEmail loggedEmail)
        {
            if (loggedEmail == null) return BadRequest();
            var result = await _loggedEmailRepository.CreateLoggedEmail(loggedEmail);
            if (result != 1) return BadRequest(loggedEmail);
            return CreatedAtAction("Post", loggedEmail, result);
        }
    }
}