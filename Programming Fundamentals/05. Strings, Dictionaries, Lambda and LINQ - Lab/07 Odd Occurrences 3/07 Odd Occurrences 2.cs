using System;
using System.Collections.Generic;
using System.Linq;

namespace Odd_Occurrences
{
    public class Odd_Occurrences
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (!counts.ContainsKey(word))
                    counts[word] = 0;
                counts[word]++;
            }
            List<string> oddOccurrencies = new List<string>();
            foreach (var pair in counts)
                if (pair.Value % 2 == 1) oddOccurrencies.Add(pair.Key);
            Console.WriteLine(string.Join(", ", oddOccurrencies));
        }
    }
}