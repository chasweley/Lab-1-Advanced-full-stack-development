using BCrypt.Net;
using Labb_1___Avancerad_fullstackutveckling.Data;
using Labb_1___Avancerad_fullstackutveckling.Helpers;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Labb_1___Avancerad_fullstackutveckling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly TableBookingContext _context;

        public AccountController(TableBookingContext context)
        {
            _context = context;
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

            var token = Helper.GenerateJwtToken(admin);

            return Ok(new { token });
        }

    }
}
