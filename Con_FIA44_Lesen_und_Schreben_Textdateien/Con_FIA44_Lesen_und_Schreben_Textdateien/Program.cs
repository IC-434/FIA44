using System;

namespace Con_FIA44_Lesen_und_Schreben_Textdateien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("---- Schreiben und Lesen einer Datei -----");
            Console.WriteLine();
            File.WriteAllText("text.txt", "Das ist ein toller Text");
            File.AppendAllText("text.txt", $"{Environment.NewLine}Das ist ein weiterer Text");

            string data = File.ReadAllText("text.txt");
            Console.WriteLine(data);

            string[] allRows = File.ReadAllLines("text.txt");

            foreach (string row in allRows)
            {
                Console.WriteLine(row);
            }

            // Alternativen für Ausgabe
            Console.WriteLine();
            Console.WriteLine("---- Alternativen für Ausgabe -----");
            Console.WriteLine();

            File.ReadAllLines("text.txt").ToList().ForEach(Console.WriteLine);
            File.ReadAllLines("text.txt").ToList().ForEach(row => Console.WriteLine(row));

            Console.WriteLine();
            Console.WriteLine("---- Verarbeitung einer CSV-Datei -----");
            Console.WriteLine();

            string[] allPerson = {
                "Max;Mustermann;42",
                "Erika;Musterfrau;33",
                "Hans;Dampf;55",
                "Hein;Blöd;22"
            };

            File.WriteAllLines("Personen.csv", allPerson);

            string[] allPersonRead = File.ReadAllLines("Personen.csv");
            Console.WriteLine(" --------------------------------");
            Console.WriteLine("| Vorname | Nachname   |  Alter  |");
            Console.WriteLine(" --------------------------------");

            foreach (var row in allPersonRead)
            {
                string[] column = row.Split(';');

                Console.WriteLine($"| {column[0],-8}| {column[1],-10} |  {column[2],-5}  |");
            }

            Console.WriteLine(" --------------------------------");

            Console.WriteLine();
            Console.WriteLine("---- Artikelbestand -----");
            Console.WriteLine();
        }
    }
}
