using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Domain
{
    public class AuthAddress
    {
        public int Id { get; set; }
        public string FullAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
