using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var phone = new Smartphone();
        var input = Console.ReadLine().Split(' ');
        foreach (var item in input)
        {
            if (!item.All(Char.IsDigit))
            {
                Console.WriteLine("Invalid number!");
            }
            else
            {
                Console.WriteLine(phone.Dial(item));
            }
        }
        input = Console.ReadLine().Split(' ');
        foreach (var item in input)
        {
            if (item.Any(Char.IsDigit))
            {
                Console.WriteLine("Invalid URL!");
            }
            else
            {
                Console.WriteLine(phone.Browse(item));
            }
        }
    }
}