using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos.OrderDiscount
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string CodeDiscount { get; set; }
        public int DiscountValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DiscountDescription { get; set; }
        public string Status { get; set; }
    }
}
