using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        var stack = new Stack<string>();
        while (input[0] != "END")
        {
            switch (input[0])
            {
                case "Push":
                    stack.Push(input.Skip(1));
                    break;
                case "Pop":
                    try
                    {
                        stack.Pop();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
            input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }
    }
}
