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
        public DateTime DateAndTime { get; set; }

        [ForeignKey("User")]
        public int FK_UserId { get; set; }
        public User Users { get; set; }

        [ForeignKey("Table")]
        public int FK_TableId { get; set; }
        public Table Tables { get; set; }
    }
}
