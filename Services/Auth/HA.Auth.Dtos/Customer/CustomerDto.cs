using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Password { get; set; }
    }
}
