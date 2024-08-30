using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser(UserDTO user)
        {
            await _userService.CreateUserAsync(user);
            return Ok(user);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult> UpdateUser(UserDTO user)
        {
            await _userService.UpdateUserAsync(user);
            return Ok(user);
        }

        [HttpDelete("DeleteUser")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUserAsync(userId);
            return Ok();
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAllUsers()
        {
            var usersList = await _userService.GetAllUsersAsync();
            return Ok(usersList);
        }
    }
}

