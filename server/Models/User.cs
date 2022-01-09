using System;

namespace Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public DateTime DoB { get; set; }
        public ICollection<Vehicle> vehicles { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ContactInfo contactInfo { get; set; }
        public string emergencyName { get; set; }
        public ContactInfo emergencyContact { get; set; }
    }
}