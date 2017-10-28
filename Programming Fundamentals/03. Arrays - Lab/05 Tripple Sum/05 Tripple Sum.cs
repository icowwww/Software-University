using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tripple_Sum
{
    class Tripple_Sum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            bool containsTriples = false;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                    if (numbers.Contains(numbers[i] + numbers[j]))
                    {
                        containsTriples = true;
                        Console.WriteLine("{0} + {1} == {2}",
                            numbers[i], numbers[j], numbers[i] + numbers[j]);
                    }
            }
            if (!containsTriples)
                Console.WriteLine("No");
        }
    }
}