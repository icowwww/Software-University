using System;
using System.Linq;

namespace TreasureHunt
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var chestItems = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();

            while ("FundamentalsExamGrade" != "6.00")
            {
                var inputLine = Console.ReadLine();

                if (!chestItems.Any())
                {
                    Console.WriteLine("Failed treasure hunt.");
                    return;
                }

                if (inputLine == "Yohoho!")
                    break;

                var inputList = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                var command = inputList[0];

                switch (command)
                {
                    case "Loot":
                        inputList.RemoveAt(0);
                        inputList.ForEach(x =>
                        {
                            if (!chestItems.Contains(x))
                                chestItems.Insert(0, x);
                        });
                        break;
                    case "Drop":
                        var itemIndex = int.Parse(inputList[1]);
                        var item = chestItems.ElementAtOrDefault(itemIndex);
                        if (item != null)
                        {
                            chestItems.RemoveAt(itemIndex);
                            chestItems.Add(item);
                        }

                        break;
                    case "Steal":
                        var stealCount = int.Parse(inputList[1]);
                        var chestCount = chestItems.Count();

                        if (chestCount < stealCount)
                            stealCount = chestCount;

                        if (chestItems.Any())
                        {
                            var stealStartIndex = chestCount - stealCount;
                            Console.WriteLine(string.Join(", ", chestItems.GetRange(stealStartIndex, stealCount)));
                            chestItems.RemoveRange(stealStartIndex, stealCount);
                        }

                        break;
                }
            }

            var chestItemsSum = 0.00;
            chestItems.ForEach(x => { chestItemsSum += x.Length; });

            var averageGain = chestItemsSum / chestItems.Count();

            Console.WriteLine($"Average treasure gain: {averageGain:f2} pirate credits.");
        }
    }
}