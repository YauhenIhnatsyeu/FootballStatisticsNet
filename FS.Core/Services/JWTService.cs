using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FS.Core.Helpers;
using FS.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FS.Core.Services
{
    public class JWTService : IJWTService
    {
        private readonly IConfiguration configuration;

        public JWTService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetToken(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
            };

            if (user.UserName != null)
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName));
            }

            if (user.Email != null)
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            }

            return JWTHelper.GetTokenAsString(
                configuration["Jwt:SecretKey"],
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims.ToArray()
            );
        }
    }
}