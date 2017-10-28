using System;
using System.Linq;

namespace Largest_3_Numbers
{
    public class Largest_3_Numbers
    {
        public static void Main()
        {
            double[] largestNumbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .OrderBy(x => -x)
                .Take(3)
                .ToArray();
            Console.WriteLine(string.Join(" ", largestNumbers));
        }
    }
}
