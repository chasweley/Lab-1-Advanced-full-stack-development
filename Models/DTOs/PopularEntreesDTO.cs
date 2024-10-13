using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class PopularEntreesDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
