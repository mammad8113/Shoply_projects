﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Order
{
    public interface ICityServices
    {
        List<Cities> Get();
        void Set(List<Cities> cities);
    }
}
