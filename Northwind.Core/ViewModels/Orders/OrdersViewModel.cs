using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.ViewModels.Orders
{
    public class OrdersViewModel: NorthwindCollectionViewModelBase<Order> {

        private IOrdersService ordersService;
        private Customer customer;


        public OrdersViewModel() : this(new HttpOrdersService()) {

        }

        public OrdersViewModel(Customer customer) : this(new HttpOrdersService()) {
            this.customer = customer;
        }

        public OrdersViewModel(IOrdersService service) : base(service) {
            this.ordersService = service;
        }

        protected override async Task<IEnumerable<Order>> GetCollection() { 
            if(customer != null) {
                return await this.ordersService.GetByCustomerId(this.customer.CustomerID);
            }
            else {
                return await base.GetCollection();
            }
        }

        protected override NorthwindItemViewModelBase<Order> GetNorthwindItemViewModel(Order item, INorthwindServiceBase<Order> service, bool isNew = false) {
            return new OrderViewModel(item, this.ordersService);
        }
    }
}
