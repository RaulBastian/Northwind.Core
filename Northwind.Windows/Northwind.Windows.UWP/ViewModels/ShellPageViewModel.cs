using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Northwind.Windows.UWP.ViewModels {
    public class ShellPageViewModel : BindableBase {


        private List<NavigationViewItem> navigationViewItem = new List<NavigationViewItem>(new NavigationViewItem[] 
        {
            new NavigationViewItem() {
                Content = "Customers",
                DataContext = "Customers"
            },
            new NavigationViewItem() {
                Content = "Products",
                DataContext = "Products"
            }
        });

        public ShellPageViewModel() {

        }

        public List<NavigationViewItem> NavigationViewItems {
            get {
                return navigationViewItem;
            }
        }

    }
}
