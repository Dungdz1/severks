using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Auth.Dtos.Sale
{
    public class SaleUser
    {
        public int SaleId { get; set; }
        public List<int> UserIds { get; set; }
    }
}
