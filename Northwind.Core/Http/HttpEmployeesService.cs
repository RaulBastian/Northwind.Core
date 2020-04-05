using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Http
{
    public class HttpEmployeesService : HttpNorthwindClientBase, IEmployeesService
    {
        private const string root = "Employees";

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var employee = await GetHttpCollectionResponse<Employee>(root);
            return employee;
        }

        public async Task<Employee> GetById(string id)
        {
            var employee = await GetHttpItemResponse<Employee>($"{root}('{id}'");
            return employee;
        }
    }
}
