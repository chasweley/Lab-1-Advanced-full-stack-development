using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Labb_1___Avancerad_fullstackutveckling.Models
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }
        [Required]
        public int SeatingCapacity { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
