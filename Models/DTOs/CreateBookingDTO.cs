using System.Text.Json.Serialization;

namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class CreateBookingDTO
    {
        public int NoOfCustomers { get; set; }
        public DateTime BookedDateTime { get; set; }
        //public string PhoneNo { get; set; }
        //public string Name { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
    }
}
