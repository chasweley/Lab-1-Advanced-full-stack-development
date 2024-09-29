using Labb_1___Avancerad_fullstackutveckling.Models;

namespace Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<int> GetUserIdByPhoneNoAsync(string phoneNo);
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
