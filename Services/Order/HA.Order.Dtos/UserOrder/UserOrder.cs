using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos.UserOrder
{
    public class UserOrder
    {
        public int UserId { get; set; }
        public List<int> OrderIds { get; set; }
    }
}
