using System;
using ARCH.DomainFramework;

namespace ARCH.Domain.Customers
{
    public class CustomerEntity : BaseEntity
    {
        public String Name { get; set; }
        public Address Address { get; set; }

    }
}


