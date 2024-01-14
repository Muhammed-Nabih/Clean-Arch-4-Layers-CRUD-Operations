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
        IEnumerable<Category> GetAll(Category category);

    }
}
