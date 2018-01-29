using System.Threading.Tasks;
using Email.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Email.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/Email/[controller]")]
    public class TokenController : Controller
    {
        private readonly ITokenUtility _tokenUtility;

        public TokenController(ITokenUtility tokenUtility)
        {
            _tokenUtility = tokenUtility;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(string applicationName)
        {
            var tokenResult = await _tokenUtility.GenerateToken(applicationName);

            if (string.IsNullOrWhiteSpace(tokenResult)) return BadRequest();

            return Ok(tokenResult);
        }
    }
}
