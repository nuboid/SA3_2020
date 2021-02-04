using System;

namespace ARCH.Domain.Customers
{
    public class Address
    {
        public String Street { get; set; }
        public String StreetNr { get; set; }
        public String City { get; set; }
        public String PostalCode { get; set; }
        public String Country { get; set; }
    }
}