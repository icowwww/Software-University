using System;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Functionality;

namespace P01_BillsPaymentSystem.Core
{
    public static class Engine
    {
        private const string LoginError =
            "Verify that the instance name is correct and that SQL Server is configured to allow" +
            " remote connections.";

        private static readonly string[] Commands =
            {"delete", "create", "migrate", "seed", "detailsCheck", "payBill", "exit"};

        public static void Run()
        {
            Console.Write("Write command: ");
            var input = Console.ReadLine();
            while (input != "exit")
            {
                var context = new BillsPaymentSystemContext();
                using (context)
                {
                    try
                    {
                        switch (input)
                        {
                            case "seed":
                                string msg;
                                using (new Loading())
                                {
                                    msg = SeedDatabase.Seed(context);
                                }
                                if (msg != "")
                                    Console.WriteLine(msg);
                                break;
                            case "detailsCheck":
                                Console.Write("Enter user id: ");
                                var userId = Console.ReadLine();
                                while (!int.TryParse(userId, out var n))
                                {
                                    Console.WriteLine("User id is an integer!");
                                    Console.Write("Enter user id: ");
                                    userId = Console.ReadLine();
                                }
                                Console.Write(new UserDetails().DisplayInfo(context, int.Parse(userId)));
                                break;
                            case "delete":
                                using (new Loading())
                                {
                                    context.Database.EnsureDeleted();
                                }
                                Console.WriteLine("Successfully deleted.");
                                break;
                            case "create":
                                using (new Loading())
                                {
                                    context.Database.EnsureCreated();
                                }
                                Console.WriteLine("Successfully created.");
                                break;
                            case "migrate":
                                using (new Loading())
                                {
                                    context.Database.Migrate();
                                }
                                Console.WriteLine("Successfully migrated.");
                                break;
                            case "payBill":
                                Console.Write("Enter user id: ");
                                var id = Console.ReadLine();
                                while (!int.TryParse(id, out var n))
                                {
                                    Console.WriteLine("User id is an integer!");
                                    Console.Write("Enter user id: ");
                                    id = Console.ReadLine();
                                }
                                Console.Write("Enter amount: ");
                                var amount = decimal.Parse(Console.ReadLine());

                                Console.WriteLine(
                                    new BillPayer().PayBills(int.Parse(id), amount, context));
                                break;
                            default:
                                Console.WriteLine($"Command {input} not found. Available commands: " +
                                                  string.Join(", ", Commands));
                                break;
                        }
                    }
                    catch (Exception e)
                    {
                        if (e.ToString().Contains(LoginError))
                            SeedDatabase.Seed(context);
                        else
                            Console.WriteLine(e.Message);
                    }
                    Console.Write("Write command: ");
                    input = Console.ReadLine();
                }
            }
        }
    }
}