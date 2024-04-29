using Elephonkey.Service;
using Elephonkey.ViewModels;
using Microcharts;
using Microcharts.Maui;
using SkiaSharp;

namespace Elephonkey.Views;

public partial class ResultsPage : ContentPage
{
    private ResultsPageViewModel _viewModel;

    public ResultsPage()
    {
        InitializeComponent();
        _viewModel = new ResultsPageViewModel();
        BindingContext = _viewModel;
        RecreateChart(); // Initial creation of chart
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.PropertyChanged += ViewModel_PropertyChanged;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _viewModel.PropertyChanged -= ViewModel_PropertyChanged;
    }

    private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ResultsPageViewModel.QuizComplete))
        {
            RecreateChart();
        }
    }

    private void RecreateChart()
    {
        if (_viewModel.QuizComplete)
        {
            ResultChart.Chart = new DonutChart
            {
                Entries = new[]
                {
                        new ChartEntry(_viewModel.DemocraticPoints)
                        {
                            Label = "Democratic",
                            Color = SKColor.Parse("#073e7e")
                        },
                        new ChartEntry(_viewModel.RepublicanPoints)
                        {
                            Label = "Republican",
                            Color = SKColor.Parse("#d8311f")
                        },
                        new ChartEntry(FinalPoints.FinalGreenPoints)
                        {
                            Label = "Green",
                            Color = SKColor.Parse("#7ed956")
                        },
                        new ChartEntry(FinalPoints.FinalLibertarianPoints)
                        {
                            Label = "Libertarian",
                            Color = SKColor.Parse("#ff7f1a")
                        },
                        new ChartEntry(FinalPoints.FinalOtherPoints)
                        {
                            Label = "Other",
                            Color = SKColor.Parse("#b34bc4")
                        } 
                },
                LabelMode = LabelMode.None
            };

            _viewModel.CalculateResult();
        }
        else
        {
            // Clear the chart if quiz is not active
            ResultChart.Chart = null;
        }
    }
}