using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variable_in_Hex_Format
{
    class Variable_in_Hex_Format
    {
        static void Main(string[] args)
        {
            int number = Convert.ToInt32(Console.ReadLine(), 16);   // convert hex to int
            Console.WriteLine(number);
        }
    }
}
