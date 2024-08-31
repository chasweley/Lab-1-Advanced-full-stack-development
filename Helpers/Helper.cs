using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;

namespace Labb_1___Avancerad_fullstackutveckling.Helpers
{
    public class Helper
    {
        //private readonly ITableRepository _tableRepo;
        //private readonly IUserRepository _userRepo;

        //public DatabasebHelper(ITableRepository tableRepo, IUserRepository userRepo)
        //{
        //    _tableRepo = tableRepo;
        //    _userRepo = userRepo;
        //}
        //public async Task CheckIfUserAndTableExistAsync(int userId, int tableId)
        //{
        //    var user = await _userRepo.GetUserByIdAsync(userId);
        //    if (user == null) throw new Exception("User was not found.");

        //    var table = await _tableRepo.GetTableByIdAsync(tableId);
        //    if (table == null) throw new Exception("Table was not found.");
        //}

        public static DateTime DateTimeCleanUp(DateTime dateTime)
        {
            return dateTime.Date.AddHours(dateTime.Hour).AddMinutes(dateTime.Minute);
        }
    }
}
