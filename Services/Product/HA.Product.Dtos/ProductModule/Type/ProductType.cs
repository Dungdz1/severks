using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Dtos.ProductModule.Type
{
    public class ProductType
    {
        public int TypeId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
