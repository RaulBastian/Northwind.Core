using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.ViewModels
{
    /// <summary>
    /// View models base class interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INorthwindViewModel<T> where T:class
    {
         Task<IEnumerable<T>> Refresh();
    }
}
