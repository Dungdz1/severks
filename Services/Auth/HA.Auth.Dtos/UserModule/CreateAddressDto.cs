using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.UserModule
{
    public class CreateAddressDto
    {
        public string FullAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
