using HA.Product.Dtos.ProductModule.Category;
using HA.Product.Dtos.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HA.Product.Dtos.ProductModule.Img;

namespace HA.Product.ApplicationService.ProductModule.Abstracts
{
    public interface IImageService
    {
        ImageDto AddNewImage(CreateImageDto input);
        void UpdateImage(UpdateImageDto input);
        void DeleteImage(int id);
        List<ImageDto> GetAllImages();
        ImageDto GetImageById(int id);
    }
}
