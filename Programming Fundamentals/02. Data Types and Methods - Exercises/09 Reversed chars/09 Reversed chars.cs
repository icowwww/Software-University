using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversed_chars
{
    class Reversed_chars
    {
        static void Main(string[] args)
        {
            char[] letters = new char[3];
            for (int i = 0; i < letters.Length; i++)
                letters[i] = (Console.ReadLine()[0]);
            Array.Reverse(letters);
            Console.WriteLine(string.Join("", letters));
        }
    }
}