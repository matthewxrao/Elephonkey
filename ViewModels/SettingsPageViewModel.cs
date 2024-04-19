using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Elephonkey.ViewModels
{
    public class SettingsPageViewModel
    {
        public ICommand LogoutCommand { get; }

        public SettingsPageViewModel()
        {
            LogoutCommand = new Command(PerformLogoutOperation);
        }

        private async void PerformLogoutOperation(object obj)
        {
            Preferences.Clear();
            await Shell.Current.GoToAsync("//Login");
        }
    }
}
