﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Product.Domain
{
    public class ProdSale
    {
        public int Id { get; set; }
        public string DiscountPersent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string SaleDescriptioon { get; set; }
    }
}
