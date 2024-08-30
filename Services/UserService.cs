using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;

namespace Labb_1___Avancerad_fullstackutveckling.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepo.GetUserByIdAsync(userId);

            if (user == null) { return null; }

            return new UserDTO
            {
                UserId = userId,
                Name = user.Name,
                PhoneNo = user.PhoneNo
            };
        }

        public async Task CreateUserAsync(UserDTO user)
        {
            var newUser = new User
            {
                Name = user.Name,
                PhoneNo = user.PhoneNo
            };

            await _userRepo.CreateUserAsync(newUser);
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            if (user != null)
            {
                var updatedUser = new User
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    PhoneNo = user.PhoneNo
                };

                await _userRepo.UpdateUserAsync(updatedUser);
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _userRepo.DeleteUserAsync(userId);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var listOfUsers = await _userRepo.GetAllUsersAsync();

            // Select går igenom varenda instans
            return listOfUsers.Select(u => new UserDTO
            {
                UserId = u.UserId,
                Name = u.Name,
                PhoneNo = u.PhoneNo,
            }).ToList();
        }
    }
}
