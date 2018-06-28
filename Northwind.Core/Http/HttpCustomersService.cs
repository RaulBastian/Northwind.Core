using Newtonsoft.Json;
using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Http
{
    public class HttpCustomersService : HttpNorthwindClientBase, ICustomersService
    {
        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await GetHttpTypedResponse<Customer>("Customers");
            return customers;
        }
    }
}
