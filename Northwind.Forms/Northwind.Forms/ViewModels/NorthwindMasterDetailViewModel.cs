using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Northwind.Forms.ViewModels
{
	public class NorthwindMasterDetailViewModel : BindableBase
	{
        private DelegateCommand<SelectedItemChangedEventArgs> navigateCommand = null;
        private INavigationService navigationService = null;
        private ObservableCollection<string> menuItems = null;


        public NorthwindMasterDetailViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            this.MenuItems = new ObservableCollection<string>(new string[] { "Customers","Products" });
            
        }

        public ObservableCollection<string> MenuItems {
            get
            {
                return menuItems;
            }
            set
            {
                this.menuItems = value;
            }
        }


        public DelegateCommand<SelectedItemChangedEventArgs> NavigateCommand {
            get {
                return navigateCommand ?? (navigateCommand = new DelegateCommand<SelectedItemChangedEventArgs>(async (parameter) => {
                    await navigationService.NavigateAsync(parameter.SelectedItem.ToString());
                }));
            }
        }

        
	}
}
