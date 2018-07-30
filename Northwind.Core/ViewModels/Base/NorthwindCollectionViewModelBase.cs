using Northwind.Core.Abstractions;
using Northwind.Core.ViewModels.Base;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Northwind.Core.ViewModels {
    /// <summary>
    /// Northwind view models base class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NorthwindCollectionViewModelBase<T> : BindableBase, INorthwindCollectionViewModel<T> where T : class, new() {
        private INorthwindServiceBase<T> service;
        private ObservableCollection<INorthwindItemViewModel<T>> items = null;
        private T item = null;

        private DelegateCommand refreshCommand = null;
        private DelegateCommand newCommand = null;

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

        public DelegateCommand NewCommand {
            get {
                return newCommand ?? (newCommand = new DelegateCommand(
                    async () => {
                        Console.WriteLine("Creating...");
                        await CreateNew();
                    },
                    () => {
                        return true;
                    }
                    ));
            }
        }

        /// <summary>
        /// View model elements of the collection, this is read-only so bindings must be one way
        /// </summary>
        public ObservableCollection<INorthwindItemViewModel<T>> Items {
            get {
                if(items ==  null) {
                    items = new ObservableCollection<INorthwindItemViewModel<T>>();
                    RefreshCommand.Execute();
                }

                return items;
            }
        }

        /// <summary>
        /// Creates a new item
        /// </summary>
        /// <returns></returns>
        private async Task CreateNew() {
            await Task.Factory.StartNew(() => {

                //If there aren't any new items we add one.
                if(!items.Where(i=>i.IsNew).Any()) {
                    T item = new T();
                    INorthwindItemViewModel<T> vm = GetNorthwindItemViewModel(item, this.service, true);
                    items.Add(vm);
                }
            });
        }
       
        /// <summary>
        /// Refreshes the items collection
        /// </summary>
        /// <returns></returns>
        private async Task Refresh() {
            var responseItems = await GetCollection();

            items.Clear();

            foreach (var item in responseItems) {
                INorthwindItemViewModel<T> vm = GetNorthwindItemViewModel(item, this.service);
                items.Add(vm);
            }
        }

        /// <summary>
        /// Gets all northwind entities collection, override if the collection needs to be filtered 
        /// </summary>
        /// <returns></returns>
        protected virtual async Task<IEnumerable<T>> GetCollection() {
            return await service.GetAll();
        }

        /// <summary>
        /// Instantiates a northwind item view model, override to provide a specific implementation
        /// </summary>
        /// <param name="item"></param>
        /// <param name="service"></param>
        /// <param name="isNew"></param>
        /// <returns></returns>
        protected virtual NorthwindItemViewModelBase<T> GetNorthwindItemViewModel(T item, INorthwindServiceBase<T> service,bool isNew = false) {
            return new NorthwindItemViewModelBase<T>(item, this.service,isNew:isNew);
        }
    }
}
