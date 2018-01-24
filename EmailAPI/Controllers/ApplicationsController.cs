using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Email.API.Interfaces;
using Email.API.Models;
using Microsoft.AspNetCore.Authorization;

namespace Email.API.Controllers
{
    [Produces("application/json")]
    [Route("/applications")]
    public class ApplicationsController : Controller
    {
        private readonly IApplicationsRepository _applicationsRepository;

        public ApplicationsController(IApplicationsRepository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            return Ok(await _applicationsRepository.RetrieveAllApplications());
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetApplication([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var application = await _applicationsRepository.RetrieveApplicationById(id);

            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutApplication([FromRoute] Guid id, [FromBody] Application application)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (id != application.Id) return BadRequest();

            try
            {
                await _applicationsRepository.UpdateApplication(application);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _applicationsRepository.ApplicationExists(id))
                {
                    return NotFound();
                }

                throw;
            }
            return Accepted(application);
        }

        [HttpPost]
        public async Task<IActionResult> PostApplication([FromBody] string applicationName)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _applicationsRepository.AddApplication(applicationName);

            return Accepted(applicationName);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication([FromRoute] Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var application = await _applicationsRepository.RetrieveApplicationById(id);
            if (application == null) return NotFound();

            return Ok(await _applicationsRepository.DeleteApplication(id));
        }
    }
}