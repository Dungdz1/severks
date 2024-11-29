using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Domain
{
    public class OdOrderPayment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int PaymentId { get; set; }
    }
}
