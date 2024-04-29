using Elephonkey.ViewModels;
using Microcharts;
using SkiaSharp;

namespace Elephonkey.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomePageViewModel();
	}
}