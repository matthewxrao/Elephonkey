using Elephonkey.Models;
using Elephonkey.ViewModels;
using System.Windows.Input;

namespace Elephonkey.Views;

public partial class SurveyPage : ContentPage
{
    public SurveyPage()
    {
        InitializeComponent();
        BindingContext = new SurveyPageViewModel();
    }
}