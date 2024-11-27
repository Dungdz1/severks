using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.Dtos.ProductModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HA.WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public ProductCategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public IActionResult Create(CreateCategoryDto input)
        {
            var category = _categoryService.CreateCategory(input);
            return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto input)
        {
            _categoryService.UpdateCategory(input);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            return Ok(category);
        }
    }
}
