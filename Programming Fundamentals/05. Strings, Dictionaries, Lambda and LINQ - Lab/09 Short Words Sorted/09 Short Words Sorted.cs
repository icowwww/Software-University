using System;
using System.Linq;

namespace Short_Words_Sorted
{
    public class Short_Words_Sorted
    {
        public static void Main()
        {
            char[] separators = ".,:;()[]\"'!? ".ToCharArray();
            string[] words = Console.ReadLine().ToLower()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length < 5)
                .Distinct()
                .OrderBy(x => x)
                .ToArray();
            Console.WriteLine(string.Join(", ", words));
        }
    }
}