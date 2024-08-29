using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace Labb_1___Avancerad_fullstackutveckling.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(32)]
        public string PhoneNo { get; set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
