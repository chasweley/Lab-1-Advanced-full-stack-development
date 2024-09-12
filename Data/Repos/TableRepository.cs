using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;

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

        // Behöver finslipas
        public async Task<bool> CheckIfTableAlreadyBookedAsync(int tableId, DateTime dateTime)
        {
            var isTableBooked = await _context.Bookings
                .AnyAsync(t => t.TableId == tableId && ((t.BookedDateTime >= dateTime && t.BookingEnds <= dateTime.AddHours(2))
                || (t.BookedDateTime < dateTime && t.BookingEnds > dateTime)));

            return isTableBooked;
        }
    }
}
