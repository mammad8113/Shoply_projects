﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Order
{
    public class OrderItemViewModel
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public double UnitPrice { get; set; }
        public int Count { get; set; }
        public int DiscountRate { get; set; }
        public double PriceWithdiscount { get; set; }
        public long OrderId { get; set; }
        public string CreationDate { get; set; }
    }
}
