using Prism;
using Prism.Ioc;
using Northwind.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using Northwind.Core.ViewModels;
using Northwind.Core.Abstractions;
using Northwind.Core.Http;
using Northwind.Forms.ViewModels;
using Northwind.Core.ViewModels.Customers;
using Northwind.Core.ViewModels.Products;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Northwind.Forms {
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { Configure(); }

        public App(IPlatformInitializer initializer) : base(initializer) { Configure(); }


        private void Configure() {
            // Initialize Live Reload.
#if DEBUG
            LiveReload.Init();
#endif

        }

        protected override void OnStart() {
            base.OnStart();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("Index/Navigation/Customers");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NorthwindMasterDetail, NorthwindMasterDetailViewModel>("Index");
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");

            containerRegistry.RegisterInstance<ICustomersService>(new HttpCustomersService());
            containerRegistry.RegisterInstance<IProductsService>(new HttpProductsService());

            containerRegistry.RegisterForNavigation<Customers, CustomersViewModel>("Customers");
            containerRegistry.RegisterForNavigation<Products,ProductsViewModel>("Products");
        }
    }
}
