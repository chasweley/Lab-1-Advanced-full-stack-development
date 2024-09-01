using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Labb_1___Avancerad_fullstackutveckling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            return Ok(user);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateUser(CreateUserDTO user)
        {
            await _userService.CreateUserAsync(user);
            return Ok("User created successfully.");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateUser(UserDTO user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok("User updated successfully.");
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUserAsync(userId);
            return Ok("User deleted successfully.");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var usersList = await _userService.GetAllUsersAsync();
            return Ok(usersList);
        }
    }
}

