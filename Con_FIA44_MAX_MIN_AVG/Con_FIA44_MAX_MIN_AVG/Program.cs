namespace Con_FIA44_MAX_MIN_AVG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] zahlen = new int[] { 5, 7, 99, 2, -6, 0 };
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            double avg = 0;

            foreach (int zahl in zahlen)
            {
                // Max bestimmen
                if (zahl > max)
                {
                    max = zahl;
                }

                // Min bestimmen
                if (zahl < min)
                {
                    min = zahl;
                }
                // Summe berechnen
                sum += zahl;
            }

            // Durchschnitt berechnen
            avg = (double)sum / zahlen.Length;

            Console.WriteLine($"Max: {max + Environment.NewLine}" +
                $"Min: {min + Environment.NewLine}" +
                $"Summe: {sum + Environment.NewLine}" +
                $"Avg: {avg:F2}{Environment.NewLine}");
        }
    }
}
