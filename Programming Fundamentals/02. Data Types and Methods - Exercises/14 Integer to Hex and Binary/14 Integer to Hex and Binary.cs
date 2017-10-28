using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integer_to_Hex_and_Binary
{
    class Integer_to_Hex_and_Binary
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Convert.ToString(number, 16).ToUpper());  // to Hex
            Console.WriteLine(Convert.ToString(number, 2));             // to Bin
        }
    }
}