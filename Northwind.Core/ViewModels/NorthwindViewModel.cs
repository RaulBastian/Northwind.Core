using Northwind.Core.Abstractions;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.ViewModels
{
    /// <summary>
    /// Northwind view models base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NorthwindViewModelBase<T> : BindableBase, INorthwindViewModel<T> where T : class
    {
        private INorthwindServiceBase<T> service;
        private ObservableCollection<T> items = new ObservableCollection<T>();

        public NorthwindViewModelBase(INorthwindServiceBase<T> service)
        {
            this.service = service;
        }

        public ObservableCollection<T> Items {
            get {
                return items;
            }
            set { }
        }

        public async Task<IEnumerable<T>> Refresh()
        {
            var responseItems = await service.GetAll();

            items.Clear();

            foreach (var item in responseItems)
            {
                items.Add(item);
            }

            return responseItems;
        }
    }
}
