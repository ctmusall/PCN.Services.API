using System;
using System.Threading.Tasks;
using Email.API.Interfaces;
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

            if (loggedEmail == null) return NotFound();

            return Ok(loggedEmail);
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Accepted();
        }
    }
}