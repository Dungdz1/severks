using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Dtos.ProductModule.Img
{
    public class ProductImage
    {
        public int ProductId { get; set; }
        public List<int> ImageIds { get; set; }
    }
}
