using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Dtos.ProductModule
{
    public class UpdateProductDto : CreateProductDto
    {
        public int Id { get; set; }
    }
}
