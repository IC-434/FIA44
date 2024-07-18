using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Con_FIA44_SeglerCsv
{
    internal class Ship
    {
        public int SID { get; set; }
        public string Name { get; set; }
        public double LaengeInMeter { get; set; }
        public int TiefgangInZentimeter { get; set; }
        public bool IstSegler { get; set; }

        private int verdraengung;

        public int Verdraengung
        {
            get { return verdraengung; }
            set { verdraengung = value; }
        }

        public List<Ship> ReadAllShipsFromCSV(string path)
        {
            List<Ship> ships = new List<Ship>();

            //Datei einlesen
            string[] lines = File.ReadAllLines(path);

            //Jede Zeile durchgehen
            foreach (string line in lines)
            {
                //Kommentarzeilen überspringen
                if (line.StartsWith("#") || line == "")
                {
                    continue;
                }

                //Daten in Array umwandeln
                string[] parts = line.Split(';');

                //Schiff erstellen
                Ship ship = new Ship();

                //Daten zuweisen
                ship.SID = int.Parse(parts[0]);
                ship.Name = parts[1];
                ship.LaengeInMeter = double.Parse(parts[2]);
                ship.TiefgangInZentimeter = int.Parse(parts[3]);
                ship.IstSegler = bool.Parse(parts[4]);
                ship.Verdraengung = int.Parse(parts[5]);

                //Schiff hinzufügen
                ships.Add(ship);
            }

            return ships;
        }

        public void DisplayAllShips(List<Ship> ships)
        {
            Console.WriteLine("Alle Schiffe:");
            Console.WriteLine();

            foreach (Ship ship in ships)
            {
                Console.WriteLine($"{ship.SID, -5}{ship.Name, -20}{ship.LaengeInMeter + " m",-9}{ship.TiefgangInZentimeter + " cm", -8}{(ship.IstSegler == true ? "👍" : "👎"), -5}{ship.Verdraengung}");
            }

        }

        public Ship GetLengthShip(List<Ship> ships)
        {
            if (ships.Count == 0)
            {
                return null;
            }

            Ship ship = ships[0];

            foreach (Ship s in ships)
            {
                if (s.LaengeInMeter > ship.LaengeInMeter)
                {
                    ship = s;
                }
            }

            return ship;
        }
    }
}
