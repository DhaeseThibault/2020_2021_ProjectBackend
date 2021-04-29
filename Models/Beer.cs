using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace ProjectBackend.Models
{
    public class Beer
    {
        public int BeerId { get; set; }
        public string Name { get; set; }
        public string Percentage { get; set; }
        public string Origin { get; set; }   
        
        public int BitternessId { get; set; }
        public Bitterness Bitterness { get; set; }  
        
        public int BrewerId { get; set; }
        public Brewer Brewer { get; set; }

        [JsonIgnore]
        public List<BeerUser> BeerUser { get; set; }
    }
}
