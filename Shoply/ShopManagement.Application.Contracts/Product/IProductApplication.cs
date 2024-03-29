﻿using _01_framwork.Applicatin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct command);
        OperationResult Edit(EditProduct command);
        OperationResult Remove(long id);
        OperationResult Activate(long id);
        EditProduct GetDetals(long id);
        List<ProductViewModel> Search(CategorySearchModel searchModel);
        public List<ProductViewModel> GetProducts();
    }
}
