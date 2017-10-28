using System;
using System.Linq;

namespace Print_a_Receipt
{
    public class Print_a_Receipt
    {
        public static void Main()
        {
            decimal[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).ToArray();
            Console.WriteLine("/{0}\\", new string('-', 22));
            for (int i = 0; i < numbers.Length; i++)
                Console.WriteLine("| {0,20:f2} |", numbers[i]);
            Console.WriteLine("|{0}|", new string('-', 22));
            Console.WriteLine("| Total:{0,14:f2} |", numbers.Sum());
            Console.WriteLine("\\{0}/", new string('-', 22));
        }
    }
}