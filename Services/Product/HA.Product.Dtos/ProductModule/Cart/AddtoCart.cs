using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Dtos.ProductModule.Cart
{
    public class AddtoCart
    {
        public int CustomerId { get; set; }
        public List<int> ProductIds { get; set; }
        public int Quantity { get; set;}
    }
}
