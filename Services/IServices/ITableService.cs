using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;

namespace Labb_1___Avancerad_fullstackutveckling.Services.IServices
{
    public interface ITableService
    {
        Task<TableDTO> GetTableByIdAsync(int tableId);
        Task CreateTableAsync(TableDTO table);
        Task UpdateTableAsync(TableDTO table);
        Task DeleteTableAsync(int tableId);
        Task<IEnumerable<TableDTO>> GetAllTablesAsync();
        Task<IEnumerable<TableDTO>> AvailableTablesSpecificDateAndTimeAsync(DateTime dateTime);
    }
}
