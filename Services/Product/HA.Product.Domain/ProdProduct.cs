using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Domain
{
    public class ProdProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProdPrice { get; set; }
        public string ProdImg { get; set; }
        public string ProdDescription { get; set; }
        public string ProdStock { get; set; }
        public bool IsDelete { get; set; }
    }
}
