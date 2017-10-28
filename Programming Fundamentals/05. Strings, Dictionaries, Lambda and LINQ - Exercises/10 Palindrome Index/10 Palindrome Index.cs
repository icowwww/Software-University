using System;

namespace Palindrome_Index
{
    public class Palindrome_Index
    {
        public static void Main()
        {
            string word = Console.ReadLine();
            if (word.Length == 1)
                Console.WriteLine(-1);
            else
                for (int i = 0; i < word.Length; i++)
                    if (IsPalindrome(word.Remove(i, 1)))
                    {
                        Console.WriteLine(i);
                        break;
                    }
        }

        static bool IsPalindrome(string text)
        {
            for (int i = 0; i < text.Length / 2; i++)
                if (text[i] != text[text.Length - 1 - i]) return false;
            return true;
        }
    }
}