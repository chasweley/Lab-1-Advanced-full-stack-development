using System.ComponentModel.DataAnnotations;

namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class BookingCompleteInfoDTO
    {
        public int BookingId { get; set; }
        public int NoOfCustomers { get; set; }
        public DateTime BookedDateTime { get; set; }
        public DateTime BookingEnds { get; set; }
        public int UserId { get; set; }
        public string PhoneNo { get; set; }
        public string Name { get; set; }
        public int TableId { get; set; }
        public int SeatingCapacity { get; set; }
    }
}
