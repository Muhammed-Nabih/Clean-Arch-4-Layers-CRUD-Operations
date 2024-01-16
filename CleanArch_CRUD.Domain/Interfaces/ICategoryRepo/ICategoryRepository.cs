using CleanArch_CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CRUD.Domain.Interfaces.ICategoryRepo
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<Category> Add(Category category);
        Task<Category> GetByIdAsync(int id);
        IEnumerable<Category> GetAll();
        Task UpdateAsync(Category category);
        Task RemoveAsync(int id);

    }
}
