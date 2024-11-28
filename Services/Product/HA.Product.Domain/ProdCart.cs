using HA.Auth.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Domain
{
    public class ProdCart
    {
        public int Id { get; set; }
        public int ProductId { get; set;}
        public int UserId { get; set; }
        public int Quantity { get; set; }
    }
}
