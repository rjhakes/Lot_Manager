using System;

namespace Models
{
    public class Lot
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public ContactInfo contactInfo { get; set; }
        public ICollection<Spot> Spots { get; set; }
        
    }
}