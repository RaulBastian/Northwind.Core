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
        private const string root = "Customers";

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await GetHttpCollectionResponse<Customer>(root);
            return customers;
        }

        public async Task<Customer> GetById(string id)
        {
            var customer = await GetHttpItemResponse<Customer>($"{root}('{id}'");
            return customer;
        }
    }
}
