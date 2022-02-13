﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public class ProductPictureViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; }
        public bool IsRemoved { get; set; }
        public string Product { get; set; }
        public long ProductId { get; set; }
        public string CreationDate { get; set; }
    }
}
