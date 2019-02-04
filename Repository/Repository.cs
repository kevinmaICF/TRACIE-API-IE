using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TRACIE_API_IE.Interface;
using TRACIE_API_IE.Models;

namespace TRACIE_API_IE.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly TracieIEContext _context;

        public Repository(TracieIEContext context)
        {
            _context = context;
        }

        protected void Save() => _context.SaveChanges();

        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Count();
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public List<T> find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
           return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Save();
        }
    }
}
