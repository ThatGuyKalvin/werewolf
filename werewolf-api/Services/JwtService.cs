using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using werewolf_api.Models.Configuration;

namespace werewolf_api.Services
{
    public interface IJwtService
    {
        public string CreateToken(string userId, string sessionId);

    }

    public class JwtService : IJwtService
    {
        private readonly JwtConfig _jwtConfig;

        public JwtService(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        public string CreateToken(string userId, string sessionId)
        {
            // Define the key used to sign the JWT
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create a JWT and add the claims
            var token = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                claims: new[] {
                    new Claim("user", userId),
                    new Claim("session", sessionId)},
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: creds);

            // Get the JWT as a string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}