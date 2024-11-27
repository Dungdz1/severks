using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Dtos.ProductModule.Sale
{
    public class ProductSale
    {
        public int SaleId { get; set; }
        public List<int> ProductIds { get; set; }
    }
}
