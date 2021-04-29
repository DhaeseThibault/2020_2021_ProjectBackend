using System;

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
