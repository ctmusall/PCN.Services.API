using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phone.API.Interfaces;
using Phone.API.Models;

namespace Phone.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/Phone/[controller]")]
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
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

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
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

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
        public async Task<IActionResult> PostApplication(string applicationName)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(applicationName)) return BadRequest(ModelState);

            var result = await _applicationsRepository.AddApplication(applicationName);

            return Accepted(result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteApplication([FromRoute] Guid id)
        {
            if (!ModelState.IsValid || id == Guid.Empty) return BadRequest(ModelState);

            var application = await _applicationsRepository.RetrieveApplicationById(id);
            if (application == null) return NotFound();

            return Ok(await _applicationsRepository.DeleteApplication(id));
        }
    }
}