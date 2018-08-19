using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Northwind.Forms.ViewModels
{
	public class NorthwindMasterDetailViewModel : BindableBase
	{
        private DelegateCommand<string> navigateCommand = null;
        private INavigationService navigationService = null;

        public NorthwindMasterDetailViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public DelegateCommand<string> NavigateCommand {
            get {
                return navigateCommand ?? (navigateCommand = new DelegateCommand<string>(async (parameter) => {
                    await navigationService.NavigateAsync(parameter);
                }));
            }
        }

        
	}
}
