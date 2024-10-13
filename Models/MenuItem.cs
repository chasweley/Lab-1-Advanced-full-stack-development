using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Labb_1___Avancerad_fullstackutveckling.Models
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Precision(10,2)]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(20)]
        public string Category { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public bool IsPopular { get; set; }
    }
}
