using Microsoft.Data.Sqlite;

namespace Con_FIA44_SQLite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connect to sqlite database via ADO.NET
            //Step 1: Provider/Connector/Driver installation via nuget package
            //Step 2: Create a connection string
            string connectionString = @"Data Source=.\db\PersonDB.sqlite";

            //Step 3: Create a connection object
            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                //Step 4: Open the connection
                connection.Open();
                Console.WriteLine("Connection is open");

                //Step 5: Create a Sqlstatement
                string sql = "SELECT * FROM Person";

                //Step 6: Create a command object
                using (SqliteCommand command = new SqliteCommand(sql, connection))
                {
                    //Step 7: Execute the command
                    using (SqliteDataReader reader = command.ExecuteReader())
                    {
                        //Step 8: Read the data
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader.GetInt32(0)}, FirstName: {reader.GetString(1)} LastName: {reader.GetString(2)}, Birthdate: {reader.GetString(3)}");
                        }
                    }
                }
            }
        }
    }
}
