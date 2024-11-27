using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Dtos.ProductModule
{
    public class CreateSaleDto
    {
        public string DiscountPersent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SaleDescriptioon { get; set; }
    }
}
