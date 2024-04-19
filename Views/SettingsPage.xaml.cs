using Elephonkey.ViewModels;

namespace Elephonkey.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage()
	{
		InitializeComponent();
		BindingContext = new SettingsPageViewModel();
	}
}