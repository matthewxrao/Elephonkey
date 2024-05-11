using CommunityToolkit.Mvvm.Input;
using Elephonkey.Models;
using Elephonkey.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephonkey.ViewModels
{
    public partial class ArticlesViewModel
    {
        [RelayCommand]
        public static void Settings()
        {
            // Navigate to the ResultsPage
            Shell.Current.GoToAsync(state: "//Settings");
        }

        public ICollection<Article> ConservativeArticles { get; set; }
        public ICollection<Article> LiberalArticles { get; set; }

        public ArticlesViewModel(INewsService news)
        {
            // Fetch conservative articles
            ConservativeArticles = news.GetConservativeArticles();

            // Fetch liberal articles
            LiberalArticles = news.GetLiberalArticles();
        }
    }
}
