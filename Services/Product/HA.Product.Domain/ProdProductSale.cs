using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Domain
{
    public class ProdProductSale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }
    }
}
