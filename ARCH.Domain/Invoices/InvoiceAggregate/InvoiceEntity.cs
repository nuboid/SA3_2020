using System;
using System.Collections.Generic;
using ARCH.Domain.Customers;
using ARCH.DomainFramework;

namespace ARCH.Domain.Invoices.InvoiceAggregate
{
    public class InvoiceEntity : BaseEntity
    {
        public String InvoiceNumber { get; }
        public CustomerEntity Customer { get; }
        public List<InvoiceLine> InvoiceLines { get; }

        public InvoiceEntity()
        {
            InvoiceLines = new List<InvoiceLine>();
        }

        public void AddInvoiceLine(string productCode, long quantity, double vatPercentage)
        {
            Validate(productCode, quantity, vatPercentage);
            InvoiceLines.Add( new InvoiceLine
            {
                ProductCode = productCode,
                Quantity = quantity,
                VATPercentage = vatPercentage
            });
        }

        private void Validate(string productCode, long quantity, double vatPercentage)
        {
            if (productCode == "")
            {
                throw new InvoiceValidationException("ProductCode is empty.");
            }
        }
    }
}
