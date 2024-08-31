using Labb_1___Avancerad_fullstackutveckling.Models;

namespace Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task CreateBookingAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int bookingId);
        Task<IEnumerable<Booking>> GetAllBookingsAsync();
    }
}
