using System;
using System.Linq;

namespace Man_O_War
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var pirateShipStatus = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var warShipStatus = Console.ReadLine().Split('>', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();
            var maxHealth = int.Parse(Console.ReadLine());

            var commandInput = Console.ReadLine();
            while (commandInput != "Retire")
            {
                var commandArgs = commandInput.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = commandArgs[0];
                switch (command)
                {
                    case "Fire":
                    {
                        var index = int.Parse(commandArgs[1]);
                        var damage = int.Parse(commandArgs[2]);
                        var warShipCount = warShipStatus.Count;
                        if (CheckIndex(warShipCount, index, null))
                        {
                            warShipStatus[index] -= damage;
                            if (warShipStatus[index] > 0) break;
                            Console.WriteLine("You won! The enemy ship has sunken.");
                            return;
                        }

                        break;
                    }
                    case "Defend":
                    {
                        var startIndex = int.Parse(commandArgs[1]);
                        var endIndex = int.Parse(commandArgs[2]);
                        var damage = int.Parse(commandArgs[3]);
                        var pirateShipCount = pirateShipStatus.Count;

                        if (CheckIndex(pirateShipCount, startIndex, endIndex))
                            for (var i = startIndex; i <= endIndex; i++)
                            {
                                pirateShipStatus[i] -= damage;
                                if (pirateShipStatus[i] > 0) continue;
                                Console.WriteLine("You lost! The pirate ship has sunken.");
                                return;
                            }

                        break;
                    }
                    case "Repair":
                    {
                        var index = int.Parse(commandArgs[1]);
                        var health = int.Parse(commandArgs[2]);
                        var pirateShipCount = pirateShipStatus.Count;
                        if (CheckIndex(pirateShipCount, index, null))
                        {
                            if (pirateShipStatus[index] + health >= maxHealth)
                                pirateShipStatus[index] = maxHealth;
                            else
                                pirateShipStatus[index] += health;
                        }

                        break;
                    }
                    case "Status":
                    {
                        var sectionsForRepair = pirateShipStatus.Count(x => maxHealth * 0.20 > x);
                        Console.WriteLine($"{sectionsForRepair} sections need repair.");
                        break;
                    }
                }

                commandInput = Console.ReadLine();
            }

            var pirateShipSum = pirateShipStatus.Sum();
            var warShipSum = warShipStatus.Sum();

            Console.WriteLine($"Pirate ship status: {pirateShipSum}");
            Console.WriteLine($"Warship status: {warShipSum}");
        }

        private static bool CheckIndex(int elementsCount, int startIndex, int? endIndex)
        {
            if (startIndex < 0 || startIndex >= elementsCount)
                return false;

            if (!endIndex.HasValue)
                return true;

            return !(endIndex < 0) && !(endIndex >= elementsCount) && !(startIndex > endIndex);
        }
    }
}