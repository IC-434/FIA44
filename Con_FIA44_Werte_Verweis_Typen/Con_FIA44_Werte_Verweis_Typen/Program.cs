namespace Con_FIA44_Werte_Verweis_Typen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 10;
            object o = 100, p = 100;
            string test = "Hallo";
            string test2 = "Hallo";

            if (a == b)
            {
                // Vergleich von Werttypen
                Console.WriteLine($"Integerwerte a -> {a} und b -> {b} sind gleich");
            }

            if (o.Equals(p))
            {
                // Vergleich von Verweistypen
                Console.WriteLine($"Verweiswerte a -> {o} und p -> {p} sind gleich");
            }

            if (test == test2)
            {
                // Vergleich von Verweistypen
                Console.WriteLine($"Stringwerte test -> {test} und test2 -> {test2} sind gleich");
            }

            test = null;

            int? c = 100;
            int f = c ?? -1; // Null-Coalescing-Operator
            int g = c == null ? -1 : (int)c; // Ternärer Operator

            bool? d = true;
            d = null;
        }
    }
}
