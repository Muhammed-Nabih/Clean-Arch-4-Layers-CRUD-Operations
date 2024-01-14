using CleanArch_CRUD.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArch_CRUD.Domain.DTOs;

namespace CleanArch_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] CategoryDTO request)
        {
            var newCategory = await _categoryService.Add(request.Name, request.Description);
            return Ok(newCategory);
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        // DTO (Data Transfer Object) for API requests

    }
}
