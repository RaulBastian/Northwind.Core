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
        private const string root = "Products";

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await GetHttpCollectionResponse<Product>("Products");
            return products;
        }

        public async Task<Product> GetById(string id)
        {
            var product = await GetHttpItemResponse<Product>($"{root}('{id}'");
            return product;
        }
    }
}
