using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Array_of_Strings
{
    class Reverse_Array_of_Strings
    {
        static void Main(string[] args)
        {
            string[] sequence = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(string.Join(" ", sequence.Reverse()));
        }
    }
}