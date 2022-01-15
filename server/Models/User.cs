using System;

namespace Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime DoB { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AddrLine1 { get; set; }
        public string? AddrLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        // public ContactInfo contactInfo { get; set; }
        public string EName { get; set; }
        public string EPhone { get; set; }
        public string EAddrLine1 { get; set; }
        public string? EAddrLine2 { get; set; }
        public string ECity { get; set; }
        public string EState { get; set; }
        public string EZip { get; set; }
        // public ContactInfo emergencyContact { get; set; }
    }
}