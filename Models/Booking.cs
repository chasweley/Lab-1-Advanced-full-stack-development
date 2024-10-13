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
        public DateTime BookingEnds { get; set; }

        [ForeignKey("Users")]
        public int UserId { get; set; }
        public User Users { get; set; }

        [ForeignKey("Tables")]
        public int? TableId { get; set; }
        public Table Tables { get; set; }
    }
}
