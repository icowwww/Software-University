using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var Ids = new List<IInfo>();
        var info = Console.ReadLine();
        while (info !="End")
        {
            var infoArgs = info.Split(' ');
            if (infoArgs.Length == 2)
            {
                var robot = new Robot(infoArgs[0],infoArgs[1]);
                Ids.Add(robot);
            }
            else
            {
                var citizen = new Citizen(infoArgs[0],int.Parse(infoArgs[1]),infoArgs[2]);
                Ids.Add(citizen);
            }
            info = Console.ReadLine();
        }
        var fakeID = Console.ReadLine();
        foreach (var id in Ids.Where(x=> x.Id.EndsWith(fakeID)))
        {
            Console.WriteLine(id.Id);
        }
    }
}

