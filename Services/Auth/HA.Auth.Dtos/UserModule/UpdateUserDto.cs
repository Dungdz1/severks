using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.UserModule
{
    public class UpdateUserDto : CreateUserDto
    {
        public int Id { get; set; }
    }
}
