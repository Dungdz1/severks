using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos
{
    public class UpdateOrderDto : CreateOrderDto
    {
        public int Id { get; set; }
    }
}
