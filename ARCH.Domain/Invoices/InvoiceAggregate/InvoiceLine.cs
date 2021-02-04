using System;

namespace ARCH.Domain.Invoices.InvoiceAggregate
{
    public class InvoiceLine 
    {
        public String ProductCode { get; set; }
        public long Quantity { get; set; }
        public double VATPercentage { get; set; }
    }
}