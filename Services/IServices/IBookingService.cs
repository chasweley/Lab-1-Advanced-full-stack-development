using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;

namespace Labb_1___Avancerad_fullstackutveckling.Services.IServices
{
    public interface IBookingService
    {
        Task<BookingCompleteInfoDTO> GetBookingByIdAsync(int bookingId);
        Task CreateBookingAsync(CreateBookingDTO booking);
        Task UpdateBookingAsync(BookingCompleteInfoDTO booking);
        Task DeleteBookingAsync(int bookingId);
        Task<IEnumerable<BookingCompleteInfoDTO>> GetAllBookingsAsync();
        Task CheckIfUserAndTableExist(int userId, int tableId);
    }
}
