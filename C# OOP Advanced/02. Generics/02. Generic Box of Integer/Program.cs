using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var list1 = new List<Box<int>>();
        var number = int.Parse(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            var box = new Box<int>(int.Parse(Console.ReadLine()));
            list1.Add(box);
        }
        foreach (var item in list1)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
