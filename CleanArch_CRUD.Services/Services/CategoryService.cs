using CleanArch_CRUD.Domain.Interfaces;
using CleanArch_CRUD.Domain.Models;
using CleanArch_CRUD.Domain;
using CleanArch_CRUD.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch_CRUD.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> AddCategory(string name, string description)
        {
            // Validate and apply business logic
            var newCategory = new Category { Name = name, Description = description };

            // Save to repository
            await _categoryRepository.AddCategory(newCategory);

            // Save changes using the Unit of Work
            await _unitOfWork.SaveChangesAsync();

            return newCategory;
        }

        // Other methods...
    }
}
