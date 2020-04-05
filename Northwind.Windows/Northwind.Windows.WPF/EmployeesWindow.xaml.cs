using Northwind.Core.ViewModels.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Northwind.Windows.WPF
{
    /// <summary>
    /// Interaction logic for EmployeesWindow.xaml
    /// </summary>
    public partial class EmployeesWindow : Window
    {
        private EmployeeCollectionViewModel viewModel = null;

        public EmployeesWindow()
        {
            InitializeComponent();

            viewModel = new EmployeeCollectionViewModel();

            this.DataContext = viewModel;
        }
    }
}
