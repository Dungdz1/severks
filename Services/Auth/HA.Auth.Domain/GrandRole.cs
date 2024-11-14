using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Domain
{
    public class GrandRole
    {
        public int RoleId { get; set; }
        public List<int> UserIdss { get; set; }
    }
}
