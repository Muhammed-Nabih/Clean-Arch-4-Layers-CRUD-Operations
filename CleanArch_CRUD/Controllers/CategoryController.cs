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
            try
            {
                var newCategory = await _categoryService.Add(request.Name, request.Description);
                return Ok(newCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                var categories = _categoryService.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryUpdateDTO)
        {
            try
            {
                await _categoryService.UpdateCategoryAsync(id, categoryUpdateDTO.Name, categoryUpdateDTO.Description);
                return Ok("Updated Succesfully");
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Not Found");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            try
            { 
                await _categoryService.RemoveCategoryAsync(id);
                return Ok($"The Category {id} Removed Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Not Found");
            }
        }
        // DTO (Data Transfer Object) for API requests

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);

                if (category == null)
                {
                    return NotFound($"Category Id {id} Not Exist");
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                // Log the exception and return an appropriate response
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
