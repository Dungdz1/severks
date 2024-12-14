using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.Customer
{
    public class CustomerUser
    {
        public int CustomerId { get; set; }
        public List<int> UserIds { get; set; }
    }
}
