using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Email.API.Authentication;
using Email.API.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Email.API.Utilities
{
    public class TokenUtility : ITokenUtility
    {
        private readonly AuthenticationConfig _authenticationConfig;
        private readonly IApplicationsRepository _applicationsRepository;

        public TokenUtility(IOptions<AuthenticationConfig> authenticationConfig, IApplicationsRepository applicationsRepository)
        {
            _applicationsRepository = applicationsRepository;
            _authenticationConfig = authenticationConfig.Value;
        }

        public async Task<string> GenerateToken(string applicationName)
        {
            return await IsValidApplicationIdentity(applicationName) 
                ? CreateToken(applicationName) 
                : string.Empty;
        }

        private async Task<bool> IsValidApplicationIdentity(string applicationName)
        {
            return await _applicationsRepository.ApplicationExists(applicationName);
        }

        private string CreateToken(string applicationName)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, applicationName),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp,
                    new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
            };

            var token = new JwtSecurityToken(
                new JwtHeader(new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationConfig.SecurityKey)),
                    SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claims));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
