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

        public async Task CreateTableAsync(CreateTableDTO table)
        {
            try
            {
                var newTable = new Table { SeatingCapacity = table.SeatingCapacity };

                await _tableRepo.CreateTableAsync(newTable);
            }
            catch (Exception ex)
            {
                 throw new Exception($"An error occured while trying to create table. {ex.Message}");
            }
        }

        public async Task UpdateTableAsync(TableDTO table)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to update table. {ex.Message}");
            }
        }

        public async Task DeleteTableAsync(int tableId)
        {
            try
            {
                await _tableRepo.DeleteTableAsync(tableId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to delete table. {ex.Message}");
            }
        }

        public async Task<IEnumerable<TableDTO>> GetAllTablesAsync()
        {
            try
            {
                var listOfTables = await _tableRepo.GetAllTablesAsync();

                return listOfTables.Select(t => new TableDTO
                {
                    TableId = t.TableId,
                    SeatingCapacity = t.SeatingCapacity
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<TableDTO>> AvailableTablesAsync(DateTime dateTime, int noOfCustomers)
        {
            var listOfTables = await _tableRepo.GetAllTablesAsync();

            List<Table> listOfAvailableTables = listOfTables.ToList();

            foreach (Table table in listOfTables)
            {
                bool isTableBooked = await _tableRepo.CheckIfTableAlreadyBookedAsync(table.TableId, dateTime);

                if (isTableBooked)
                {
                    var tableToRemove = listOfAvailableTables.SingleOrDefault(t => t.TableId == table.TableId);
                    listOfAvailableTables.Remove(tableToRemove);
                };
            }

            return listOfAvailableTables.Where(t => t.SeatingCapacity >= noOfCustomers).Select(t => new TableDTO
            {
                TableId = t.TableId,
                SeatingCapacity = t.SeatingCapacity
            }).ToList();
        }
    }
}
