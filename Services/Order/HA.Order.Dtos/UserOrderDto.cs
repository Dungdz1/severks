using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos
{
    public class UserOrderDto
    {
        
        public int UsertId { get; set; }
        public List<int> OrderIds { get; set; }
    }
}
