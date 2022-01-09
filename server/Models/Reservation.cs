using System;

namespace Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public int SpotId { get; set; }
        public Spot Spot { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime date { get; set; }
        // public Addon[]? addons { get; set; }
        public string? description { get; set; }
        public string? review { get; set; }
    }
}