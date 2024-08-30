using Labb_1___Avancerad_fullstackutveckling.Models;

namespace Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos
{
    public interface ITableRepository
    {
        Task<Table> GetTableByIdAsync(int tableId);
        Task CreateTableAsync(Table table);
        Task UpdateTableAsync(Table table);
        Task DeleteTableAsync(int tableId);
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task<IEnumerable<Table>> AvailableTablesSpecificDateAndTimeAsync(DateTime dateTime);
    }
}
