using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels.Orders
{
    public class OrderItemViewModel: NorthwindItemViewModelBase<Order> {

        private IOrdersService ordersService;

        public OrderItemViewModel(Order order) : this(order, new HttpOrdersService()) {

        }

        public OrderItemViewModel(Order order, IOrdersService ordersService) : base(order, ordersService) {
            this.ordersService = ordersService;
        }
    }
}
