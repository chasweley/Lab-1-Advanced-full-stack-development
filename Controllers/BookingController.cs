using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Labb_1___Avancerad_fullstackutveckling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{bookingId}")]
        [Authorize]
        public async Task<ActionResult<BookingCompleteInfoDTO>> GetBookingById(int bookingId)
        {
            var booking = await _bookingService.GetBookingByIdAsync(bookingId);
            return Ok(booking);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateBooking(CreateBookingDTO booking)
        {
            await _bookingService.CreateBookingAsync(booking);
            return Created();
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<ActionResult> UpdateBooking(BookingCompleteInfoDTO booking)
        {
            await _bookingService.UpdateBookingAsync(booking);
            return Ok("Booking updated successfully.");
        }

        [HttpDelete("Delete/{bookingId}")]
        [Authorize]
        public async Task<ActionResult> DeleteBooking(int bookingId)
        {
            await _bookingService.DeleteBookingAsync(bookingId);
            return Ok("Booking deleted successfully.");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<BookingCompleteInfoDTO>>> GetAllBookings()
        {
            var bookingsList = await _bookingService.GetAllBookingsAsync();
            return Ok(bookingsList);
        }
    }
}
