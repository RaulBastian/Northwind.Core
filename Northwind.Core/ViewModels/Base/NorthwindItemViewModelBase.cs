using Northwind.Core.Abstractions;
using Northwind.Core.ViewModels.Base;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.ViewModels {
    public class NorthwindItemViewModelBase<T> : BindableBase, INorthwindItemViewModel<T> where T : class {
        private T item = null;
        private INorthwindServiceBase<T> service;

        private DelegateCommand deleteCommand;
        private DelegateCommand saveCommand;
        private DelegateCommand refreshCommand;

        public NorthwindItemViewModelBase(T item, INorthwindServiceBase<T> service) {
            this.service = service;
            this.item = item;
        }

        public T Item {
            get {
                return item;
            }
        }

        public DelegateCommand DeleteCommand {
            get {
                return deleteCommand ?? (deleteCommand = new DelegateCommand(
                   async () => {
                       Console.WriteLine("Deleting...");
                       await Task.Delay(1000);
                   },
                   () => {
                       return true;
                   }
              ));
            }
        }

        public DelegateCommand SaveCommand {
            get {
                return saveCommand ?? (saveCommand = new DelegateCommand(
                   async () => {
                       Console.WriteLine("Saving...");
                       await Task.Delay(1000);
                   },
                   () => {
                       return true;
                   }
              ));
            }
        }

        public DelegateCommand RefreshCommand {
            get {
                return refreshCommand ?? (refreshCommand = new DelegateCommand(
                   async () => {
                       Console.WriteLine("Refreshing...");
                       await Task.Delay(1000);
                   },
                   () => {
                       return true;
                   }
              ));
            }
        }


        public Task<T> GetById(string id) {
            throw new NotImplementedException();
        }
    }
}
