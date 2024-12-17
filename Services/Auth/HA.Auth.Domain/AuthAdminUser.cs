using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Domain
{
    public class AuthAdminUser
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int UserId { get; set; }
    }
}
