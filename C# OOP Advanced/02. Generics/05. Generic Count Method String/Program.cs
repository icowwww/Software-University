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
        var box = new Box<string>();
        for (int i = 0; i < number; i++)
        {
            box.Add(Console.ReadLine());
        }
        var swapinfo = Console.ReadLine();
        Console.WriteLine(box.Compare<string>(swapinfo));
    }
}