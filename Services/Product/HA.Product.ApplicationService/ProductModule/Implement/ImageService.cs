using HA.Product.ApplicationService.Common;
using HA.Product.ApplicationService.ProductModule.Abstracts;
using HA.Product.Domain;
using HA.Product.Dtos.ProductModule;
using HA.Product.Dtos.ProductModule.Category;
using HA.Product.Dtos.ProductModule.Img;
using HA.Product.Infrastructure;
using HA.Shared.ApplicationService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.ApplicationService.ProductModule.Implement
{
    public class ImageService : ProductServiceBase, IImageService
    {
        private readonly ILogger<ImageService> _logger;
        private readonly BasethDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ImageService(ILogger<ImageService> logger, BasethDbContext dbContext, IConfiguration configuration) : base(logger, dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public ImageDto AddNewImage(CreateImageDto input)
        {
            var image = new ProdImage
            {
                ImageName = input.ImageName,
                ImageUrl = input.ImageUrl
            };

            _dbContext.Images.Add(image);
            _dbContext.SaveChanges();

            return new ImageDto
            {
                Id = image.Id,
                ImageName = image.ImageName,
                ImageUrl = image.ImageUrl
            };
        }

        public void DeleteImage(int id)
        {
            var image = _dbContext.Images.FirstOrDefault(c => c.Id == id);
            if (image == null)
                throw new KeyNotFoundException("Image not found");

            _dbContext.Images.Remove(image);
            _dbContext.SaveChanges();
        }

        public List<ImageDto> GetAllImages()
        {
            return _dbContext.Images.Select(c => new ImageDto
            {
                Id = c.Id,
                ImageName = c.ImageName,
                ImageUrl = c.ImageUrl
            }).ToList();
        }

        public ImageDto GetImageById(int id)
        {
            var image = _dbContext.Images.FirstOrDefault(c => c.Id == id);
            if (image == null)
                throw new KeyNotFoundException("Category not found");

            return new ImageDto
            {
                Id = image.Id,
                ImageName = image.ImageName,
                ImageUrl = image.ImageUrl,
            }; ;
        }

        public void UpdateImage(UpdateImageDto input)
        {
            var image = _dbContext.Images.FirstOrDefault(c => c.Id == input.Id);
            if (image == null)
                throw new KeyNotFoundException("Image not found");

            image.ImageName = input.ImageName;
            image.ImageUrl = input.ImageUrl;

            _dbContext.SaveChanges();
        }
    }
}