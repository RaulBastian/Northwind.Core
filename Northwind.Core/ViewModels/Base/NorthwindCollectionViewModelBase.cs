using Northwind.Core.Abstractions;
using Northwind.Core.ViewModels.Base;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.ViewModels {
    /// <summary>
    /// Northwind view models base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NorthwindCollectionViewModelBase<T> : BindableBase, INorthwindCollectionViewModel<T> where T : class {
        private INorthwindServiceBase<T> service;
        private ObservableCollection<INorthwindItemViewModel<T>> items = new ObservableCollection<INorthwindItemViewModel<T>>();
        private T item = null;

        private DelegateCommand refreshCommand = null;

        public NorthwindCollectionViewModelBase(INorthwindServiceBase<T> service) {
            this.service = service;
        }

        public ObservableCollection<INorthwindItemViewModel<T>> Items {
            get {
                return items;
            }
            set { }
        }


        public DelegateCommand RefreshCommand {
            get {
                return refreshCommand ?? (refreshCommand = new DelegateCommand(
                    async () => {
                        Console.WriteLine("Refreshing...");
                        await Refresh();
                    },
                    () => {
                        return true;
                    }
                    ));
            }
        }


        public async Task<IEnumerable<T>> Refresh() {
            var responseItems = await service.GetAll();

            items.Clear();

            foreach (var item in responseItems) {
                INorthwindItemViewModel<T> vm = new NorthwindItemViewModelBase<T>(item, this.service);
                items.Add(vm);
            }

            return responseItems;
        }
    }
}
