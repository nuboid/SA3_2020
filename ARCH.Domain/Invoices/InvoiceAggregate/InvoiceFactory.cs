using System;
using System.Collections.Generic;
using System.Text;

namespace ARCH.Domain.Invoices.InvoiceAggregate
{
    public static class InvoiceFactory
    {
        public static InvoiceEntity Create()
        {
            var o = new InvoiceEntity();
            return o;
        }
    }
}
