using Elephonkey.ViewModels;

namespace Elephonkey.Views;

public partial class SurveyPage : ContentPage
{
	public SurveyPage()
	{
		InitializeComponent();
		BindingContext = new SurveyPageViewModel();
	}
}