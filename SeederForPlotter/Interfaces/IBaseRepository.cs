using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeederForPlotter.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Add();
        Task Delete();
        Task<T> Update(T entity);
        IQueryable<T> GetAll();
    }
}
