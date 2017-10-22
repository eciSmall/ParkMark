using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkMark.Infrastructure.Repository
{
    public interface IRepository<T> : IRepositoryBase
    {
        T Find(object key);
        T Add(T item);
        void Update(T item);
        void Remove(object key);
        IEnumerable<T> GetAll();
    }
}
