using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        while (input!="End")
        {
            var inputArgs = input.Split(' ');
            var citizen = new Citizen(inputArgs[0],inputArgs[1],int.Parse(inputArgs[2]));
            IResident resident = citizen;
            IPerson person = citizen;

            Console.WriteLine(person.GetName());
            Console.WriteLine(resident.GetName());
            input = Console.ReadLine();

        }
    }
}