using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EiGroupPlc_Application_PublicanChannel.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void Delete(T entity);
        T Update(T entity);

        T GetById(object id);
        T GetByGuid(Guid id);
        IEnumerable<T> GetAll();
    }
}
