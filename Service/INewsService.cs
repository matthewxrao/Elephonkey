using Elephonkey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephonkey.Service
{
    public interface INewsService
    {
        ICollection<string> GetHeadlines();
        ICollection<Article> GetConservativeArticles();
        ICollection<Article> GetLiberalArticles();
        ICollection<Article> GetHomePageArticles();
        ICollection<Article> GetFeaturedArticle();
        string GetArticleBody(string articleId);
    }
}