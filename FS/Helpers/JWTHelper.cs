using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FS.Helpers
{
    public static class JWTHelper
    {
        public static JwtSecurityToken GetToken(string secretKey, string issuer, string audience, Claim[] claims)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256
            );

            return new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.Now.AddMonths(3),
                signingCredentials: signingCredentials
            );
        }

        public static string GetTokenAsString(string secretKey, string issuer, string audience, Claim[] claims)
        {
            return new JwtSecurityTokenHandler().WriteToken(GetToken(secretKey, issuer, audience, claims));
        }
    }
}