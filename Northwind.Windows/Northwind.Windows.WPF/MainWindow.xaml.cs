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
        private CustomerCollectionViewModel viewModel = null;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new CustomerCollectionViewModel();

            this.DataContext = viewModel;

            
        }

    }
}
