using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.Admins
{
    public class AdminUser
    {
        public int AdminId { get; set; }
        public List<int> UserIds { get; set; }
    }
}
