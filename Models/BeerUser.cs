using System;

namespace ProjectBackend.Models
{
    public class BeerUser
    {
        public int BeerUserId { get; set; }
        
        public int BrewerId { get; set; }
        public Brewer Brewer { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
