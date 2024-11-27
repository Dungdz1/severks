using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.ApplicationService.ProductModule.Abstracts
{
    public interface ICategoryService
    {
        CategoryDto CreateCategory(CreateCategoryDto input);
        void UpdateCategory(UpdateCategoryDto input);
        void DeleteCategory(int id);
        List<CategoryDto> GetAllCategories();
        CategoryDto GetCategoryById(int id);
    }
}
