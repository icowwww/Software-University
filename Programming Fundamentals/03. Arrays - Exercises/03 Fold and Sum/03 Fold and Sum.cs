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
            int[] innerArr = new int[2 * k];
            int[] outerArr = new int[2 * k];
            for (int i = 0; i < 2 * k; i++)
                innerArr[i] = numbers[k + i];
            for (int i = 0; i < k; i++)
            {
                outerArr[i] = numbers[k - 1 - i];
                outerArr[k + i] = numbers[numbers.Length - 1 - i];
            }
            int[] sumArr = new int[2 * k];
            for (int i = 0; i < 2 * k; i++)
                sumArr[i] = outerArr[i] + innerArr[i];
            Console.WriteLine(string.Join(" ", sumArr));
        }
    }
}