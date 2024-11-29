using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos.OrderPayment
{
    public class AddPaymentDto
    {
        public int PaymentId { get; set; }
        public List<int> OrderIds { get; set; }
    }
}
