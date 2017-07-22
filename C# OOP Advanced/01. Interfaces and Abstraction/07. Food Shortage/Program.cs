using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var Ids = new List<IBuyer>();
        var dictionary = new Dictionary<string,IBuyer>();

        var number = int.Parse(Console.ReadLine());
        for (int index = 0; index < number; index++)
        {
            var curretnLine = Console.ReadLine().Split(' ');
            
            if (curretnLine.Length == 3)
            {
                var rebel = new Rebel(curretnLine[0],Int32.Parse(curretnLine[1]),curretnLine[2]);
                dictionary[curretnLine[0]] = rebel;
            }
            else
            {
                var citizen = new Citizen(curretnLine[0], int.Parse(curretnLine[1]), curretnLine[2], curretnLine[3]);
                dictionary[curretnLine[0]] = citizen;
            }

        }


        var info = Console.ReadLine();
        while (info !="End")
        {
            if (dictionary.ContainsKey(info))
            {
                dictionary[info].BuyFood();
            }
            info = Console.ReadLine();
        }
        Console.WriteLine(dictionary.Sum(x => x.Value.Food));

    }
}

