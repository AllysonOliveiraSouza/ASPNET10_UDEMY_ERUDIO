using Microsoft.EntityFrameworkCore;
using ProjetoPrincipal.Context;
using System.Data;

namespace ProjetoPrincipal.Repositories.Implementations
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly AppDbContext _context;
        private DbSet<T> _dataset;

        public RepositoryBase(AppDbContext context) { 
            _context = context;
            _dataset = context.Set<T>();
        }

        public T Create(T obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public void Delete(long id)
        {
            var existingItem = _dataset.Find(id);
            if (existingItem != null) {
                _context.Remove(existingItem);
                _context.SaveChanges();
            }
        }

        public bool Exists(long id)
        {
            return _dataset.Find(id)!=null;            
        }

        public List<T> FindAll()
        {
            return [.._dataset.AsNoTracking()];
        }

        public T FindById(long id)
        {
            var item = _dataset.Find(id);
            return item;
        }

        public T Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
            return obj;
        }
    }
}
