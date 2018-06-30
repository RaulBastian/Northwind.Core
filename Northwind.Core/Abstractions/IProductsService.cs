using Northwind.Core.DataObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Abstractions
{
    /// <summary>
    /// Products service interface
    /// </summary>
    public interface IProductsService: INorthwindServiceBase<Product>
    {

    }
}
