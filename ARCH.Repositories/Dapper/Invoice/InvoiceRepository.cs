using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using ARCH.Domain.Invoices.InvoiceAggregate;
using ARCH.DomainFramework;
using Dapper;

//using Dapper;

namespace ARCH.Repositories.Dapper.Invoice
{
    public class InvoiceRepository : IRepository<InvoiceEntity>
    {
        private DbConnection _connection;
        private DbTransaction _transaction;

     
        public void SetConnectionAndTransaction(DbConnection connection, DbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public InvoiceEntity GetById(string id)
        {
            return null;
        }

        public List<InvoiceEntity> GetAll()
        {
            return null;
        }

        public List<InvoiceEntity> GetSpecification(string whereClause)
        {
            return null;
        }

        public InvoiceEntity Insert(InvoiceEntity o)
        {

            var sqlInsertInvoice = "INSERT INTO [dbo].[Invoice]([InvoiceNumber],[CustomerFK]) VALUES (@InvoiceNumber,@CustomerFK)";
            var sqlInsertLines = "INSERT INTO [dbo].[InvoiceLines]([InvoiceLineFK],[ProductFK],[Quantity],[VATPercentage]) VALUES (@InvoiceLineFK,@ProductFK,@Quantity,@VATPercentage)";
            _connection.Execute(sqlInsertInvoice, new { InvoiceNumber = o.InvoiceNumber, CustomerFK = "FK" }, _transaction);
            //o.ID = (int)_connection.ExecuteScalar("SELECT @@IDENTITY");
            o.ID = 999;
            foreach (var l in o.InvoiceLines)
            {
                _connection.Execute(sqlInsertLines, new { InvoiceLineFK = o.ID, ProductFK = "FK", Quantity = l.Quantity, VATPercentage = l.VATPercentage }, _transaction);
            }
            return o;
        }

        public InvoiceEntity Update(InvoiceEntity o)
        {
            return null;
        }

        public void Delete(InvoiceEntity o)
        {

        }
    }
}
