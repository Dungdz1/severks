using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Dtos.ProductModule.Category
{
    public class ProductCategory
    {
        public int CategoryId { get; set; }
        List<int> ProductIds { get; set; } 
    }
}
