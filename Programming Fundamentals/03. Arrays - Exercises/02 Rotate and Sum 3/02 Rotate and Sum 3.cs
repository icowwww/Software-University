using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotate_and_Sum
{
    class Rotate_and_Sum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rotations = int.Parse(Console.ReadLine());
            int[] sumRotatedNumbers = new int[numbers.Length];

            for (int i = 0; i < rotations; i++)
            {
                numbers = numbers.Skip(numbers.Length - 1).Take(1)
                        .Concat(numbers.Take(numbers.Length - 1))
                        .ToArray();
                sumRotatedNumbers = sumRotatedNumbers
                    .Select((x, index) => x + numbers[index])
                    .ToArray();
            }
            Console.WriteLine(string.Join(" ", sumRotatedNumbers));
        }
    }
}