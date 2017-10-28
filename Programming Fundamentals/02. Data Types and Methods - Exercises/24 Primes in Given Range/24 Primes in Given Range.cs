using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primes_in_Given_Range
{
    class Primes_in_Given_Range
    {
        static void Main(string[] args)
        {
            int rangeStart = int.Parse(Console.ReadLine());
            int rangeEnd = int.Parse(Console.ReadLine());

            List<int> primesInRange = FindPrimesInRange(rangeStart, rangeEnd);
            Console.WriteLine(string.Join(", ", primesInRange));
        }

        static List<int> FindPrimesInRange(int rangeStart, int rangeEnd)
        {
            List<int> primes = new List<int>();
            for (int number = rangeStart; number <= rangeEnd; number++)
                if (IsPrime(number)) primes.Add(number);
            return primes;
        }

        static bool IsPrime(int number)
        {
            if (number == 0 || number == 1)
                return false;
            for (int i = 2; i <= Math.Sqrt(number); i++)
                if (number % i == 0) return false;
            return true;
        }
    }
}
