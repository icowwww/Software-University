using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var number = int.Parse(Console.ReadLine());
        var box = new Box<double>();
        for (int i = 0; i < number; i++)
        {
            box.Add(double.Parse(Console.ReadLine()));
        }
        var swapinfo = double.Parse(Console.ReadLine());
        Console.WriteLine(box.Compare(swapinfo));
    }
}