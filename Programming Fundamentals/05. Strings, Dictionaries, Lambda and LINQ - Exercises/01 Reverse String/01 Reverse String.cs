using System;

namespace Reverse_String
{
    public class Reverse_String
    {
        public static void Main()
        {
            char[] text = Console.ReadLine().ToCharArray();
            Array.Reverse(text);
            Console.WriteLine(text);
        }
    }
}