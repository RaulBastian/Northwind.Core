using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels.Products
{
    public class ProductViewModel : NorthwindItemViewModelBase<Product>
    {
        private IProductsService service;

        public ProductViewModel(Product product,bool isNew = false) : this(product, new HttpProductsService(), isNew)
        {

        }

        public ProductViewModel(Product product, IProductsService service, bool isNew = false) : base(product, service, isNew)
        {
            this.service = service;
        }
    }
}
