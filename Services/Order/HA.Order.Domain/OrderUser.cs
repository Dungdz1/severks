using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Domain
{
    public class OrderUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OrderId {  get; set; }
    }
}
