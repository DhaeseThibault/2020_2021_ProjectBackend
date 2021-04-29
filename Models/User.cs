using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjectBackend.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        
        [JsonIgnore]
        public List<BeerUser> BeerUser { get; set; }

    }
}
