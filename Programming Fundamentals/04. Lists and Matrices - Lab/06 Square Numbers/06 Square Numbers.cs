using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_Numbers
{
    class Square_Numbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x >= 0)
                .ToList();
            List<int> squareNumbers = new List<int>();
            foreach (int number in numbers)
            {
                int sqRoot = (int)Math.Sqrt(number);
                if (sqRoot * sqRoot == number)
                    squareNumbers.Add(number);
            }
            Console.WriteLine(string.Join(" ", squareNumbers.OrderBy(x => -x)));
        }
    }
}
