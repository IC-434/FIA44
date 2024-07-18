using System.Text;

namespace Con_FIA44_LaenderCSV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            List<Land> laender = new List<Land>();

            //Prüfen, ob Datei vorhanden ist
            if (!File.Exists("Laender.csv"))
            {
                Console.WriteLine("Datei nicht gefunden");
                return;
            }

            string[] allLines = File.ReadAllLines("Laender.csv");
            int maxFlaeche = 0;

            //CSV-Datei einlesen
            //for (int i = 0; i < allLines.Length; i++)
            //{
            //    string line = allLines[i];
            //    string[] part = line.Split(";");

            //    Land land = new Land();

            //    land.Name = part[0];
            //    land.Flaeche = int.Parse(part[1]);
            //    land.Einwohner = double.Parse(part[2]);
            //    land.Zeitzonen = int.Parse(part[3]);

            //    laender.Add(land);

            //}

            foreach (string line in allLines)
            {
                string[] part = line.Split(";");

                Land land = new Land();

                land.Name = part[0];
                land.Flaeche = int.Parse(part[1]);
                land.Einwohner = double.Parse(part[2]);
                land.Zeitzonen = int.Parse(part[3]);
                land.LandKleiner100000 = land.LandIstKleinerAls100000(land.Flaeche);

                laender.Add(land);
            }

            ////Land manuell hinzufügen
            //laender.Add(new Land("Griechenland", 56000, 12.6, 3));
            ////Besser: Land mit Objekt-Initialisierern hinzufügen
            //laender.Add(new Land { Name = "Griechenland", Flaeche = 56000, Einwohner = 12.6, Zeitzonen = 3});

            //Ausgabe

            //Prüfen, ob Länder vorhanden sind
            if (laender.Count == 0)
            {
                Console.WriteLine("Keine Länder gefunden");
                return;
            }

            //Headline in Farbe
            Console.Write($"\u001b[38;2;{255};{165};{0}m");
            Console.WriteLine($"Länder der Welt{Environment.NewLine}");
            Console.Write("\u001b[0m");

            foreach (var land in laender)
            {
                //Console.WriteLine($"Name: {land.Name} Fläche: {land.Flaeche} Einwohner: {land.Einwohner} Zeitzone: {land.Zeitzonen}");
                Console.WriteLine(land.ToString());
            }

            //Maximale Fläche
            Land l = new Land ();
            Console.WriteLine();
            Console.WriteLine(l.MaxFlaeche(laender));
            Console.WriteLine(l.MinFlaeche(laender));
            Console.WriteLine(l.MaxEinwohner(laender));
            Console.WriteLine($"Der Einwohnerdurchschnitt beträgt: {l.EinwohnerAVG(laender):F3} Millionen Einwohner");
        }
    }
}
