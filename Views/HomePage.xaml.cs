using Elephonkey.ViewModels;
using Microcharts;
using SkiaSharp;

namespace Elephonkey.Views;

public partial class HomePage : ContentPage
{

    ChartEntry[] entries = new[]
    {
        new ChartEntry(40)
        {
            Label = "Republican",
            Color = SKColor.Parse("#d8311f")
        },
        new ChartEntry(10)
        {
            Label = "Democratic",
            Color = SKColor.Parse("#073e7e")
        },
        new ChartEntry(5)
        {
            Label = "Green",
            Color = SKColor.Parse("#7ed956")
        },
        new ChartEntry(2)
        {
            Label = "Libertarian",
            Color = SKColor.Parse("#ff7f1a")
        },
        new ChartEntry(1)
        {
            Label = "Other",
            Color = SKColor.Parse("#b34bc4")
        }
    };

    public HomePage()
	{
		InitializeComponent();
		BindingContext = new HomePageViewModel();

        chartView.Chart = new DonutChart
        {
            Entries = entries, LabelMode = LabelMode.None
        };
	}
}