using System;

namespace Models
{
    public class Address
    {
        public Guid Id { get; set; }
        public string line1 { get; set; }
        public string? line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }

        public Guid ContactInfoId { get; set; }
        public ContactInfo ContactInfo { get; set; }
    }
}