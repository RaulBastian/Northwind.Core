using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Abstractions
{
    public interface INorthwindServiceBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
