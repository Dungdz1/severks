using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos.ProductOrder
{
    public class AddProducttoOrder
    {
        public int OrderId { get; set; }
        public List<int> ProductIds { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
