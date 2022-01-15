using System;

namespace Models
{
    public class Lot
    {
        public Guid Id { get; set; }
        public string LotName { get; set; }
        // public ContactInfo contactInfo { get; set; }
        public string Phone { get; set; }
        public string AddrLine1 { get; set; }
        public string? AddrLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public ICollection<Spot> Spots { get; set; }
        
    }
}