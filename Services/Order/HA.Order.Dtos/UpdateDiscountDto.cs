using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos
{
    public class UpdateDiscountDto : CreateDiscountDto
    {
        public int Id { get; set; }
    }
}
