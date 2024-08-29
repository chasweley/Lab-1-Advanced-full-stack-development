using System.ComponentModel.DataAnnotations;

namespace Labb_1___Avancerad_fullstackutveckling.Models
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        [Required]
        [MaxLength(50)]
        public string MenuItem { get; set; }
        public decimal Price { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
    }
}
