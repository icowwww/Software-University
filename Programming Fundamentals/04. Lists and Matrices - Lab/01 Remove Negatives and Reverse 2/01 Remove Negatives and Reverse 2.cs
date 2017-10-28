﻿using System;
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
                .Where(x => x >= 0)
                .Reverse()
                .ToList();
            if (numbers.Count > 0)
                Console.WriteLine(string.Join(", ", numbers));
            else
                Console.WriteLine("empty");
        }
    }
}