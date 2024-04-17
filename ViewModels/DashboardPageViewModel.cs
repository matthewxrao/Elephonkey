using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Elephonkey.ViewModels
{
    public class DashboardPageViewModel
    {
        public ICommand LogoutCommand { get; }

        public DashboardPageViewModel()
        {
            LogoutCommand = new Command(PerformLogoutOperation);
        }

        private async void PerformLogoutOperation(object obj)
        {
            await Shell.Current.GoToAsync("//Login");

        }
    }
}
