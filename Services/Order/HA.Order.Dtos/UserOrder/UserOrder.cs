using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos.UserOrder
{
    public class UserOrder
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderIds { get; set; }
    }
}
