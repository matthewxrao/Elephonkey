using Elephonkey.Service;
using Elephonkey.ViewModels;

namespace Elephonkey.Views;

public partial class ArticlesPage : ContentPage
{
	public ArticlesPage(INewsService news)
    {
        InitializeComponent();
        this.BindingContext = new ArticlesViewModel(news);
    }
}