using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.ViewModels.Orders
{
    public class OrderCollectionViewModel: NorthwindCollectionViewModelBase<Order> {

        private IOrdersService ordersService;
        private Customer customer;


        public OrderCollectionViewModel() : this(new HttpOrdersService()) {

        }

        public OrderCollectionViewModel(Customer customer) : this(new HttpOrdersService()) {
            this.customer = customer;
        }

        public OrderCollectionViewModel(IOrdersService service) : base(service) {
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
