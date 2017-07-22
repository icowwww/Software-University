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
            if (infoArgs[0] =="Robot")
            {
                var robot = new Robot(infoArgs[1],infoArgs[2]);
            }
            else if(infoArgs[0] =="Citizen")
            {
                var citizen = new Citizen(infoArgs[1],int.Parse(infoArgs[2]),infoArgs[3],infoArgs[4]);
                Ids.Add(citizen);
            }
            else
            {
                var pet = new Pet(infoArgs[1],infoArgs[2]);
                Ids.Add(pet);
            }
            info = Console.ReadLine();
        }
        var birthdate = Console.ReadLine();
        foreach (var id in Ids.Where(x=> x.Birthdate.EndsWith(birthdate)))
        {
            Console.WriteLine(id.Birthdate);
        }
    }
}

