using System;

namespace Models
{
    public class ContactInfo
    {
        public Guid Id { get; set; }
        public int countryCode { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }
    }
}