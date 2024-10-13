using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;

namespace Labb_1___Avancerad_fullstackutveckling.Services.IServices
{
    public interface ITableService
    {
        Task<TableDTO> GetTableByIdAsync(int tableId);
        Task CreateTableAsync(CreateTableDTO table);
        Task UpdateTableAsync(TableDTO table);
        Task DeleteTableAsync(int tableId);
        Task<IEnumerable<TableDTO>> GetAllTablesAsync();
        Task<IEnumerable<TableDTO>> AvailableTablesAsync(DateTime dateTime, int noOfCustomers);
    }
}
