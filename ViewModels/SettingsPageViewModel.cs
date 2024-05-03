using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Elephonkey.ViewModels
{
    public partial class SettingsPageViewModel
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

        [RelayCommand]
        public static void Settings()
        {
            // Navigate to the ResultsPage
            Shell.Current.GoToAsync(state: "//Settings");
        }
    }
}
