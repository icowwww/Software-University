using System;
using System.Linq;

namespace Count_Real_Numbers
{
    public class Count_Real_Numbers
    {
        public static void Main()
        {
            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .OrderBy(x => x)
                .ToArray();
            foreach (var number in numbers.Distinct())
                Console.WriteLine(string.Join(" -> ", 
                                    number,
                                    numbers.Count(x => x == number)));
        }
    }
}