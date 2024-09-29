using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___Avancerad_fullstackutveckling.Data.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly TableBookingContext _context;

        public UserRepository(TableBookingContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            return user;
        }

        public async Task<int> GetUserIdByPhoneNoAsync(string phoneNo)
        {
            var user = await _context.Users.FindAsync(phoneNo);
            if (user == null) { return 0; }
            return user.UserId;
        } 

        public async Task CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var listOfUsers = await _context.Users.ToListAsync();
            return listOfUsers;
        }
    }
}
