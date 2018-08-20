using Northwind.Core.ViewModels;
using Northwind.Core.ViewModels.Customers;
using System.Windows;

namespace Northwind.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomersViewModel viewModel = null;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new CustomersViewModel();

            this.DataContext = viewModel;

            
        }

    }
}
