using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Numbers
{
    class Fibonacci_Numbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] fibonacci = GetFibonacci(n);
            Console.WriteLine(fibonacci[fibonacci.Length - 1]);
        }

        static int[] GetFibonacci(int n)
        {
            int[] fibonacci = new int[n + 1];   // [0, n]
            fibonacci[0] = 1;
            if (fibonacci.Length > 1)
                fibonacci[1] = 1;
            for (int i = 2; i <= n; i++)
                fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
            return fibonacci;
        }
    }
}
