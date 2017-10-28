using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sum_Min_Max_First_Last_Average
{
    class Sum_Min_Max_First_Last_Average
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
                numbers[i] = int.Parse(Console.ReadLine());
            Console.WriteLine("Sum = {0}\nMin = {1}\nMax = {2}\nFirst = {3}\nLast = {4}\nAverage = {5:f2}",
                numbers.Sum(), numbers.Min(), numbers.Max(), numbers.First(), numbers.Last(), numbers.Average());
        }
    }
}