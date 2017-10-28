using System;

namespace Occurrences_in_String
{
    public class Occurrences_in_String
    {
        public static void Main()
        {
            string text = Console.ReadLine().ToLower();
            string word = Console.ReadLine();
            int countWordOccurrencies = 0;
            int index = 0;
            while (index < text.Length)
            {
                index = text.IndexOf(word, index) + 1;
                if (index > 0)  countWordOccurrencies++;
                else break;
            }
            Console.WriteLine(countWordOccurrencies);
        }
    }
}