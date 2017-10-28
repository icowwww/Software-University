using System;
using System.Linq;

namespace Reverse_String
{
    public class Reverse_String
    {
        public static void Main()
        {
            char[] text = Console.ReadLine().ToCharArray().Reverse().ToArray();
            Console.WriteLine(text);
        }
    }
}