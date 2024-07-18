using System.Text;

namespace Con_FIA44_StringParse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string preis = "123,4";

            double preisDouble = double.Parse(preis);

            Console.WriteLine(preisDouble);
            Console.WriteLine(preisDouble.ToString("C2"));
            Console.WriteLine($"{preisDouble:C2}");

            string bestand = "42";

            //int bestandInt = int.Parse(bestand);
            int bestandInt;
            bool isInteger = int.TryParse(bestand, out bestandInt);

            if (isInteger)
                Console.WriteLine(bestandInt);
            else
                Console.WriteLine("Fehler beim Parsen");



        }
    }
}
