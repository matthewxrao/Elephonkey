using Elephonkey.Models;

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
            return _sqliteArticles.GetAllDistinct<Article>(a => a.Headline).ToList();
        }

        public ICollection<Article> GetConservativeArticles()
        {
            return _sqliteArticles.GetAllDistinct<Article>(a => a.Conservative && !a.HomePage && !a.Headline && !a.Featured).ToList();
        }

        public ICollection<Article> GetLiberalArticles()
        {
            return _sqliteArticles.GetAllDistinct<Article>(a => !a.Conservative && !a.HomePage && !a.Headline && !a.Featured).ToList();
        }

        public ICollection<Article> GetHomePageArticles()
        {
            return _sqliteArticles.GetAllDistinct<Article>(a => a.HomePage).ToList();
        }

        public ICollection<Article> GetFeaturedArticle()
        {
            return _sqliteArticles.GetAllDistinct<Article>(a => a.Featured).ToList();
        }
    }
}