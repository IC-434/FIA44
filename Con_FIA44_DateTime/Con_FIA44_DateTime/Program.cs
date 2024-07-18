namespace Con_FIA44_DateTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime greeseGeburtsdatum = new DateTime(1932, 4, 1);
            DateTime aktuellesDatum = DateTime.Now;

            TimeSpan zeitspanne = aktuellesDatum - greeseGeburtsdatum;

            // Kulturinformationen für Deutschland
            var culture = new System.Globalization.CultureInfo("de-DE");
            var day = culture.DateTimeFormat.GetDayName(greeseGeburtsdatum.DayOfWeek);

            Console.WriteLine($"Der Kollege Greese ist {(int)(zeitspanne.TotalDays / 365.25)} Jahre alt.");
            Console.WriteLine($"Er ist an einem {day} geboren.");
        }
    }
}
