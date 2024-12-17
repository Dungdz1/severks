using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.UserModule
{
    public class CreateAdminDto
    {
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
    }
}
