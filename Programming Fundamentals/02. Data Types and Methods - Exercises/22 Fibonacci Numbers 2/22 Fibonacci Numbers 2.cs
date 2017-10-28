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
            Stack<long> fibonacci = new Stack<long>();
            fibonacci.Push(1);
            fibonacci.Push(1);
            for (int i = 2; i <= n; i++)
            {
                long prevFibonacci = fibonacci.Pop();
                long nextFibonacci = fibonacci.Peek() + prevFibonacci;
                fibonacci.Push(prevFibonacci);
                fibonacci.Push(nextFibonacci);
            }
            Console.WriteLine(fibonacci.Peek());
        }
    }
}
