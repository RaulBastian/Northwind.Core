using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Http
{
    public class HttpOrdersService : HttpNorthwindClientBase, IOrdersService {

        private const string root = "Orders";

        public async Task<IEnumerable<Order>> GetAll() {
            var orders = await GetHttpCollectionResponse<Order>(root);
            return orders;
        }

        public async Task<IEnumerable<Order>> GetByCustomerId(string customerId) {

            //http://services.odata.org/V4/Northwind/Northwind.svc/Orders?$filter=CustomerId%20eq%20'ALFKI'

            var orders = await GetHttpCollectionResponse<Order>($"{root}?$filter=CustomerID%20eq%20'{customerId}'");
            return orders;
        }

        public async Task<Order> GetById(string id) {
            var order = await GetHttpItemResponse<Order>($"{root}('{id}'");
            return order;
        }
        
    }
}
