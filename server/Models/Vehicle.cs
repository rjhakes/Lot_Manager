using System;

namespace Models
{
    public class Vehicle
    {
        public Guid Id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string licensePlate { get; set; }
        public string state { get; set; }
        public Guid UserId { get; set; }
        public User user { get; set; }
    }
}