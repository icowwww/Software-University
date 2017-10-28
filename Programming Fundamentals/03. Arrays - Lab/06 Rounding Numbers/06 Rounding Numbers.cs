using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rounding_Numbers
{
    class Rounding_Numbers
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();
            for (int i = 0; i < numbers.Length; i++)
                Console.WriteLine(string.Join(" => ", 
                    numbers[i],
                    Math.Round(numbers[i], MidpointRounding.AwayFromZero)));
        }
    }
}