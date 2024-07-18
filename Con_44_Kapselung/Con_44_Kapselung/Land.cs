using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Con_44_Kapselung
{
    class Land
    {
        public Land(string Name, int Flaeche, double Einwohner, int Zeitzone)
        {
            this.name = Name;
            this.flaeche = Flaeche;
            this.einwohner = Einwohner;
            this.zeitzone = Zeitzone;
        }



        #region "Java-Style"

        private string? name;
        private int flaeche;
        private double einwohner;
        private int zeitzone;

        public string GetName()
        {
            return name;
        }

        public void SetName(string? value)
        {
            name = value;
        }

        public int GetFlaeche()
        {
            return flaeche;
        }

        public void SetFlaeche(int value)
        {
            flaeche = value;
        }

        public double GetEinwohner()
        {
            return einwohner;
        }

        public void SetEinwohner(double value)
        {
            einwohner = value;
        }

        public int GetZeitzone()
        {
            return zeitzone;
        }

        public void SetZeitzone(int value)
        {
            zeitzone = value;
        }

        #endregion

        //public string? Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}

        //public int Flaeche
        //{
        //    get { return flaeche; }
        //    set { flaeche = value; }
        //}

        //public double Einwohner
        //{
        //    get { return einwohner; }
        //    set { einwohner = value; }
        //}

        //public int Zeitzone
        //{
        //    get { return zeitzone; }
        //    set { zeitzone = value; }
        //}

        //public string? Name { get; set; }
        //public int Flaeche { get; set; }
        //public double Einwohner { get; set; }
        //public int Zeitzone { get; set; }
    }
}
