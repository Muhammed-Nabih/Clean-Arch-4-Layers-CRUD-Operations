using CleanArch_CRUD.Domain.Interfaces;
using CleanArch_CRUD.Domain.Interfaces.ICategoryRepo;
using CleanArch_CRUD.Domain.Models;
using CleanArch_CRUD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace CleanArch_CRUD.Infrastructure.Repositories.CategoryRepo
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly List<Category> _categories = new List<Category>();

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Add(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public IEnumerable<Category> GetAll(Category category)
        {
            return (IEnumerable<Category>)_context.Categories.ToList();
        }

        public IEnumerable<Category> GetAll()
        {
            return (IEnumerable<Category>)_context.Categories.ToList();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);

        }


        public async Task RemoveAsync(int id)
        {
            var category = await GetByIdAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

        }




        /*
IEnumerable<Category> ICategoryRepository.GetAll(Category category)
{
   return (IEnumerable<Category>)_context.Categories.ToListAsync();
}
*/
    }
}
