using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using Northwind.Core.ViewModels.Customers;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels
{
    /// <summary>
    /// Represents the customers view model
    /// </summary>
    public class CustomersCollectionViewModel: NorthwindCollectionViewModelBase<Customer>
    {
        private ICustomersService service;

        public CustomersCollectionViewModel(): this(new HttpCustomersService())
        {

        }

        public CustomersCollectionViewModel(ICustomersService service):base(service)
        {
            this.service = service;
        }

        protected override NorthwindItemViewModelBase<Customer> GetNorthwindItemViewModel(Customer item, INorthwindServiceBase<Customer> service) {
            return new CustomerItemViewModel(item);
        }
    }
}
