using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int NoOfCustomers { get; set; }
        public DateTime DateAndTime { get; set; }
        public int FK_UserId { get; set; }
        public int FK_TableId { get; set; }
    }
}
