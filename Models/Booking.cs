using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb_1___Avancerad_fullstackutveckling.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [Required]
        public int NoOfCustomers { get; set; }
        [Required]
        public DateTime BookedDateTime { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Table")]
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
