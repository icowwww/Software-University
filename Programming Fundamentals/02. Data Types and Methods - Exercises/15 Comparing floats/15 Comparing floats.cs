using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparing_floats
{
    class Comparing_floats
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            double precision = 0.000001d;

            double diff = Math.Abs(number1 - number2);
            Console.WriteLine(diff < precision);    // diff < required precision => equal numbers
        }
    }
}
