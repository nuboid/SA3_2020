using System;
using System.Collections.Generic;
using System.Text;

namespace ARCH.Domain.Invoices.InvoiceAggregate
{
    public class InvoiceValidationException : Exception
    {
        public InvoiceValidationException(string message) : base(message)
        {
            
        }
    }
}
