using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.Address
{
    public class AddressUser
    {
        public int UserId { get; set; }
        public List<int> AddressIds { get; set; }
    }
}
