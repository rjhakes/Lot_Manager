using System;

namespace Models
{
    public class Spot
    {
        public Guid Id { get; set; }
        // public Lot lot { get; set; }
        // public int LotId { get; set; }
        public Lot Lot { get; set; }
        public int Number { get; set; }
        public ICollection<Reservation> Reservation { get; set; }
        // public int level { get; set; }
        // public int electrical { get; set; }
        // public bool gas { get; set; }
        // public Amenities[]? MyProperty { get; set; }
    }
}