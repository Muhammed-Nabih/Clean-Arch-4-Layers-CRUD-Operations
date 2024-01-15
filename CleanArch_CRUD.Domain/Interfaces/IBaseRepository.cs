using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CRUD.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T entity);
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
    }
}
