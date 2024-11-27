using HA.Product.Dtos.ProductModule.Category;
using HA.Product.Dtos.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA.Product.Dtos.ProductModule.Brand;

namespace HA.Product.ApplicationService.ProductModule.Abstracts
{
    public interface IBrandService
    {
        BrandDto CreatenewBrand(CreateBrandDto input);
        void UpdateBrand(UpdateBrandDto input);
        void DeleteBrand(int id);
        List<BrandDto> GetAllBrand();
        BrandDto GetBrandById(int id);
    }
}
