using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos
{
    public class CreateDiscountDto
    {
        public string CodeDiscount { get; set; }
        public int DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DiscountDescription { get; set; }
        public string Status { get; set; }
    }
}
