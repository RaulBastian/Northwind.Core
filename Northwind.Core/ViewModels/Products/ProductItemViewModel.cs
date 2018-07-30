using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels.Products
{
    public class ProductItemViewModel : NorthwindItemViewModelBase<Product>
    {
        private IProductsService service;

        public ProductItemViewModel(Product product,bool isNew = false) : this(product, new HttpProductsService(), isNew)
        {

        }

        public ProductItemViewModel(Product product, IProductsService service, bool isNew = false) : base(product, service, isNew)
        {
            this.service = service;
        }
    }
}
