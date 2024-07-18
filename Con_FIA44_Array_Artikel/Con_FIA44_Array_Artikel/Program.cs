namespace Con_FIA44_Array_Artikel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] artikel = { { "Hammer", "35", "20"}, { "Zange", "25", "10"}, { "Nagel", "0.6", "150"}, { "Dübel", "0.5", "500"} };

            Console.WriteLine("Artikel\t\tPreis\t\tMenge");
            Console.WriteLine("======================================");

            for (int i = 0; i < artikel.GetLength(0); i++)
            {
                for (int j = 0; j < artikel.GetLength(1); j++)
                {
                    Console.Write(artikel[i, j] + "\t\t");
                }

                Console.WriteLine();
            }



        }
    }
}
