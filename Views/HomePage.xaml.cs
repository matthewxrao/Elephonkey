using Elephonkey.Service;
using Elephonkey.ViewModels;
using Microcharts;
using SkiaSharp;


namespace Elephonkey.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage(INewsService news)
        {
            InitializeComponent();
            this.BindingContext = new HomePageViewModel(news);
        }
    }
}







