using Labb_1___Avancerad_fullstackutveckling.Models.DTOs;
using Labb_1___Avancerad_fullstackutveckling.Services.IServices;
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
        public async Task<ActionResult<UserDTO>> GetBookingById(int bookingId)
        {
            var booking = await _bookingService.GetBookingByIdAsync(bookingId);
            return Ok(booking);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateBooking(BookingDTO booking)
        {
            await _bookingService.CreateBookingAsync(booking);
            return Ok(booking);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateBooking(BookingDTO booking)
        {
            await _bookingService.UpdateBookingAsync(booking);
            return Ok(booking);
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult> DeleteBooking(int bookingId)
        {
            await _bookingService.DeleteBookingAsync(bookingId);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetAllBookings()
        {
            var bookingsList = await _bookingService.GetAllBookingsAsync();
            return Ok(bookingsList);
        }
    }
}
