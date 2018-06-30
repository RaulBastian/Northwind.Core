using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels
{
    /// <summary>
    /// Represents the products view model
    /// </summary>
    public class ProductsViewModel : NorthwindViewModelBase<Product>
    {
        private IProductsService service;

        public ProductsViewModel() : this(new HttpProductsService())
        {

        }

        public ProductsViewModel(IProductsService service) : base(service)
        {
            this.service = service;
        }
    }
}
