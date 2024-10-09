using BCrypt.Net;
using Labb_1___Avancerad_fullstackutveckling.Data;
using Labb_1___Avancerad_fullstackutveckling.Helpers;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Labb_1___Avancerad_fullstackutveckling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TableBookingContext _context;
        private readonly IConfiguration _configuration; // To be able to get the data from appsettings.json

        public AccountController(TableBookingContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterAdminDTO registerAdmin)
        {
            Account existingAdmin = _context.Accounts.SingleOrDefault(a => a.Email == registerAdmin.Email);

            if (existingAdmin != null) { return BadRequest("Email is already registered."); }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(registerAdmin.Password);

            Account newAccount = new Account
            {
                FirstName = registerAdmin.FirstName,
                LastName = registerAdmin.LastName,
                Email = registerAdmin.Email,
                PasswordHash = passwordHash
            };

            _context.Accounts.Add(newAccount);
            _context.SaveChanges();
            
            return Ok();
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginAdminDTO loginAdmin)
        {
            Account admin = _context.Accounts.SingleOrDefault(a => a.Email == loginAdmin.Email);

            if (admin == null || !BCrypt.Net.BCrypt.Verify(loginAdmin.Password, admin.PasswordHash)) 
            {
                return Unauthorized("Invalid username or password.");
            }

            var token = GenerateJwtToken(admin);

            return Ok(new { token });
        }

        private string GenerateJwtToken(Account account)
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
