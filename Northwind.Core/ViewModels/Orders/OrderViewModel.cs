using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels.Orders
{
    public class OrderViewModel: NorthwindItemViewModelBase<Order> {

        private IOrdersService ordersService;

        public OrderViewModel(Order order) : this(order, new HttpOrdersService()) {

        }

        public OrderViewModel(Order order, IOrdersService ordersService) : base(order, ordersService) {
            this.ordersService = ordersService;
        }
    }
}
