using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.ViewModels.Employees
{
    public class EmployeeViewModel : NorthwindItemViewModelBase<Employee>
    {
        private IEmployeesService service;

        public EmployeeViewModel(Employee employee, bool isNew = false) : this(employee, new HttpEmployeesService(), isNew)
        {

        }

        public EmployeeViewModel(Employee employee, IEmployeesService service, bool isNew = false) : base(employee, service, isNew)
        {
            this.service = service;
        }


        public EmployeeViewModel ReportsTo { get; set; }
    }
}
