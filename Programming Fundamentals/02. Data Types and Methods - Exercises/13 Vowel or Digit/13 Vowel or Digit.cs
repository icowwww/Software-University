using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vowel_or_Digit
{
    class Vowel_or_Digit
    {
        static void Main(string[] args)
        {
            char symbol = char.Parse(Console.ReadLine());

            if (char.IsDigit(symbol))           Console.WriteLine("digit");
            else if ("aeiou".Contains(symbol))  Console.WriteLine("vowel");
            else                                Console.WriteLine("other");
        }
    }
}