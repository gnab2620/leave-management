using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Contract
{
    public interface IRepositoryBase<T>
        where T:class
    {
        ICollection<T> FindAll();

        T FindById(int id);
        bool isExist(int id);
        bool Update(T entity);
        bool Create(T entity);
        bool Delete(T entity);

        bool Save();
    }
}
