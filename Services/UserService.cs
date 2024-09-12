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
                UserId = user.UserId,
                Name = user.Name,
                PhoneNo = user.PhoneNo
            };
        }

        public async Task CreateUserAsync(CreateUserDTO user)
        {
            try
            {
                var newUser = new User
                {
                    Name = user.Name,
                    PhoneNo = user.PhoneNo
                };

                await _userRepo.CreateUserAsync(newUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to create user. {ex.Message}");
            }
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to update user. {ex.Message}");
            }
        }

        public async Task DeleteUserAsync(int userId)
        {
            try
            {
                await _userRepo.DeleteUserAsync(userId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to delete user. {ex.Message}");
            }
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var listOfUsers = await _userRepo.GetAllUsersAsync();

            return listOfUsers.Select(u => new UserDTO
            {
                UserId = u.UserId,
                Name = u.Name,
                PhoneNo = u.PhoneNo,
            }).ToList();
        }
    }
}
