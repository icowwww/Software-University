using System;
using System.Linq;

namespace Common_Strings
{
    public class Common_Strings
    {
        public static void Main()
        {
            string word1 = Console.ReadLine();
            string word2 = Console.ReadLine();
            bool containsCommonChar = false;
            foreach (char word1Char in word1)
            {
                if (word2.Contains(word1Char))
                {
                    containsCommonChar = true; break;
                }
            }
            Console.WriteLine(containsCommonChar ? "yes" : "no");
        }
    }
}