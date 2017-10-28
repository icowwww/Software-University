using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Numbers
{
    class Master_Numbers
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
                if (IsMasterNumber(i))
                    Console.WriteLine(i);
        }
        static bool IsMasterNumber(int number)
        {
            return IsPalindrome(number) && SumOfDigitsDivisibleBy7(number) && ContainsEvenDigit(number);
        }
        static bool IsPalindrome(int number)
        {
            string numberStr = number.ToString();
            int len = numberStr.Length;
            for (int i = 0; i < len / 2; i++) 
            {
                if (numberStr[i] != numberStr[len - 1 - i])
                    return false;
            }
            return true;
        }
        static bool SumOfDigitsDivisibleBy7(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum % 7 == 0;
        }
        static bool ContainsEvenDigit(int number)
        {
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                    return true;
                number /= 10;
            }
            return false;
        }
    }
}
