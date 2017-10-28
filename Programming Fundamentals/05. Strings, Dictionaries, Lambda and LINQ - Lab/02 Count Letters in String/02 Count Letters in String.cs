using System;
using System.Linq;

namespace Count_Letters_in_String
{
    public class Count_Letters_in_String
    {
        public static void Main()
        {
            char[] letters = Console.ReadLine().ToLower().ToCharArray();
            foreach (var letter in letters.Distinct().OrderBy(x => x))
                Console.WriteLine(string.Join(" -> ", 
                                    letter,
                                    letters.Count(x => x == letter)));
        }
    }
}