﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Labb_1___Avancerad_fullstackutveckling.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNo { get; set; }
    }
}
