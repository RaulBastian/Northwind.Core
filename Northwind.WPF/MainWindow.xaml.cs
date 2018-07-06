using Northwind.Core.ViewModels;
using System.Windows;

namespace Northwind.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CustomersCollectionViewModel viewModel = null;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new CustomersCollectionViewModel();

            this.DataContext = viewModel;

            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await viewModel.Refresh();
        }
    }
}
