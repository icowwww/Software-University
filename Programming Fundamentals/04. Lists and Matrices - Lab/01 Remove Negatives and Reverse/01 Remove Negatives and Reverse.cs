using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Negatives_and_Reverse
{
    class Remove_Negatives_and_Reverse
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            List<int> positiveNumbers = new List<int>();
            foreach (int number in numbers)
                if (number >= 0)    positiveNumbers.Add(number);
            positiveNumbers.Reverse();
            if (positiveNumbers.Count > 0)
                Console.WriteLine(string.Join(" ", positiveNumbers));
            else
                Console.WriteLine("empty");
        }
    }
}