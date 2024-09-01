using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Labb_1___Avancerad_fullstackutveckling.Helpers;
using Microsoft.AspNetCore.Mvc;

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
            try 
            {
                var booking = await _bookingRepo.GetBookingByIdAsync(bookingId);

                if (booking == null) { return null; }

                return new BookingDTO
                {
                    BookingId = bookingId,
                    NoOfCustomers = booking.NoOfCustomers,
                    BookedDateTime = booking.BookedDateTime,
                    BookingEnds = booking.BookingEnds,
                    UserId = booking.UserId,
                    TableId = booking.TableId
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task CreateBookingAsync(CreateBookingDTO booking)
        {
            // To check if user and table exist before creating the booking
            // If not, exception is thrown
            await CheckIfUserAndTableExist(booking.UserId, booking.TableId);

            // To clean up the time so seconds and milliseconds won't be saved to the database
            DateTime dateTime = Helper.DateTimeCleanUp(booking.BookedDateTime);

            bool isTableBooked = await _tableRepo.CheckIfTableAlreadyBooked(booking.TableId, dateTime);

            if (isTableBooked)
            {
                throw new Exception("Table is already booked the requested time.");
            }
            else
            {
                try
                {
                    var newBooking = new Booking
                    {
                        NoOfCustomers = booking.NoOfCustomers,
                        BookedDateTime = dateTime,
                        BookingEnds = dateTime.AddHours(2),
                        UserId = booking.UserId,
                        TableId = booking.TableId
                    };

                    await _bookingRepo.CreateBookingAsync(newBooking);
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occured while trying to create booking. {ex.Message}");
                }
            }
        }

        public async Task UpdateBookingAsync(BookingDTO booking)
        {
            await CheckIfUserAndTableExist(booking.UserId, booking.TableId);

            DateTime dateTime = Helper.DateTimeCleanUp(booking.BookedDateTime);
            DateTime bookingEnds = Helper.DateTimeCleanUp(booking.BookingEnds);

            try
            {
                var updatedBooking = new Booking
                {
                    BookingId = booking.BookingId,
                    NoOfCustomers = booking.NoOfCustomers,
                    BookedDateTime = dateTime,
                    BookingEnds = bookingEnds,
                    UserId = booking.UserId,
                    TableId = booking.TableId
                };

                await _bookingRepo.UpdateBookingAsync(updatedBooking);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to update booking. {ex.Message}");
            }

        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            try
            {
                await _bookingRepo.DeleteBookingAsync(bookingId);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occured while trying to delete booking. {ex.Message}");
            }
            
        }

        public async Task<IEnumerable<BookingDTO>> GetAllBookingsAsync()
        {
            try
            {
                var listOfBookings = await _bookingRepo.GetAllBookingsAsync();

                return listOfBookings.Select(b => new BookingDTO
                {
                    BookingId = b.BookingId,
                    NoOfCustomers = b.NoOfCustomers,
                    BookedDateTime = b.BookedDateTime,
                    BookingEnds = b.BookingEnds,
                    UserId = b.UserId,
                    TableId = b.TableId
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task CheckIfUserAndTableExist(int userId, int tableId)
        {
            try
            {
                var user = await _userRepo.GetUserByIdAsync(userId);
                if (user == null) throw new Exception("User was not found.");

                var table = await _tableRepo.GetTableByIdAsync(tableId);
                if (table == null) throw new Exception("Table was not found.");
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
