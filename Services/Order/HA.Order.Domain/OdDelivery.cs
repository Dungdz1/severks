using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Domain
{
    public class OdDelivery
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public int OrderId { get; set; }
    }
}
