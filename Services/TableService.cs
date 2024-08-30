using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;

namespace Labb_1___Avancerad_fullstackutveckling.Services
{
    public class TableService : ITableService
    {
        private readonly ITableRepository _tableRepo;

        public TableService(ITableRepository tableRepo)
        {
            _tableRepo = tableRepo;
        }

        public async Task<TableDTO> GetTableByIdAsync(int tableId)
        {
            var table = await _tableRepo.GetTableByIdAsync(tableId);

            if (table == null) { return null; }

            return new TableDTO
            {
                TableId = table.TableId,
                SeatingCapacity = table.SeatingCapacity
            };
        }

        public async Task CreateTableAsync(TableDTO table)
        {
            var newTable = new Table { SeatingCapacity = table.SeatingCapacity };

            await _tableRepo.CreateTableAsync(newTable);
        }

        public async Task UpdateTableAsync(TableDTO table)
        {
            if (table != null)
            {
                var updatedTable = new Table
                {
                    TableId = table.TableId,
                    SeatingCapacity = table.SeatingCapacity,
                };

                await _tableRepo.UpdateTableAsync(updatedTable);
            }
        }

        public async Task DeleteTableAsync(int tableId)
        {
            await _tableRepo.DeleteTableAsync(tableId);
        }

        public async Task<IEnumerable<TableDTO>> GetAllTablesAsync()
        {
            var listOfTables = await _tableRepo.GetAllTablesAsync();

            return listOfTables.Select(t => new TableDTO 
            { 
                TableId = t.TableId, 
                SeatingCapacity = t.SeatingCapacity 
            }).ToList();
        }

        public async Task<IEnumerable<TableDTO>> AvailableTablesSpecificDateAndTimeAsync(DateTime dateTime)
        {
            var listOfAvailableTables = await _tableRepo.AvailableTablesSpecificDateAndTimeAsync(dateTime);

            return listOfAvailableTables.Select(t => new TableDTO
            {
                TableId = t.TableId,
                SeatingCapacity = t.SeatingCapacity
            }).ToList();
        }
    }
}
