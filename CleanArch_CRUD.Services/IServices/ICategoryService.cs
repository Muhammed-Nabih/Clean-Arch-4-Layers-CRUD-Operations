using CleanArch_CRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CRUD.Services.IServices
{
    public interface ICategoryService
    {
        Task<Category> Add(string name, string description);
        IEnumerable<Category> GetAll();
        Task UpdateCategoryAsync(int categoryId, string name, string description);
    }
}
