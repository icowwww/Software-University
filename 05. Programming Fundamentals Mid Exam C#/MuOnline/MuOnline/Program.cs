using System;
using System.Linq;

namespace MuOnline
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var health = 100;
            var bitcoins = 0;

            var inputList = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            var roomCount = 0;
            foreach (var roomArgs in inputList)
            {
                roomCount++;
                var roomArgsList = roomArgs.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var command = roomArgsList[0];
                var number = int.Parse(roomArgsList[1]);

                switch (command)
                {
                    case "potion":
                        var amountToHeal = health + number <= 100 ? number : 100 - health;
                        health += amountToHeal;
                        Console.WriteLine($"You healed for {amountToHeal} hp.");
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        bitcoins += number;
                        Console.WriteLine($"You found {number} bitcoins.");
                        break;
                    default:
                        health -= number;
                        if (!(health <= 0))
                        {
                            Console.WriteLine($"You slayed {command}.");
                            continue;
                        }
                        Console.WriteLine($"You died! Killed by {command}.");
                        Console.WriteLine($"Best room: {roomCount}");
                        return;
                }
            }

            Console.WriteLine($"You've made it!\nBitcoins: {bitcoins}\nHealth: {health}");
        }
    }
}