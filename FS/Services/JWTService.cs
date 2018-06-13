using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FS.Helpers;

namespace FS.Services
{
    public static class JWTService
    {
        public static string GetToken(string UserName)
        {
            Claim[] claims =
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, UserName)
            };

            var configuration = ConfigurationContainer.Configuration;

            return JWTHelper.GetTokenAsString(
                configuration["Jwt:SecretKey"],
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims
            );
        }
    }
}
