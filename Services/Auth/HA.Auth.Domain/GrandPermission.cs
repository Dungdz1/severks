using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Domain
{
    public class GrandPermission
    {
        public int PermissionId { get; set; }
        public List<int> UserIds { get; set; }
    }
}
