using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Arrays
{
    class Sum_Arrays
    {
        static void Main(string[] args)
        {
            int[] array1 = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] array2 = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int maxLength = Math.Max(array1.Length, array2.Length);
            long[] sumArrays = new long[maxLength];
            for (int i = 0; i < sumArrays.Length; i++)
                sumArrays[i] = array1[i % array1.Length] + array2[i % array2.Length];
            Console.WriteLine(string.Join(" ", sumArrays));
        }        
    }
}