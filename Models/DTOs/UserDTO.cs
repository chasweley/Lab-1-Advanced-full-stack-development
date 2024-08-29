using System.ComponentModel.DataAnnotations;

namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
    }
}
