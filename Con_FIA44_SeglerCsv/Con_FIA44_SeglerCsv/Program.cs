using System.Text;

namespace Con_FIA44_SeglerCsv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            //Pfad zur CSV-Datei
            string path = "Schiffe.csv";

            //Datei prüfen
            if (!File.Exists("Schiffe.csv"))
            {
                Console.WriteLine("Datei Schiffe.csv nicht gefunden");
                return;
            }

            Ship s = new Ship();

            //Datei einlesen
            List<Ship> ships = s.ReadAllShipsFromCSV(path);

            //Alle Schiffe anzeigen
            s.DisplayAllShips(ships);

            //Größtes Schiff anzeigen
            s = s.GetLengthShip(ships);

            Console.WriteLine($"Das Größtes Schiff ist {s.Name} mit einer Länge von {s.LaengeInMeter} m und einen Tiefgang von {s.TiefgangInZentimeter} cm");
        }
    }
}
