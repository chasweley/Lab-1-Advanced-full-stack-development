using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;

namespace Labb_1___Avancerad_fullstackutveckling.Services.IServices
{
    public interface IBookingService
    {
        Task<BookingDTO> GetBookingByIdAsync(int bookingId);
        Task CreateBookingAsync(BookingDTO booking);
        Task UpdateBookingAsync(BookingDTO booking);
        Task DeleteBookingAsync(int bookingId);
        Task<IEnumerable<BookingDTO>> GetAllBookingsAsync();
        Task CheckIfUserAndTableExist(int userId, int tableId);
    }
}
