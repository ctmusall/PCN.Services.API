using System;
using System.Linq;
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
        public IActionResult Get()
        {
            return Ok(_loggedEmailRepository.RetrieveAllLoggedEmails());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var loggedEmail = _loggedEmailRepository.RetrieveAllLoggedEmails().FirstOrDefault(email => email.Id == id);

            if (loggedEmail == null) return NotFound();

            return Ok(loggedEmail);
        }

    }
}