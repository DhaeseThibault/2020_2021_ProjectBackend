using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectBackend.Models
{
    public class BeerUser
    {
        public Guid BeerUserId { get; set; }
        
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
