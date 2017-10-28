using System;

namespace Fit_String_in_20_Chars
{
    public class Fit_String_in_20_Chars
    {
        public static void Main()
        {
            string text = Console.ReadLine();
            int len = 20;
            if (text.Length > len)
                text = text.Substring(0, len);
            else if (text.Length < len)
                text = string.Join("", text, new string('*', len - text.Length));
            Console.WriteLine(text);
        }
    }
}