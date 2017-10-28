using System;

namespace Capitalization
{
    public class Capitalization
    {
        public static void Main()
        {
            char[] separators = " ,.?!".ToCharArray();
            string[] words = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == 1)
                    words[i] = words[i].ToUpper();
                else
                    words[i] = words[i][0].ToString().ToUpper() +
                                words[i].Substring(1);
            }
            Console.WriteLine(string.Join(" ", words));
        }
    }
}