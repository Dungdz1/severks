using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos.Detail
{
    public class DetailDto
    {
        public int OrderId { get; set; }
        public List<int> ProductIds { get; set; }
        public List<int> Quantitys { get; set; } 
    }
}
