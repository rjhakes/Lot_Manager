using System;

namespace Models
{
    public class Reservation
    {
        public Guid Id { get; set; }
        // public int SpotId { get; set; }
        public Spot Spot { get; set; }
        // public int UserId { get; set; }
        public User User { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // public Addon[]? addons { get; set; }
        public string? Description { get; set; }
        public string? Review { get; set; }
    }
}