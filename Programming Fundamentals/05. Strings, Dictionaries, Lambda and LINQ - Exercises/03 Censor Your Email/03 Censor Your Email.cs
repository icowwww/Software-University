using System;

namespace Censor_Your_Email
{
    public class Censor_Your_Email
    {
        public static void Main()
        {
            string[] email = Console.ReadLine().Split('@');
            string text = Console.ReadLine();
            text = text.Replace(string.Join("@", email),
                string.Join("@", new string('*', email[0].Length), email[1]));
            Console.WriteLine(text);
        }
    }
}