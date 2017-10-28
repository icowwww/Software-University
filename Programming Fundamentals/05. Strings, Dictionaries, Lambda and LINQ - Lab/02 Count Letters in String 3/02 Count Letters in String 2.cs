using System;
using System.Collections.Generic;

namespace Count_Letters_in_String
{
    public class Count_Letters_in_String
    {
        public static void Main()
        {
            SortedDictionary<char, int> letterCounts = new SortedDictionary<char, int>();
            string word = Console.ReadLine().ToLower();
            foreach (var letter in word)
            {
                if (!letterCounts.ContainsKey(letter))
                    letterCounts[letter] = 0;
                letterCounts[letter]++;
            }
            foreach (var letterPair in letterCounts)
                Console.WriteLine(string.Join(" -> ", letterPair.Key, letterPair.Value));
        }
    }
}