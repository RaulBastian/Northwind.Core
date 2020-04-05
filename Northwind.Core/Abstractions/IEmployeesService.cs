using Northwind.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Abstractions
{
    public interface IEmployeesService : INorthwindServiceBase<Employee>
    {
    }
}
