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

            articles = article.GetArticles("Article.csv");
            article.DisplayArticles(articles);

            article = article.GetArticle(2);

            article.DisplayArticle(article);

            //Article newArticle = new Article()
            //{
            //    Name = "New Article",
            //    Price = 99.99m,
            //    Stock = 100,
            //    InAssortSince = DateTime.Now,
            //    Discountable = true
            //};

            //article.DisplayArticle(article.GetArticle(article.AddArticle(newArticle)));

            //article.DeleteArticle(10);

            //Article updatedArticle = new Article()
            //{
            //    Aid = 2,
            //    Name = "Updated Article",
            //    Price = 199.99m,
            //    Stock = 200,
            //    InAssortSince = DateTime.Now,
            //    Discountable = false
            //};

            //article.UpdateArticle(updatedArticle);
        }
    }
}
