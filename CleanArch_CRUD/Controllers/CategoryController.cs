using CleanArch_CRUD.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddCategory([FromBody] CategoryRequestDto request)
        {
            var newCategory = await _categoryService.AddCategory(request.Name, request.Description);
            return Ok(newCategory);
        }

        // DTO (Data Transfer Object) for API requests
        public class CategoryRequestDto
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
