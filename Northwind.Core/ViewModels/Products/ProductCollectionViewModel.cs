using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using Northwind.Core.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels.Products
{
    /// <summary>
    /// Represents the products view model
    /// </summary>
    public class ProductCollectionViewModel : NorthwindCollectionViewModelBase<Product>
    {
        private IProductsService service;

        public ProductCollectionViewModel() : this(new HttpProductsService())
        {

        }

        public ProductCollectionViewModel(IProductsService service) : base(service)
        {
            this.service = service;
        }

        protected override NorthwindItemViewModelBase<Product> GetNorthwindItemViewModel(Product item, INorthwindServiceBase<Product> service,bool isNew = false) {
            return new ProductViewModel(item);
        }
    }
}
