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
        private ObservableCollection<INorthwindItemViewModel<T>> items = null;
        private T item = null;

        private DelegateCommand refreshCommand = null;

        public NorthwindCollectionViewModelBase(INorthwindServiceBase<T> service) {
            this.service = service;
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

        public ObservableCollection<INorthwindItemViewModel<T>> Items {
            get {
                if(items ==  null) {
                    items = new ObservableCollection<INorthwindItemViewModel<T>>();
                    RefreshCommand.Execute();
                }

                return items;
            }
        }

        private async Task Refresh() {
            var responseItems = await GetCollection();

            items.Clear();

            foreach (var item in responseItems) {
                INorthwindItemViewModel<T> vm = GetNorthwindItemViewModel(item, this.service);
                items.Add(vm);
            }
        }

        protected virtual async Task<IEnumerable<T>> GetCollection() {
            return await service.GetAll();
        }

        protected virtual NorthwindItemViewModelBase<T> GetNorthwindItemViewModel(T item, INorthwindServiceBase<T> service) {
            return new NorthwindItemViewModelBase<T>(item, this.service);
        }
    }
}
