using System;

namespace Occurrences_in_String
{
    public class Occurrences_in_String
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();
            int countWordOccurrencies = 0;
            for (int i = 0; i < text.Length; i++)
                if (i == text.IndexOf(word, i))
                    countWordOccurrencies++;
            Console.WriteLine(countWordOccurrencies);
        }
    }
}