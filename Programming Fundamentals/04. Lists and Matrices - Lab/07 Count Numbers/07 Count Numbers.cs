using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Numbers
{
    class Count_Numbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            foreach (var number in numbers.Distinct().OrderBy(x => x))
                Console.WriteLine(string.Join(" -> ",
                    number,
                    numbers.Count(x => x == number)));
        }
    }
}