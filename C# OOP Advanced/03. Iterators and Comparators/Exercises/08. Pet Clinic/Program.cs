﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var type = typeof(Pet);
        Console.WriteLine(type.Name);
        Console.WriteLine(type.FullName);
    }
}