using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elephonkey.Models
{
    public class Article
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Party { get; set; }

        public string Category { get; set; }

        public string Time { get; set; }
        public string ImageURL { get; set; }

        public string Body { get; set; }

        //GetConservativeArticles() will retrieve all articles with Conservative = true. GetLiberalArticles() will retrieve all articles with Liberal = true.
        public Boolean Conservative { get; set; } = false;

        //GetHomePageArticles() will retrieve all articles with HomePage = true

        public Boolean HomePage { get; set; } = false;

        //GetFeaturedArticle() will retrieve all articles with Featured = true

        public Boolean Featured { get; set; } = false;

        //GetHeadlines() will retrieve all articles with Headline = true

        public Boolean Headline { get; set; } = false;
    }
}