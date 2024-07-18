using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Con_FIA44_LaenderCSV
{
    internal class Land
    {
        public string Name { get; set; }
        public int Flaeche { get; set; }
        public double Einwohner { get; set; }
        public int Zeitzonen { get; set; }

        public bool LandKleiner100000 { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Land()
        {

        }
        /// <summary>
        /// Konstruktor mit Parametern
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Flaeche"></param>
        /// <param name="Einwohner"></param>
        /// <param name="Zeitzone"></param>
        public Land(string Name, int Flaeche, double Einwohner, int Zeitzone)
        {
            this.Name = Name;
            this.Flaeche = Flaeche;
            this.Einwohner = Einwohner;
            this.Zeitzonen = Zeitzone;
        }

        /// <summary>
        /// ToString Methode überschreiben
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string landKleiner = LandKleiner100000 == false ? "👎" : "👍";

            return $"Name: {Name} Fläche: {Flaeche} Einwohner: {Einwohner} Zeitzone: {Zeitzonen} Land ist kleiner 100000 km²? {landKleiner}";
        }

        public string MaxFlaeche(List<Land> laender)
        {
            int maxFlaeche = 0;
            string maxLand = string.Empty;

            foreach (var land in laender)
            {
                if (land.Flaeche > maxFlaeche)
                {
                    maxLand = land.Name;
                    maxFlaeche = land.Flaeche;
                }
            }
            return $"Das Land {maxLand} hat die größte Fläche mit {maxFlaeche} km²";
        }

        public string MinFlaeche(List<Land> laender)
        {
            int minFlaeche = int.MaxValue;
            string minLand = string.Empty;

            foreach (var land in laender)
            {
                if (land.Flaeche < minFlaeche)
                {
                    minLand = land.Name;
                    minFlaeche = land.Flaeche;
                }
            }
            return $"Das Land {minLand} hat die kleinste Fläche mit {minFlaeche} km²";
        }

        public string MaxEinwohner(List<Land> laender)
        {
            double maxEinwohner = 0;
            string maxLand = string.Empty;

            foreach (var land in laender)
            {
                if (land.Einwohner > maxEinwohner)
                {
                    maxLand = land.Name;
                    maxEinwohner = land.Einwohner;
                }
            }
            return $"Das Land {maxLand} hat die meisten Einwohner mit {maxEinwohner} Millionen";
        }

        public bool LandIstKleinerAls100000(int flaeche)
        {
            if (flaeche < 100000)
            {
                return true;
            }

            return false;
        }

        public double EinwohnerAVG(List<Land> laender)
        {
            double sum = 0;
            foreach (var land in laender)
            {
                sum += land.Einwohner;
            }
            return sum / laender.Count;
        }
    }
}
