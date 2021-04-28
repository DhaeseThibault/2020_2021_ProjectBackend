using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace ProjectBackend.Models
{
    public class Beer
    {
        public Guid BeerId { get; set; }
        public string Name { get; set; }
        public float Percentage { get; set; }
        public string Origin { get; set; }        
        [JsonIgnore]
        public List<Bitterness> Bitterness { get; set; }  
        [JsonIgnore]
        public List<Brewer> Brewer { get; set; }
    }
}
