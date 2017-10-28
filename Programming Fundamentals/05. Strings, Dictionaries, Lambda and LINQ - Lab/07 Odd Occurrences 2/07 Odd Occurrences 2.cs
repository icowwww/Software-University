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
            Console.WriteLine(string.Join(", ",
                counts.Where(x => x.Value % 2 == 1).Select(x => x.Key)));
        }
    }
}