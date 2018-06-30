using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels
{
    /// <summary>
    /// Represents the customers view model
    /// </summary>
    public class CustomersViewModel: NorthwindViewModelBase<Customer>
    {
        private ICustomersService service;

        public CustomersViewModel(): this(new HttpCustomersService())
        {

        }

        public CustomersViewModel(ICustomersService service):base(service)
        {
            this.service = service;
        }
    }
}
