using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.UserModule
{
    public class CreateSaleDto
    {
        public string SaleName { get; set; }
        public string Password { get; set; }
        public string SaleDes { get; set; }
    }
}
