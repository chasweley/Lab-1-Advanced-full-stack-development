using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb_1___Avancerad_fullstackutveckling.Data.Repos
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TableBookingContext _context;

        public BookingRepository(TableBookingContext context)
        {
            _context = context;
        }
        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            return booking;
        }

        public async Task CreateBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);

            if (booking != null) 
            { 
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            var listOfBookings = await _context.Bookings.ToListAsync();
            return listOfBookings;
        }
    }
}
