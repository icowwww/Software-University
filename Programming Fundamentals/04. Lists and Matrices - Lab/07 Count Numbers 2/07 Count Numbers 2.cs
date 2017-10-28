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
                .OrderBy(x => x)
                .ToList();
            int count = 1;
            for (int i = 1; i < numbers.Count + 1; i++)
            {
                if (i == numbers.Count)
                    Console.WriteLine(string.Join(" -> ", numbers[i - 1], count));
                else if (numbers[i] == numbers[i - 1]) count++;
                else
                {
                    Console.WriteLine(string.Join(" -> ", numbers[i - 1], count));
                    count = 1;
                }
            }
        }
    }
}