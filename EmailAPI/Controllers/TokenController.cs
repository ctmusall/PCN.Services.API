using Email.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Email.API.Controllers
{
    [Route("/token")]
    public class TokenController : Controller
    {
        private readonly ITokenUtility _tokenUtility;

        public TokenController(ITokenUtility tokenUtility)
        {
            _tokenUtility = tokenUtility;
        }

        [HttpPost]
        public IActionResult Create(string applicationName)
        {
            var tokenResult = _tokenUtility.GenerateToken(applicationName);

            if (string.IsNullOrWhiteSpace(tokenResult)) return BadRequest();

            return Ok(tokenResult);
        }
    }
}
