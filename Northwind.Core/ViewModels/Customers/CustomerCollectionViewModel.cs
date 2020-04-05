using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using Northwind.Core.ViewModels.Customers;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels.Customers {
    /// <summary>
    /// Represents the customers view model
    /// </summary>
    public class CustomerCollectionViewModel: NorthwindCollectionViewModelBase<Customer>
    {
        private ICustomersService service;

        public CustomerCollectionViewModel(): this(new HttpCustomersService())
        {

        }

        public CustomerCollectionViewModel(ICustomersService service):base(service)
        {
            this.service = service;
        }

        protected override NorthwindItemViewModelBase<Customer> GetNorthwindItemViewModel(Customer item, INorthwindServiceBase<Customer> service, bool isNew = false) {
            return new CustomerViewModel(item);
        }
    }
}
