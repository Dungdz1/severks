using HA.Product.ApplicationService.Common;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.Domain;
using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Brand;
using HA.Product.Dtos.ProductModule.Category;
using HA.Product.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.ApplicationService.ProductModule.Implement
{
    public class BrandService : ProductServiceBase, IBrandService
    {
        private readonly ILogger<BrandService> _logger;
        private readonly ProductDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public BrandService(ILogger<BrandService> logger, ProductDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public BrandDto CreatenewBrand(CreateBrandDto input)
        {
            var brand = new ProdBrand
            {
                BrandName = input.BrandName,
                BrandImg = input.BrandImg,
                BrandDescription = input.BrandDescription,
            };
            _dbContext.Brands.Add(brand);
            _dbContext.SaveChanges();
            return new BrandDto 
            {
                Id = brand.Id,
                BrandName = brand.BrandName,
                BrandImg = brand.BrandImg,
                BrandDescription = brand.BrandDescription
            };
        }

        public void DeleteBrand(int id)
        {
            var brand = _dbContext.Brands.FirstOrDefault(c => c.Id == id);
            if (brand == null)
                throw new KeyNotFoundException("Category not found");

            _dbContext.Brands.Remove(brand);
            _dbContext.SaveChanges();
        }

        public List<BrandDto> GetAllBrand()
        { 
            return _dbContext.Brands.Select(c => new BrandDto
            {
                Id = c.Id,
                BrandName = c.BrandName,
                BrandImg = c.BrandImg,
                BrandDescription = c.BrandDescription,
            }).ToList();
        }

        public BrandDto GetBrandById(int id)
        {
            var brand = _dbContext.Brands.FirstOrDefault(c => c.Id == id);
            if (brand == null)
                throw new KeyNotFoundException("Category not found");

            return new BrandDto
            {
                Id = brand.Id,
                BrandName = brand.BrandName,
                BrandImg = brand.BrandImg,
                BrandDescription = brand.BrandDescription,
            };
        }

        public void UpdateBrand(UpdateBrandDto input)
        {
            var brand = _dbContext.Brands.FirstOrDefault(c => c.Id == input.Id);
            if (brand == null)
                throw new KeyNotFoundException("Category not found");

            brand.BrandName = input.BrandName;
            brand.BrandImg = input.BrandImg;
            brand.BrandDescription = input.BrandDescription;

            _dbContext.SaveChanges();
        }
    }
}
