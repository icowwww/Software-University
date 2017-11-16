using System;
using P03_FootballBetting.Data;

namespace P03_FootballBetting_App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Server name: ");
            var serverName = Console.ReadLine();
            Console.Write("Requested database name: ");
            var databaseName = Console.ReadLine();
            var configuration = new Configuration(serverName, databaseName);
            var context = new FootballBettingContext(configuration);
            Console.Write($"Creating {databaseName} database... ");
            using (new ProgressBar())
            {
                context.Database.EnsureCreated();
            }
            Console.WriteLine("Done.");
        }
    }
}