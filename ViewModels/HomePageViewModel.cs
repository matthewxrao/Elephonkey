using Elephonkey.Models;
using Elephonkey.Service;
using Microcharts;
using SkiaSharp;

namespace Elephonkey.ViewModels
{
    public class HomePageViewModel
    {
        public string Name { get; set; } = TextModel.myName;

        public HomePageViewModel(INewsService news)
        {
            this.Headlines = news.GetHeadlines();

            this.HomePageArticles = news.GetHomePageArticles();

            this.FeaturedArticle = news.GetFeaturedArticle();

            this.TappedCommand = new Command<Article>((article) =>
            {
                var query = new Dictionary<string, object>()
                {
                    { "article", article }
                };
                Shell.Current.GoToAsync("//Home/article", query);
            });
        }

        public ICollection<string> Headlines { get; set; }

        public ICollection<Article> HomePageArticles { get; set; }
        public ICollection<Article> FeaturedArticle { get; set; }

        public Command<Article> TappedCommand { get; set; }
    }
}

