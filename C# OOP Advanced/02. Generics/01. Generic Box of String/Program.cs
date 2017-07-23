using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var customlist = new List<Box<string>>();
        var number = int.Parse(Console.ReadLine());
        for (int i = 0; i < number; i++)
        {
            var box = new Box<string>(Console.ReadLine());
            customlist.Add(box);
        }
        foreach (var item in customlist)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
