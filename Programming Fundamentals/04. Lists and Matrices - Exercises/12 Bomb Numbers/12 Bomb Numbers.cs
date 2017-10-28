using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomb_Numbers
{
    class Bomb_Numbers
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToList();
            numbers = RemoveBombedNumbers(numbers);
            Console.WriteLine(numbers.Sum());
        }

        private static List<long> RemoveBombedNumbers(List<long> numbers)
        {
            int[] bombData = Console.ReadLine()
                            .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            int bombNumber = bombData[0];
            int bombRange = bombData[1];
            while (numbers.IndexOf(bombNumber) != -1)
            {
                int bombIndex = numbers.IndexOf(bombNumber);
                int bombRangeStart = Math.Max(bombIndex - bombRange, 0);
                int bombRangeEnd = Math.Min(bombIndex + bombRange, numbers.Count - 1);
                numbers.RemoveRange(bombRangeStart, bombRangeEnd - bombRangeStart + 1);
            }
            return numbers;
        }
    }
}