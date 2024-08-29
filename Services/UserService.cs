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

        public async Task<User> GetUserByIdAsync(int userId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public async Task DeleteUserAsync(int userId)
        {
            throw new NotImplementedException();
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
