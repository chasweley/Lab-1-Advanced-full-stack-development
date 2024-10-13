using Labb_1___Avancerad_fullstackutveckling.Data.Repos.IRepos;
using Labb_1___Avancerad_fullstackutveckling.Models;
using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Labb_1___Avancerad_fullstackutveckling.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

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

        public async Task<BookingCompleteInfoDTO> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _bookingRepo.GetBookingByIdAsync(bookingId);

            if (booking == null) { return null; }

            if (booking.TableId == null)
            {
                return new BookingCompleteInfoDTO
                {
                    BookingId = bookingId,
                    NoOfCustomers = booking.NoOfCustomers,
                    BookedDateTime = booking.BookedDateTime,
                    BookingEnds = booking.BookingEnds,
                    UserId = booking.UserId,
                    Name = booking.Users.Name,
                    PhoneNo = booking.Users.PhoneNo,
                    TableId = null,
                    SeatingCapacity = null
                };
            }
            else
            {
                return new BookingCompleteInfoDTO
                {
                    BookingId = bookingId,
                    NoOfCustomers = booking.NoOfCustomers,
                    BookedDateTime = booking.BookedDateTime,
                    BookingEnds = booking.BookingEnds,
                    UserId = booking.UserId,
                    Name = booking.Users.Name,
                    PhoneNo = booking.Users.PhoneNo,
                    TableId = booking.TableId,
                    SeatingCapacity = booking.Tables.SeatingCapacity
                };
            }
        }

        public async Task CreateBookingAsync(CreateBookingDTO booking)
        {
            int userId = await _userRepo.GetUserIdByPhoneNoAsync(booking.PhoneNo);

            if (userId == 0)
            {
                var newUser = new User
                {
                    Name = booking.Name,
                    PhoneNo = booking.PhoneNo
                };
                await _userRepo.CreateUserAsync(newUser);

                userId = await _userRepo.GetUserIdByPhoneNoAsync(booking.PhoneNo);
            }

            // To clean up the time so seconds and milliseconds won't be saved to the database
            DateTime dateTime = Helper.DateTimeCleanUp(booking.BookedDateTime);

            bool isTableBooked = false;

            if (booking.TableId != null)
            {
                isTableBooked = await _tableRepo.CheckIfTableAlreadyBookedAsync(booking.TableId.GetValueOrDefault(), dateTime);
            }

            if (isTableBooked)
            {
                throw new Exception("Table is already booked the requested time.");
            }
            else
            {
                var newBooking = new Booking
                {
                    NoOfCustomers = booking.NoOfCustomers,
                    BookedDateTime = dateTime,
                    BookingEnds = dateTime.AddHours(2),
                    UserId = userId,
                    TableId = booking.TableId
                };

                await _bookingRepo.CreateBookingAsync(newBooking);
            }
        }

        public async Task UpdateBookingAsync(BookingCompleteInfoDTO booking)
        {
            //await CheckIfUserAndTableExist(booking.UserId, booking.TableId);

            DateTime dateTime = Helper.DateTimeCleanUp(booking.BookedDateTime);
            DateTime bookingEnds = dateTime.AddHours(2);

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

                var updatedUser = new User
                {
                    UserId = booking.UserId,
                    Name = booking.Name,
                    PhoneNo = booking.PhoneNo
                };

                await _userRepo.UpdateUserAsync(updatedUser);
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

        public async Task<IEnumerable<BookingCompleteInfoDTO>> GetAllBookingsAsync()
        {
            var listOfBookings = await _bookingRepo.GetAllBookingsAsync();
            
            return listOfBookings
                .Select(b =>
                {
                    if (b.TableId == null)
                    {
                        return new BookingCompleteInfoDTO
                        {
                            BookingId = b.BookingId,
                            NoOfCustomers = b.NoOfCustomers,
                            BookedDateTime = b.BookedDateTime,
                            BookingEnds = b.BookingEnds,
                            UserId = b.UserId,
                            Name = b.Users.Name,
                            PhoneNo = b.Users.PhoneNo,
                            TableId = null,
                            SeatingCapacity = null
                        };
                    }
                    else 
                    {
                        return new BookingCompleteInfoDTO
                        {
                            BookingId = b.BookingId,
                            NoOfCustomers = b.NoOfCustomers,
                            BookedDateTime = b.BookedDateTime,
                            BookingEnds = b.BookingEnds,
                            UserId = b.UserId,
                            Name = b.Users.Name,
                            PhoneNo = b.Users.PhoneNo,
                            TableId = b.TableId,
                            SeatingCapacity = b.Tables.SeatingCapacity
                        };
                    }
                }).ToList();
        }
    }

}
