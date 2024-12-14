using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.UserModule
{
    public class CreateCustomerDto
    {
        public string CustomerName { get; set; }
        public string Password { get; set; }
    }
}
