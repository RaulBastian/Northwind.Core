using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Abstractions
{

    /// <summary>
    /// Northwind service base interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INorthwindServiceBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(string id);
    }
}
