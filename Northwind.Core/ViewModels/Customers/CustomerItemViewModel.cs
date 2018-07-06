using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels.Customers
{
    public class CustomerItemViewModel : NorthwindItemViewModelBase<Customer>
    {
        private ICustomersService service;

       
        public CustomerItemViewModel(Customer customer) : this(customer, new HttpCustomersService())
        {

        }

        public CustomerItemViewModel(Customer customer, ICustomersService service) : base(customer, service)
        {
            this.service = service;
        }
    }
}
