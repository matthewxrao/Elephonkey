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
    public partial class ArticleViewModel
    {
        public ArticleViewModel(INewsService news, Article a)
        {
            this.Title = a.Title;
            this.ImageURL = a.ImageURL;
            this.Body = a.Body;
            this.Time = a.Time;
        }

        public string Title { get; set; }

        public string ImageURL { get; set; }

        public string Body { get; set; }

        public string Time { get; set; }

        [RelayCommand]
        public static void Back()
        {
            // Navigate to the ResultsPage
            Shell.Current.GoToAsync(state: "//Home");
        }

        [RelayCommand]
        public static void Settings()
        {
            // Navigate to the ResultsPage
            Shell.Current.GoToAsync(state: "//Settings");
        }
    }
}
