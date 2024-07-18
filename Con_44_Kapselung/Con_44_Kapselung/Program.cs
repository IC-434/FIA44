namespace Con_44_Kapselung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Land land = new Land("Deutschland", 345000, 83.9, 1);

            Console.WriteLine(land.GetName());
            Console.WriteLine(land.GetFlaeche());
            Console.WriteLine(land.GetEinwohner());
            Console.WriteLine(land.GetZeitzone());
        }
    }
}
