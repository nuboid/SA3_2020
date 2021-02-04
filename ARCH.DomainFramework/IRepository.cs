using System.Collections.Generic;
using System.Data.Common;

namespace ARCH.DomainFramework
{
    public interface IRepository<T>
    {
        //CRUD

        void SetConnectionAndTransaction(DbConnection connection, DbTransaction transaction);

        T GetById(string id);
        List<T> GetAll();
        List<T> GetSpecification(string whereClause);
        T Insert(T o);
        T Update(T o);
        void Delete(T o);
    }
}
