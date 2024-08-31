namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public int NoOfCustomers { get; set; }
        public DateTime BookedDateTime { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
    }
}
