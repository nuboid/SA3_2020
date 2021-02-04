using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ARCH.InvoiceService;
using ARCH.Repositories.Dapper.Invoice;

namespace ARCH.UseCase.CreateInvoice
{
    class Program
    {
        static void Main(string[] args)
        {
            var svcFunction1 = new InvoiceService.Functionality1(
                new InvoiceRepository(),
                new AnotherRepository());

            svcFunction1.CreateInvoiceForCustomer("TEST1", new List<InvoiceLineDto>
            {
                new InvoiceLineDto { ProductId = "p1",Quantity = 100},
                new InvoiceLineDto { ProductId = "p2",Quantity = 200},
            });

            Console.ReadKey();
        }
    }
}
