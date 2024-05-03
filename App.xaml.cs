using Elephonkey.Models;
using Elephonkey.Service;
using Elephonkey.Views;

namespace Elephonkey
{
    public partial class App : Application
    {
        public App()
        {
            
            InitializeComponent();
            
            MainPage = new AppShell();
        }
    }
}