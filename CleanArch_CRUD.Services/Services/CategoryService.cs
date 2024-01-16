using CleanArch_CRUD.Domain.Models;
using CleanArch_CRUD.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch_CRUD.Domain.Interfaces.ICategoryRepo;
using CleanArch_CRUD.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

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

        public async Task<Category> Add(string name, string description)
        {
            // Validate and apply business logic
            var newCategory = new Category { Name = name, Description = description };

            // Save to repository
            await _categoryRepository.Add(newCategory);

            // Save changes using the Unit of Work
            await _unitOfWork.SaveChangesAsync();

            return newCategory;
        }

        public IEnumerable<Category> GetAll()
        {
            return _categoryRepository.GetAll();
        }

   

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _categoryRepository.GetByIdAsync(categoryId);
        }

        public async Task RemoveCategoryAsync(int categoryId)
        {
            await _categoryRepository.RemoveAsync(categoryId);
        }

        public async Task UpdateCategoryAsync(int categoryId, string name, string description)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if (category != null)
            {
                category.Name = name;
                category.Description = description;

                await _categoryRepository.UpdateAsync(category);

            }
            else
            {
                throw new DirectoryNotFoundException();
            }

        }



        // Other methods...
    }
}
