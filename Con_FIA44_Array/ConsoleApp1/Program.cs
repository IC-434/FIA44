using System.Linq.Expressions;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Deklaration
            double[] werte1 = new double[5];
            double[] ergebnisse = new double[5];
            double[] werte3 = new double[10];

            // Initialisierung
            werte1[0] = 1.0;
            werte1[1] = 2.0;
            werte1[2] = 3.0;
            werte1[3] = 4.0;
            werte1[4] = 5.0;

            // Deklaration und Initialisierung in einem Schritt
            double[] werte2 = { 1.0, 2.5, 2.1, 3.4, 90 };

            Console.WriteLine($"--------------------- Addieren und Ausgeben ---------------------");
            // Addieren und ausgeben
            for (int i = 0; i < werte1.Length; i++)
            {
                ergebnisse[i] = werte1[i] + werte2[i];
                Console.WriteLine(ergebnisse[i]);
            }

            Console.WriteLine($"-----------------------------------------------------------------");

            Console.WriteLine($"--------------------- Arraywerte aus 1. und 2. in 3. kopieren ---------------------");

            // Erstes Array kopieren
            for (int i = 0; i < werte1.Length; i++)
            {
                if (i < werte1.Length)
                {
                    werte3[i] = werte1[i];
                }
            }

            // zweites Array kopieren
            for (int i = 0; i < werte2.Length; i++)
            {
                if (i < werte2.Length)
                {
                    werte3[i + werte1.Length] = werte2[i];
                };
            }

            // Ausgabe
            foreach (var item in werte3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"-----------------------------------------------------------------------------------");
        }
    }
}
