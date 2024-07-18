using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Con_FIA44_CsvCrud
{
    internal class Article
    {
        public int Aid { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime InAssortSince { get; set; }
        public bool Discountable { get; set; }

        #region UI-Methods
        public void DisplayArticles(List<Article> articles)
        {
            // Create a table
            var table = new Table();
            //Set the table border
            table.Border(TableBorder.Rounded);
            //Set the table color
            HasBorderExtensions.BorderColor(table, Color.Chartreuse1);

            table.AddColumn("[red]AID[/]").Centered();
            table.AddColumn(new TableColumn("[red]Name[/]").Centered());
            table.AddColumn(new TableColumn("[red]Price[/]").Centered());
            table.AddColumn(new TableColumn("[red]Stock[/]").Centered());
            table.AddColumn(new TableColumn("[red]In Assort Since[/]").Centered());
            table.AddColumn(new TableColumn("[red]Discountable[/]").Centered());

            table.Columns[2].RightAligned();

            foreach (Article article in articles)
            {
                table.AddRow($"[blue]{article.Aid}[/]", $"[plum1]{article.Name}[/]", $"[green]{article.Price:C2}[/]", $"[yellow]{article.Stock} pcs[/]", $"[lime]{article.InAssortSince:dd.MM.yyyy}[/]", $"[purple]{(article.Discountable ? "👍" : "👎")}[/]");
            }

            AnsiConsole.Write(table);
        }

        public void DisplayArticle(Article article)
        {
            // Create a table
            var table = new Table();
            //Set the table border
            table.Border(TableBorder.Rounded);
            //Set the table color
            HasBorderExtensions.BorderColor(table, Color.Chartreuse1);

            table.AddColumn("[red]AID[/]").Centered();
            table.AddColumn(new TableColumn("[red]Name[/]").Centered());
            table.AddColumn(new TableColumn("[red]Price[/]").Centered());
            table.AddColumn(new TableColumn("[red]Stock[/]").Centered());
            table.AddColumn(new TableColumn("[red]In Assort Since[/]").Centered());
            table.AddColumn(new TableColumn("[red]Discountable[/]").Centered());

            table.Columns[2].RightAligned();
            table.Columns[3].RightAligned();

            table.AddRow($"[blue]{article.Aid}[/]", $"[plum1]{article.Name}[/]", $"[green]{article.Price:C2}[/]", $"[yellow]{article.Stock} pcs[/]", $"[lime]{article.InAssortSince:dd.MM.yyyy}[/]", $"[purple]{(article.Discountable ? "👍" : "👎")}[/]");

            AnsiConsole.Write(table);
        }
        #endregion

        #region Logic-Methods
        #endregion

        #region CRUD-Methods
        public List<Article> GetArticles(string path)
        {
            List<Article> articles = new List<Article>();
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {

                if (line.StartsWith("#") || line == "")
                {
                    continue;
                }

                string[] parts = line.Split(';');
                Article article = new Article
                {
                    Aid = int.Parse(parts[0]),
                    Name = parts[1],
                    Price = decimal.Parse(parts[2]),
                    Stock = int.Parse(parts[3]),
                    InAssortSince = DateTime.Parse(parts[4]),
                    Discountable = bool.Parse(parts[5])
                };

                articles.Add(article);
            }

            return articles;
        }

        public Article GetArticle(int id)
        {

            List<Article> articles = GetArticles("Article.csv");

            foreach (Article article in articles)
            {
                if (article.Aid == id)
                {
                    return article;
                }
            }

            return null;
        }

        public int AddArticle(Article article)
        {
            int newId = 0;
            int lastId = 0;

            List<Article> articles = GetArticles("Article.csv");

            newId = articles[articles.Count - 1].Aid + 1;

            article.Aid = newId;
            articles.Add(article);

            string csvContent = $"#AID;Name;Price;Stock;InAssortSince;Discountable{Environment.NewLine}";

            foreach (Article a in articles)
            {
                csvContent += $"{a.Aid};{a.Name};{a.Price};{a.Stock};{a.InAssortSince:d};{a.Discountable}{Environment.NewLine}";
            }

            File.WriteAllText("Article.csv", csvContent);

            return newId;
        }

        public bool DeleteArticle(int id)
        {
            List<Article> articles = GetArticles("Article.csv");

            foreach (Article a in articles)
            {
                if (a.Aid == id)
                {
                    articles.Remove(a);
                    break;
                }
            }

            string csvContent = $"#AID;Name;Price;Stock;InAssortSince;Discountable{Environment.NewLine}";

            foreach (Article a in articles)
            {
                csvContent += $"{a.Aid};{a.Name};{a.Price};{a.Stock};{a.InAssortSince:d};{a.Discountable}{Environment.NewLine}";
            }

            File.WriteAllText("Article.csv", csvContent);

            return true;

            return false;
        }
        #endregion
    }
}
