using CommunityToolkit.Mvvm.Input;
using Elephonkey.Models;
using Elephonkey.Service;
using Microcharts;
using SkiaSharp;
using System.Diagnostics;

namespace Elephonkey.ViewModels
{
    public partial class HomePageViewModel
    {

        // Properties for quiz state and result
        public bool QuizIncomplete { get; set; }
        public bool QuizComplete { get; set; }
        public string ResultText { get; set; }
        public string ResultColor { get; set; }

        public string Name { get; set; } = TextModel.myName;

        public ICollection<Article> Headlines { get; set; }
        public ICollection<Article> HomePageArticles { get; set; }
        public ICollection<Article> FeaturedArticle { get; set; }

        public Command<Article> TappedCommand { get; set; }

        public HomePageViewModel(INewsService news)
        {
            Headlines = news.GetHeadlines();
            Debug.WriteLine($"Number of headlines fetched: {Headlines.Count}");

            HomePageArticles = news.GetHomePageArticles();
            Debug.WriteLine($"Number of homepage articles fetched: {HomePageArticles.Count}");

            FeaturedArticle = news.GetFeaturedArticle();
            Debug.WriteLine($"Number of featured articles fetched: {FeaturedArticle.Count}");

            TappedCommand = new Command<Article>((article) =>
            {
                var query = new Dictionary<string, object>()
                {
                    { "article", article }
                };
                Shell.Current.GoToAsync("//Home/article", query);
            });

            ResultText = FinalPoints.ResultText;
            ResultColor = FinalPoints.ResultColor;

            QuizIncomplete = FinalPoints.QuizActive;
            QuizComplete = !FinalPoints.QuizActive;
        }

        [RelayCommand]
        public static void Settings()
        {
            // Navigate to the ResultsPage
            Shell.Current.GoToAsync(state: "//Settings");
        }

        [RelayCommand]
        public static void Survey()
        {
            // Navigate to the ResultsPage
            Shell.Current.GoToAsync(state: "//Survey");
        }
    }
}