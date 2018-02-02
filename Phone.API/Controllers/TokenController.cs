using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Services.API.Common.Authentication;
using Services.API.Common.Authentication.Interfaces;

namespace Phone.API.Controllers
{
    [Produces("application/json")]
    [Route("/api/Phone/[controller]")]
    public class TokenController : Controller
    {
        private readonly ITokenUtility _tokenUtility;
        private readonly AuthenticationConfig _authenticationConfig;

        public TokenController(ITokenUtility tokenUtility, IOptions<AuthenticationConfig> authenticationConfig)
        {
            _authenticationConfig = authenticationConfig.Value;
            _tokenUtility = tokenUtility;
        }

        [HttpPost]
        public IActionResult CreateToken(string applicationName)
        {
            var tokenResult = _tokenUtility.GenerateToken(applicationName, _authenticationConfig.SecurityKey);

            if (string.IsNullOrWhiteSpace(tokenResult)) return BadRequest();

            return Ok(tokenResult);
        }
    }
}
