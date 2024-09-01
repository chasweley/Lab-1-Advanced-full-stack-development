using System.Text.Json.Serialization;

namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class CreateBookingDTO
    {
        [JsonPropertyName("numberOfCustomers")]
        public int NoOfCustomers { get; set; }
        public DateTime BookedDateTime { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
    }
}
