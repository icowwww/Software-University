using System;
using System.Linq;

namespace Reverse_Words_In_Sentence
{
    public class Reverse_Words_In_Sentence
    {
        public static void Main()
        {
            // UPDATE: problem modified by SoftUni
            string sentence = Console.ReadLine();
            char[] wordSeparators = " .,:;=()&[]\"'\\/!?".ToCharArray();
            string[] words = sentence
                .Split(wordSeparators, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(words);

            char[] punctuationSeparators = string.Join("", words)
                .ToCharArray()
                .Distinct().ToArray();
            string[] punctuation = sentence
                .Split(punctuationSeparators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
                Console.Write(string.Join("", words[i], punctuation[i]));
        }
    }
}