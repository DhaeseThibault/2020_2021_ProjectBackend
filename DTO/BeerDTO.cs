using System;
using System.Collections.Generic;


namespace ProjectBackend.DTO
{
    public class BeerDTO
    {
        public string Name { get; set; }
        public int Percentage { get; set; }
        public string Origin { get; set; }
        public int BitternessId { get; set; }
        public int BrewerId { get; set; }
        public List<int> Users { get; set; }

    }
}
