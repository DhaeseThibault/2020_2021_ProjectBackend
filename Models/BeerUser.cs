using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectBackend.Models
{
    public class BeerUser
    {
        public int BeerId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
