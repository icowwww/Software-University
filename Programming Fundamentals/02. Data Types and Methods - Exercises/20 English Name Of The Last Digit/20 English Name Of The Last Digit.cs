using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace English_Name_Of_The_Last_Digit
{
    class English_Name_Of_The_Last_Digit
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int digit = int.Parse(number[number.Length - 1].ToString());
            Console.WriteLine(GetDigitName(digit));
        }

        static string GetDigitName(int digit)
        {
            string names = "zero,one,two,three,four,five,six,seven,eight,nine";
            string[] digitNames = names.Split(',').ToArray();
            for (int i = 0; i < digitNames.Length; i++)
                if (digit == i) return digitNames[i];
            return string.Empty;
        }
    }
}
