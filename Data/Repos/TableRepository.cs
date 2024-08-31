using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___Avancerad_fullstackutveckling.Data.Repos
{
    public class TableRepository : ITableRepository
    {

        private readonly TableBookingContext _context;

        public TableRepository(TableBookingContext context)
        {
            _context = context;
        }

        public async Task<Table> GetTableByIdAsync(int tableId)
        {
            return await _context.Tables.FindAsync(tableId);
        }

        public async Task CreateTableAsync(Table table)
        {
            await _context.Tables.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTableAsync(Table table)
        {
            _context.Tables.Update(table);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTableAsync(int tableId)
        {
            var table = await _context.Tables.FindAsync(tableId);

            if (table != null) 
            {
                _context.Tables.Remove(table);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {
            var listOfTables = await _context.Tables.ToListAsync();
            return listOfTables;
        }

        public async Task<IEnumerable<Table>> AvailableTablesSpecificDateAndTimeAsync(DateTime dateTime)
        {
            var listOfAvailableTables = await _context.Bookings
                .Where(d => d.BookedDateTime != dateTime)
                .Select(t => t.Table)
                .ToListAsync();
            return listOfAvailableTables;
        }
    }
}
