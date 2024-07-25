using System.Text;

namespace Con_FIA44_CsvCrud
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Article> articles = new List<Article>();
            Article article = new Article();

            articles = ShowArticles(article);

            Console.WriteLine("Get Article:");
            article = article.GetArticle(9);

            article.DisplayArticle(article);

            //Console.WriteLine("Add Article:");
            //Article newArticle = new Article()
            //{
            //    Name = "Shorts",
            //    Price = 99.99m,
            //    Stock = 150,
            //    InAssortSince = DateTime.Now,
            //    Discountable = false
            //};

            //int articleID = article.AddArticle(newArticle);
            //article.GetArticle(articleID);
            //articles = ShowArticles(article);

            //article.DisplayArticle(article.GetArticle(article.AddArticle(newArticle)));

            Console.WriteLine($"Article deleted: {article.DeleteArticle(11)}");        

            Console.WriteLine("Update Article:");
            Article updatedArticle = new Article()
            {
                Aid = 2,
                Name = "Test22",
                Price = 199.99m,
                Stock = 200,
                InAssortSince = DateTime.Now,
                Discountable = false
            };

            article.UpdateArticle(updatedArticle);

            articles = ShowArticles(article);
            //article.DisplayArticles(article.GetArticles("Article.csv"));
        }

        private static List<Article> ShowArticles(Article article)
        {
            List<Article> articles = article.GetArticles("Article.csv");
            article.DisplayArticles(articles);
            return articles;
        }
    }
}
