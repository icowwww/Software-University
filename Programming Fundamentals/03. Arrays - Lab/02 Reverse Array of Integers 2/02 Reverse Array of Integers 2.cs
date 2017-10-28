using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Array_of_Integers
{
    class Reverse_Array_of_Integers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
                numbers[i] = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join(" ", numbers.Reverse()));
        }
    }
}