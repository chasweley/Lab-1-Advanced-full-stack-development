using Labb_1___Avancerad_fullstackutveckling.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___Avancerad_fullstackutveckling.Data
{
    public class TableBookingContext : DbContext
    {
        public TableBookingContext(DbContextOptions<TableBookingContext> options) : base (options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
