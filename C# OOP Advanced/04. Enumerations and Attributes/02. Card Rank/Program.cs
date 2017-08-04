using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        Console.ReadLine();
        var names = Enum.GetNames(typeof(CardRanks));
        Console.WriteLine("Card Ranks:");
        foreach (var item in names)
        {
            Console.WriteLine($"Ordinal value: {Array.IndexOf(names,item)}; Name value: {item}");
        }
    }
}
