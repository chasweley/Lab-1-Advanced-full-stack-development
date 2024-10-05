using Labb_1___Avancerad_fullstackutveckling.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Labb_1___Avancerad_fullstackutveckling.Helpers
{
    public class Helper
    {
        private readonly IConfiguration _configuration; // To be able to get the data from appsettings.json

        public Helper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public static DateTime DateTimeCleanUp(DateTime dateTime)
        {
            return dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
        }

        public string GenerateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];

            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, $"{account.FirstName} {account.LastName}"),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Email, account.Email)
            });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
