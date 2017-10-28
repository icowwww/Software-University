using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            char[] separators = " ,.?!".ToCharArray();
            string[] words = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(x => x)
                .Distinct().ToArray();
            List<string> palindromes = new List<string>();
            foreach (string word in words)
                if (IsPalindrome(word))     palindromes.Add(word);
            Console.WriteLine(string.Join(", ", palindromes));
        }

        static bool IsPalindrome(string text)
        {
            for (int i = 0; i < text.Length / 2; i++)
                if (text[i] != text[text.Length - 1 - i]) return false;
            return true;
        }
    }
}