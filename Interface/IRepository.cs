using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TRACIE_API_IE.Interface
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        List<T> find(Func<T, bool> predicate);

        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        int Count(Func<T, bool> predicate);
    }
}
