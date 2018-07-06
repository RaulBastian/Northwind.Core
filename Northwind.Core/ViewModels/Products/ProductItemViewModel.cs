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

        public ProductItemViewModel(Product product) : this(product, new HttpProductsService())
        {

        }

        public ProductItemViewModel(Product product, IProductsService service) : base(product, service)
        {
            this.service = service;
        }
    }
}
