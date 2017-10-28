using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Numbers
{
    class Fibonacci_Numbers
    {
        static long[] fibonacci;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            fibonacci = new long[n + 1];
            fibonacci[0] = 1;
            if(n > 0) fibonacci[1] = 1;
            Console.WriteLine(GetFibonacci(n));
        }

        static long GetFibonacci(int n)
        {
            if (fibonacci[n] == 0)
                fibonacci[n] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
            return fibonacci[n];
        }
    }
}
