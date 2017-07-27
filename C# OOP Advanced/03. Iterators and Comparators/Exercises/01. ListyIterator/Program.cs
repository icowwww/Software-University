using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var listyIterator = new ListyIterator<string>(input.Split(' ').Skip(1));
        input = Console.ReadLine();
        while (input != "END")
        {
            switch (input)
            {
                case "Move":
                    Console.WriteLine(listyIterator.Move());
                    break;
                case "HasNext":
                    Console.WriteLine(listyIterator.HasNext());
                    break;
                case "Print":
                    try
                    {
                        listyIterator.Print();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
            input = Console.ReadLine();
        }
    }
}
