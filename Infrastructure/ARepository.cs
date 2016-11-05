using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ARepository<T> : IRepository<T>
        where T : class
    {
        protected IDbSet<T> _dbSet;

        protected DbContext _context;

        public ARepository(DbContext dbContext)
        {
            _context = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public IQueryable<T> Items
        {
            get { return _dbSet; }
        }

        public T AddItem(T item)
        {
            return _dbSet.Add(item);
        }

        public T UpdateItem(T item)
        {
            return item;
        }

        public T Remove(T item)
        {
            return _dbSet.Remove(item);
        }

        public void Save()
        {
            _context.ChangeTracker.DetectChanges();
            _context.SaveChanges();
        }

        public void Dispose()
        {
        }
    }
}
