using System.Text;
using Spectre.Console;

namespace Con_FIA44_Artikel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            //CSV-Datei einlesen
            string[] alleArtikel = File.ReadAllLines("Artikel.csv");
            string maxPreisArtikel = string.Empty;
            decimal maxPreis = decimal.MinValue;
            string minPreisArtikel = string.Empty;
            decimal minPreis = decimal.MaxValue;

            // Create a table
            var table = new Table();
            //Set the table border
            table.Border(TableBorder.Ascii);
            //Set the table color
            HasBorderExtensions.BorderColor(table, Color.Aqua);

            // Set a figlet font
            FigletFont font = FigletFont.Load("fonts/puffy.flf");

            AnsiConsole.Write(new FigletText(font, "Artikelbestand").LeftJustified().Color(Color.Aqua));

            //Console.WriteLine(" ---------------------------------------------------");
            //Console.WriteLine("| Bezeichnung |   Preis    |  Bestand  |   Zulauf   |");
            //Console.WriteLine(" ---------------------------------------------------");

            // Add some columns
            table.AddColumn("[red]Bezeichnung[/]").Centered();
            table.AddColumn(new TableColumn("[red]Preis[/]").Centered());
            table.AddColumn(new TableColumn("[red]Bestand[/]").Centered());
            table.AddColumn(new TableColumn("[red]Zulauf[/]").Centered());

            //BarChart bc = new BarChart();
            //bc.Width = 60;
            //bc.CenterLabel();

            string chart = string.Empty;

            foreach (var artikel in alleArtikel)
            {
                string[] artikelZeile = artikel.Split(';');
                decimal preis = decimal.Parse(artikelZeile[1]);
                int bestand = int.Parse(artikelZeile[2]);
                string zulauf = artikelZeile[3] == "" ? "👎" : "👍";

                if (preis > maxPreis)
                {
                    maxPreis = preis;
                    maxPreisArtikel = artikelZeile[0];
                }

                if (preis < minPreis)
                {
                    minPreis = preis;
                    minPreisArtikel = artikelZeile[0];
                }

                //bc.AddItem("", bestand, Color.Green1);

                var backup = Console.Out;


                using (var writer = new StringWriter())
                {
                    Console.SetOut(writer);
                    //Console.Write("bc");
                    AnsiConsole.Write(new BarChart().Width(60).CenterLabel().AddItem("", bestand, Color.Green1));

                    writer.Flush();

                    chart = writer.GetStringBuilder().ToString();
                }

                Console.SetOut(backup);

                // Add some rows
                table.AddRow($"[blue]{artikelZeile[0]}[/]", $"[green]{preis:C2}[/]", $"{chart}", $"{zulauf}");

                //Console.WriteLine($"| {artikelZeile[0],-10}  |  {preis,-8:C2}  |  {bestand,-4} Stk |     {zulauf,-6} |");
            }

            // Render the table to the console
            AnsiConsole.Write(table);

            //AnsiConsole.Write(bc);
            Console.WriteLine(chart);

            // Create a list of Items
            var rows = new List<Text>(){
                new Text($"Der teuerste Artikel ist {maxPreisArtikel} und kostet {maxPreis:C2}", new Style(Color.Black, Color.White)),
                new Text($"Der günstigste Artikel ist {minPreisArtikel} und kostet {minPreis:C2}", new Style(Color.Violet, Color.Black))};

            // Render each item in list on separate line
            AnsiConsole.Write(new Rows(rows));

            //Console.WriteLine($" ---------------------------------------------------");
            //Console.WriteLine($"Der teuerste Artikel ist {maxPreisArtikel} und kostet {maxPreis:C2}");
            //Console.WriteLine($"Der günstigste Artikel ist {minPreisArtikel} und kostet {minPreis:C2}");

            //Console.WriteLine(" ---------------------------------------------------");
        }
    }
}
