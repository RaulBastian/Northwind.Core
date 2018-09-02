using Northwind.Core.Abstractions;
using Northwind.Core.Http;
using Northwind.Core.ViewModels.Customers;
using Northwind.Core.ViewModels.Products;
using Northwind.Windows.UWP.Views;
using Prism.Mvvm;
using Prism.Unity.Windows;
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Unity;

namespace Northwind.Windows.UWP {
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : PrismUnityApplication {

        private ShellPage shell = null;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App() {
            this.InitializeComponent();

            shell = new ShellPage();
        }

        protected override UIElement CreateShell(Frame rootFrame) {
            return shell;
        }

        protected override async Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args) {
            NavigationService.Navigate("Customers",args.Arguments);
            await Task.CompletedTask;
        }

        protected override Frame OnCreateRootFrame() {
            return shell.FindName("rootFrame") as Frame;
        }

        protected override Task OnInitializeAsync(IActivatedEventArgs args) {

            Container.RegisterInstance<ICustomersService>(new HttpCustomersService());
            Container.RegisterInstance<IProductsService>(new HttpProductsService());

            ViewModelLocationProvider.Register<CustomersPage, CustomersViewModel>();
            ViewModelLocationProvider.Register<ProductsPage, ProductsViewModel>();

            return base.OnInitializeAsync(args);
        }

    }
}
