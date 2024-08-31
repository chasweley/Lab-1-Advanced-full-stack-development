using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Labb_1___Avancerad_fullstackutveckling.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly ITableRepository _tableRepo;
        private readonly IUserRepository _userRepo;

        public BookingService(IBookingRepository bookingrepo, ITableRepository tableRepo, IUserRepository userRepo)
        {
            _bookingRepo = bookingrepo;
            _tableRepo = tableRepo;
            _userRepo = userRepo;
        }

        public async Task<BookingDTO> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _bookingRepo.GetBookingByIdAsync(bookingId);

            if (booking == null ) { return null; }

            return new BookingDTO
            {
                BookingId = bookingId,
                NoOfCustomers = booking.NoOfCustomers,
                BookedDateTime = booking.BookedDateTime,
                UserId = booking.UserId,
                TableId = booking.TableId
            };
        }

        public async Task CreateBookingAsync(BookingDTO booking)
        {
            var user = await _userRepo.GetUserByIdAsync(booking.UserId);
            if (user == null) throw new Exception("User was not found.");

            var table = await _tableRepo.GetTableByIdAsync(booking.TableId);
            if (table == null) throw new Exception("Table was not found.");

            var newBooking = new Booking
            {
                NoOfCustomers = booking.NoOfCustomers,
                BookedDateTime = booking.BookedDateTime,
                UserId = booking.UserId,
                TableId = booking.TableId
            };

            await _bookingRepo.CreateBookingAsync(newBooking);
        }

        public async Task UpdateBookingAsync(BookingDTO booking)
        {
            var user = await _userRepo.GetUserByIdAsync(booking.UserId);
            if (user == null) throw new Exception("User was not found.");

            var table = await _tableRepo.GetTableByIdAsync(booking.TableId);
            if (table == null) throw new Exception("Table was not found.");

            var updatedBooking = new Booking 
            { 
                BookingId = booking.BookingId,
                NoOfCustomers = booking.NoOfCustomers,
                BookedDateTime = booking.BookedDateTime,
                UserId = booking.UserId,
                TableId = booking.TableId
            };

            await _bookingRepo.UpdateBookingAsync(updatedBooking);
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            await _bookingRepo.DeleteBookingAsync(bookingId);
        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            var listOfBookings = await _bookingRepo.GetAllBookingsAsync();

            return listOfBookings.Select(b => new BookingDTO
            { 
                BookingId = b.BookingId, 
                NoOfCustomers = b.NoOfCustomers,
                BookedDateTime = b.BookedDateTime,
                UserId = b.UserId,
                TableId = b.TableId
            }).ToList();
        }
    }
}
