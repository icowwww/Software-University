using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Letters_in_String
{
    public class Count_Letters_in_String
    {
        public static void Main()
        {
            Dictionary<char, int> letterCounts = new Dictionary<char, int>();
            string word = Console.ReadLine().ToLower();
            foreach (var letter in word)
            {
                if (!letterCounts.ContainsKey(letter))
                    letterCounts[letter] = 0;
                letterCounts[letter]++;
            }
            foreach (var letterPair in letterCounts.OrderBy(x => x.Key))
                Console.WriteLine(string.Join(" -> ", letterPair.Key, letterPair.Value));
        }
    }
}