using System;

namespace Forbidden_Substrings
{
    public class Forbidden_Substrings
    {
        public static void Main()
        {
            string[] words = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] forbiddenWords = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
                foreach (string forbiddenWord in forbiddenWords)
                    if (words[i].Contains(forbiddenWord))
                        words[i] = words[i].Replace(forbiddenWord, new string('*', forbiddenWord.Length));
            Console.WriteLine(string.Join(" ", words));
        }
    }
}