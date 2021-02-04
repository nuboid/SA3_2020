using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using ARCH.Repositories.Dapper.Invoice;

namespace ARCH.InvoiceService
{
    public class Functionality1
    {
        private readonly DbConnection _dbConnection;
        private readonly InvoiceRepository _invoiceRepository;
        private readonly AnotherRepository _anotherRepository;

        //public Functionality1(DbConnection dbConnection, 
        //    InvoiceRepository invoiceRepository,
        //    AnotherRepository anotherRepository
        //    )
        //{
        //    _dbConnection = dbConnection;
        //    _invoiceRepository = invoiceRepository;
        //    _anotherRepository = anotherRepository;
        //}
        public Functionality1(InvoiceRepository invoiceRepository, AnotherRepository anotherRepository)
        {
            var connStr =
                "Data Source=DESKTOP-MH2BT9E;Initial Catalog=ARCH;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            _dbConnection = new SqlConnection(connStr);
            _invoiceRepository = invoiceRepository;
            _anotherRepository = anotherRepository;
        }
        public void CreateInvoiceForCustomer(string customerId, List<InvoiceLineDto> invoiceLines)
        {
            try
            {
                var invoice = Domain.Invoices.InvoiceAggregate.InvoiceFactory.Create();
                foreach (var invoiceLine in invoiceLines)
                {
                    var tavPercentage = 0d;
                    invoice.AddInvoiceLine(invoiceLine.ProductId, invoiceLine.Quantity, tavPercentage);
                }

                _dbConnection.Open();
                using (var transaction = _dbConnection.BeginTransaction())
                {
                    _invoiceRepository.SetConnectionAndTransaction(_dbConnection, transaction);
                    _anotherRepository.SetConnectionAndTransaction(_dbConnection, transaction);
                    try
                    {

                        //Begin Unit Of work

                        _invoiceRepository.Insert(invoice);
                        _anotherRepository.Update(null);

                        //End Unit Of work
                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        //TODO : log exception or return alternative answser
                    }
                }
                _dbConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
