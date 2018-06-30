using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Http
{
    public class HttpProductsService : HttpNorthwindClientBase, IProductsService
    {
        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await GetHttpTypedResponse<Product>("Products");
            return products;
        }
    }
}
