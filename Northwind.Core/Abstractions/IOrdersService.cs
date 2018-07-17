using Northwind.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Abstractions
{
    public interface IOrdersService : INorthwindServiceBase<Order> {

        Task<IEnumerable<Order>> GetByCustomerId(string customerId);
    }
}
