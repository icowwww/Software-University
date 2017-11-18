using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using P01_BillsPaymentSystem.Data.Configuration;

namespace P01_BillsPaymentSystem
{
    public static class SettingUpConnection
    {
        public static void SetUp()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Wrong connection string! You have to manualy set up the connection before using the tool.");
            sb.AppendLine();
            sb.AppendLine("The program will now set up the connection string.");
            sb.AppendLine($"Current connection string: {Configuration.ConnectionString}");
            sb.Append($"Enter server name(i.e - DESKTOP-9NMMA7\\SQLEXPRESS): ");
            Console.Write(sb.ToString());
            var serverName = Console.ReadLine();
            Console.Write($"Enter new database name or hit enter to use the default: ");
            var newDatabaseName = Console.ReadLine();
            var newConnectionString = "";
            if (newDatabaseName=="")
            {
                newConnectionString = $"Server={serverName};Database=BillsPaymentSystem;Integrated Security=True;";
            }
            else
            {
                newConnectionString = $"Server={serverName};Database={newDatabaseName};Integrated Security=True;";
            }
            var field = typeof(Configuration).GetField("ConnectionString",
                BindingFlags.Static |
                BindingFlags.Public);
            field.SetValue(null,newConnectionString);
            Console.WriteLine($"Setting-up finished. New connection string: {Configuration.ConnectionString}");
            Console.WriteLine("You can now try writing the command. If you still getting this error. Go to P01_BillsPaymentSystem.Data.Config.Configuration.ConfigurationString and edit the default info.");
        }
    }
}
