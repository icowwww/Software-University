using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Real_Numbers
{
    public class Count_Real_Numbers
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .OrderBy(x => x)
                .ToArray();
            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();
            foreach (double number in numbers)
            {
                if (!counts.ContainsKey(number))
                    counts[number] = 0;
                counts[number]++;
            }
            foreach (var numberPair in counts)
                Console.WriteLine(string.Join(" -> ", numberPair.Key, numberPair.Value));
        }
    }
}