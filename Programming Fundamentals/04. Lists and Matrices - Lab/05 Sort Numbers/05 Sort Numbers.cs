﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Numbers
{
    class Sort_Numbers
    {
        static void Main(string[] args)
        {
            List<decimal> numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .OrderBy(x => x)
                .ToList();
            Console.WriteLine(string.Join(" <= ", numbers));
        }
    }
}