using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Domain
{
    public class AuthPermissions
    {
        public int Id { get; set; }
        public string PermissionName { get; set; }
        public string PermissionDescription { get; set; }
    }
}
