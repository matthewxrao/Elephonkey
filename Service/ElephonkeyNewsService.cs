using Elephonkey.Models;
using Elephonkey.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephonkey.Service
{
    public class ElephonkeyNewsService : INewsService
    {
        private readonly SQLiteArticles _sqliteArticles;

        public ElephonkeyNewsService()
        {
            _sqliteArticles = new SQLiteArticles();
        }

        public ICollection<Article> GetHeadlines()
        {
            return _sqliteArticles.GetAll<Article>(a => a.Headline).ToList();
        }

        public ICollection<Article> GetConservativeArticles()
        {
            return _sqliteArticles.GetAll<Article>(a => a.Conservative).ToList();
        }

        public ICollection<Article> GetLiberalArticles()
        {
            return _sqliteArticles.GetAll<Article>(a => !a.Conservative).ToList();
        }

        public ICollection<Article> GetHomePageArticles()
        {
            return _sqliteArticles.GetAll<Article>(a => a.HomePage).ToList();
        }

        public ICollection<Article> GetFeaturedArticle()
        {
            return _sqliteArticles.GetAll<Article>(a => a.Featured).ToList();
        }
    }
}