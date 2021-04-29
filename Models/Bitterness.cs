using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;


namespace ProjectBackend.Models
{
    public class Bitterness
    {
        // [Key]
        public int BitternessId { get; set; }
        public int AmountIBU { get; set; }
       
        [JsonIgnore]
        public List<Beer> Beer { get; set; }
    }
}
