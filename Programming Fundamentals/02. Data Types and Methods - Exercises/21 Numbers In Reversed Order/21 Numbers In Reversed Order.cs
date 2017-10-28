using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numbers_In_Reversed_Order
{
    class Numbers_In_Reversed_Order
    {
        static void Main(string[] args)
        {
            decimal number = decimal.Parse(Console.ReadLine());
            PrintDigitsInReverseOrder(number);
        }

        static void PrintDigitsInReverseOrder(decimal number)
        {
            string numberStr = number.ToString();
            for (int i = numberStr.Length - 1; i >= 0; i--)
                Console.Write(numberStr[i]);
        }
    }
}