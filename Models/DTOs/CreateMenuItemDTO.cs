using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class CreateMenuItemDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
