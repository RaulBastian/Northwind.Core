using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using Northwind.Core.ViewModels.Orders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.ViewModels.Customers {
    public class CustomerViewModel : NorthwindItemViewModelBase<Customer> {

        private OrdersViewModel orders = null;

        private ICustomersService customerService;
        private IOrdersService ordersService;

        public CustomerViewModel(Customer customer) : this(customer, new HttpOrdersService(), new HttpCustomersService()) {

        }

        public CustomerViewModel(Customer customer, IOrdersService ordersService, ICustomersService service) : base(customer, service) {
            this.ordersService = ordersService;
            this.customerService = service;
        }


        public OrdersViewModel Orders {
            get {
                if (orders == null) {
                    orders = new OrdersViewModel(this.DataObject);
                }
                return orders;
            }
        }


        

    }
}
