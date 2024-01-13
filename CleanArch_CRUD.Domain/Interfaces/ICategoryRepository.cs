using CleanArch_CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CRUD.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> AddCategory(Category category);
    }
}
