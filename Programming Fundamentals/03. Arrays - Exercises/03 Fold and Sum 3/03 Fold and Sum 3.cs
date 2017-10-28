using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fold_and_Sum
{
    class Fold_and_Sum
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int k = numbers.Length / 4;
            int[] innerArr = numbers.Skip(k).Take(2 * k)
                            .ToArray();
            int[] outerArr = numbers.Take(k).Reverse()
                            .Concat(numbers.Reverse().Take(k))
                            .ToArray();
            int[] sumArr = innerArr
                            .Select((x, index) => x + outerArr[index])
                            .ToArray();
            Console.WriteLine(string.Join(" ", sumArr));
        }
    }
}