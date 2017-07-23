using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(' ');
        var name = input[0] + " " + input[1];
        var tuple = new Threeuple<string, string, string>(name, input[2], input[3]);
        Console.WriteLine(tuple.ToString());

        input = Console.ReadLine().Split(' ');
        var tuple1 = new Threeuple<string, int, bool>(input[0], int.Parse(input[1]), input[2] == "drunk");
        Console.WriteLine(tuple1.ToString());

        input = Console.ReadLine().Split(' ');
        var tuple2 = new Threeuple<string, double, string>(input[0], double.Parse(input[1]), input[2]);
        Console.WriteLine(tuple2.ToString());
    }
}
