using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Dtos.ProductModule
{
    public class CreateProductDto
    {
        private string _prodname;
        public string ProductName
        {
            get => _prodname;
            set => _prodname = value;
        }

        private decimal _prodprice;
        public decimal ProdPrice
        {
            get => _prodprice;
            set => _prodprice = value;
        }

        private string _prodimg;
        public string ProdImg
        {
            get => _prodimg;
            set => _prodimg = value;
        }

        private string _proddescription;
        public string ProdDescription
        {
            get => _proddescription;
            set => _proddescription=value;
        }

        private string _prodstock;
        public string ProdStock
        {
            get => _prodstock; 
            set => _prodstock = value;
        }
    }
}
