using Northwind.Core.ViewModels;
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

            this.Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await viewModel.Refresh();
        }
    }
}
