using System.Collections.Generic;
using System.Data.Common;
using ARCH.Domain.Invoices.AnotherAggregate;
using ARCH.DomainFramework;

//using Dapper;

namespace ARCH.Repositories.Dapper.Invoice
{
    public class AnotherRepository : IRepository<AnotherEntity>
    {
        private DbConnection _connection;
        private DbTransaction _transaction;

        public void SetConnectionAndTransaction(DbConnection connection, DbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public AnotherEntity GetById(string id)
        {
            return null;
        }

        public List<AnotherEntity> GetAll()
        {
            return null;
        }

        public List<AnotherEntity> GetSpecification(string whereClause)
        {
            return null;
        }

        public AnotherEntity Insert(AnotherEntity o)
        {

            return null;
        }

        public AnotherEntity Update(AnotherEntity o)
        {
            return null;
        }

        public void Delete(AnotherEntity o)
        {

        }
    }

 
}
