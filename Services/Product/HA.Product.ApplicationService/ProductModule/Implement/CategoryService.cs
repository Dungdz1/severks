using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.Domain;
using HA.Product.Dtos.ProductModule.Category;
using HA.Product.Dtos.ProductModule;
using HA.Product.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA.Product.ApplicationService.Common;
using HA.Shared.ApplicationService;

namespace HA.Product.ApplicationService.ProductModule.Implement
{
    public class CategoryService : ProductServiceBase, ICategoryService
    {
        private readonly ILogger<CategoryService> _logger;
        private readonly BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public CategoryService(ILogger<CategoryService> logger, BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public CategoryDto CreateCategory(CreateCategoryDto input)
        {
            var category = new ProdCategory
            {
                CategoryName = input.CategoryName,
                CategoryDescription = input.CategoryDescription
            };

            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription
            };
        }

        public void DeleteCategory(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                throw new KeyNotFoundException("Category not found");

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _dbContext.Categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                CategoryName = c.CategoryName,
                CategoryDescription = c.CategoryDescription
            }).ToList();
        }

        public CategoryDto GetCategoryById(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
                throw new KeyNotFoundException("Category not found");

            return new CategoryDto
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                CategoryDescription = category.CategoryDescription,
            };
        }

        public void UpdateCategory(UpdateCategoryDto input)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == input.Id);
            if (category == null)
                throw new KeyNotFoundException("Category not found");

            category.CategoryName = input.CategoryName;
            category.CategoryDescription = input.CategoryDescription;

            _dbContext.SaveChanges();
        }
    }
}
