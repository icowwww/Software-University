using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index_of_letters
{
    class Index_of_letters
    {
        static void Main(string[] args)
        {
            //char[] letters = [a, z]          
            string text = Console.ReadLine();
            foreach (var letter in text)
                Console.WriteLine(string.Join(" -> ", letter, letter - 'a'));
        }
    }
}