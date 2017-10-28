using System;

namespace Print_String_Letters
{
    public class Print_String_Letters
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
                Console.WriteLine("str[{0}] -> '{1}'", i, text[i]);
        }
    }
}