using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Infrastructure.Repository
{
    public abstract class Repository : IRepositoryBase
    {
        protected DbContext cntx;

        public Repository(IUnitOfWork uow)
        {
            this.cntx = (DbContext)uow;
        }
        public virtual void Save()
        {
            cntx.SaveChanges();
        }
    }
}
