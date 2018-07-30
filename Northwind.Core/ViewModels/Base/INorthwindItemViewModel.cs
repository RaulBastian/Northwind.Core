using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.ViewModels.Base
{
    public interface INorthwindItemViewModel<T> where T : class
    {
        bool IsNew { get; }

         T DataObject { get; }

        DelegateCommand DeleteCommand { get; }

        DelegateCommand RefreshCommand { get; }

        DelegateCommand SaveCommand { get; }

    }
}
