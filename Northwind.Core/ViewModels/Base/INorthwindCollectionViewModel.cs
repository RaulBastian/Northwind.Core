using Northwind.Core.ViewModels.Base;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.ViewModels
{
    /// <summary>
    /// View models base class interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface INorthwindCollectionViewModel<T> where T : class
    {
        ObservableCollection<INorthwindItemViewModel<T>> Items { get; }

        DelegateCommand RefreshCommand { get; }

        DelegateCommand NewCommand { get; }
    }
}
