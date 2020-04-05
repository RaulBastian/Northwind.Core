using Northwind.Core.Abstractions;
using Northwind.Core.DataObjects;
using Northwind.Core.Http;
using Northwind.Core.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Core.ViewModels.Employees
{
    public class EmployeeCollectionViewModel : NorthwindCollectionViewModelBase<Employee>
    {
        private IEmployeesService service;

        public EmployeeCollectionViewModel() : this(new HttpEmployeesService())
        {

        }

        public EmployeeCollectionViewModel(IEmployeesService service) : base(service)
        {
            this.service = service;
        }

        protected override NorthwindItemViewModelBase<Employee> GetNorthwindItemViewModel(Employee item, INorthwindServiceBase<Employee> service, bool isNew = false)
        {
            return new EmployeeViewModel(item);
        }

        protected override void OnAfterRefresh(IEnumerable<INorthwindItemViewModel<Employee>> items)
        {
            var employees_who_report_to_somebody = items.OfType<EmployeeViewModel>().Where(i => i.DataObject.ReportsTo.HasValue).ToArray();

            foreach (var e in employees_who_report_to_somebody)
            {
                var parent = items.OfType<EmployeeViewModel>().Where(i => i.DataObject.EmployeeID == e.DataObject.ReportsTo.Value).FirstOrDefault();

                //We add it to the parent's children collection
                parent.Children.Add(e);

                //We set the parent on this item
                e.ReportsTo = parent;
            }
        }
    }
}
