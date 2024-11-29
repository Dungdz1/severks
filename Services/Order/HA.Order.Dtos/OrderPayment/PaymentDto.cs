﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Order.Dtos.OrderPayment
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string PaymentMethod { get; set; }
        public string Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Status { get; set; }
        public string TransactionCode { get; set; }
    }
}