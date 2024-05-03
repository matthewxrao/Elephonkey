using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephonkey.ViewModels
{
    public partial class ArticlesViewModel
    {
        [RelayCommand]
        public static void Settings()
        {
            // Navigate to the ResultsPage
            Shell.Current.GoToAsync(state: "//Settings");
        }
    }
}
