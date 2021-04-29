using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace ProjectBackend.Models
{
    public class Brewer
    {
        public int BrewerId { get; set; }
        public string Name { get; set; }
        public string HeadOffice { get; set; }
        
        [JsonIgnore]
        public List<Beer> Beer { get; set; }

    }
}
    	