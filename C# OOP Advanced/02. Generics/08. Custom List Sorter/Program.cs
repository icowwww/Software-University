using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var objects = new CustomList<string>();
        var input = Console.ReadLine().Split(' ');
        while (input[0] != "END")
        {
            switch (input[0])
            {
                case "Add":
                    objects.Add(input[1]);
                    break;
                case "Remove":
                    objects.Remove(int.Parse(input[1]));
                    break;
                case "Contains":
                    Console.WriteLine(objects.Contains(input[1]));
                    break;
                case "Swap":
                    objects.Swap(int.Parse(input[1]), int.Parse(input[2]));
                    break;
                case "Greater":
                    Console.WriteLine(objects.CountGreaterThan(input[1]));
                    break;
                case "Max":
                    Console.WriteLine(objects.Max());
                    break;
                case "Min":
                    Console.WriteLine(objects.Min());
                    break;
                case "Print":
                    Console.WriteLine(objects.Print());
                    break;
                case "Sort":
                    objects = Sorter.Sort(objects);
                    break;
            }
            input = Console.ReadLine().Split(' ');
        }
    }
}
