using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Infrastructure.Repository
{
    public abstract class RepositoryBase<T> : Repository, IRepository<T> where T : class
    {
        protected DbSet<T> dbSet;

        public RepositoryBase(IUnitOfWork uow) : base(uow)
        {
            dbSet = cntx.Set<T>();
        }


        public virtual T Add(T item)
        {
            return dbSet.Add(item);
        }

        public virtual T Find(object key)
        {
            return dbSet.Find(key);
        }

        public IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual void Remove(object key)
        {
            var removeItem = dbSet.Find(key);
            dbSet.Remove(removeItem);
        }


        public virtual void Update(T item)
        {
            dbSet.Attach(item);
            cntx.Entry(item).State = EntityState.Modified;
        }
    }
}
