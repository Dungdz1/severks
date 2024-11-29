using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos.OrderDiscount
{
    public class AddDiscounttoOrder
    {
        public int DiscountId { get; set; }
        public List<int> OrderIds { get; set; }  
    }
}
