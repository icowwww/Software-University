using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

class Program
{
    public static void Main(string[] args)
    {
        var name = Console.ReadLine();
        Console.WriteLine((new Ferrari(name)).ToString());
    }
}
