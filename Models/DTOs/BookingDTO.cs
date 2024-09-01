﻿using System.Text.Json.Serialization;

namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        [JsonPropertyName("numberOfCustomers")]
        public int NoOfCustomers { get; set; }
        public DateTime BookedDateTime { get; set; }
        public DateTime BookingEnds { get; set; }
        public int UserId { get; set; }
        public int TableId { get; set; }
    }
}
