using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Labb_1___Avancerad_fullstackutveckling.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingrepo)
        {
            _bookingRepo = bookingrepo;
        }

        public async Task<BookingDTO> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _bookingRepo.GetBookingByIdAsync(bookingId);

            if (booking == null ) { return null; }

            return new BookingDTO
            {
                BookingId = bookingId,
                NoOfCustomers = booking.NoOfCustomers,
                DateAndTime = booking.DateAndTime,
                FK_UserId = booking.FK_UserId,
                FK_TableId = booking.FK_TableId
            };
        }

        public async Task CreateBookingAsync(BookingDTO booking)
        {
            var newBooking = new Booking
            {
                NoOfCustomers = booking.NoOfCustomers,
                DateAndTime = booking.DateAndTime,
                FK_UserId = booking.FK_UserId,
                FK_TableId = booking.FK_TableId
            };

            await _bookingRepo.CreateBookingAsync(newBooking);
        }

        public async Task UpdateBookingAsync(BookingDTO booking)
        {
            if (booking != null) 
            {
                var updatedBooking = new Booking 
                { 
                    BookingId = booking.BookingId,
                    NoOfCustomers = booking.NoOfCustomers,
                    DateAndTime = booking.DateAndTime,
                    FK_UserId = booking.FK_UserId,
                    FK_TableId = booking.FK_TableId
                };

                await _bookingRepo.UpdateBookingAsync(updatedBooking);
            }
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
                FK_UserId = b.FK_UserId,
                FK_TableId = b.FK_TableId
            }).ToList();
        }
    }
}
