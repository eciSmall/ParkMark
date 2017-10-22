using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Infrastructure.Repository
{
    public class EFUnitOfWorks : DbContext, IUnitOfWork
    {

        public EFUnitOfWorks(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
        public void Commit()
        {
            SaveChanges();
        }
    }
}
