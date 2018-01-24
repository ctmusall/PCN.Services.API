﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Email.API.Authentication;
using Email.API.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Email.API.Utilities
{
    public class TokenUtility : ITokenUtility
    {
        private readonly AuthenticationConfig _authenticationConfig;

        public TokenUtility(IOptions<AuthenticationConfig> authenticationConfig)
        {
            _authenticationConfig = authenticationConfig.Value;
        }

        public string GenerateToken(string applicationName)
        {
            return IsValidApplicationIdentity(applicationName) 
                ? CreateToken(applicationName) 
                : string.Empty;
        }

        private bool IsValidApplicationIdentity(string applicationName)
        {
            return true;
            // TODO - Find in application table application identity. If exists return true else false.
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
