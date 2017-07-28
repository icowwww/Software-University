using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static void Main(string[] args)
    {
        var persons= new List<Person>();
        var input = Console.ReadLine();
        while (input !="END")
        {
            var inputArgs = input.Split(' ');
            var person = new Person(inputArgs[0],int.Parse(inputArgs[1]),inputArgs[2]);
            persons.Add(person);
            input = Console.ReadLine();
        }
        var index = int.Parse(Console.ReadLine());
        var counter = persons.Count(x => x.CompareTo(persons[index - 1]) == 0);
        if (counter < 2)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{counter} {persons.Count - counter} {persons.Count}");
        }
    }
}
