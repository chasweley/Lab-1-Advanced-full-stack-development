using System.Text.Json.Serialization;

namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNo { get; set; }
    }
}
