using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class Program
{
    static void Main(string[] args)
    {
        var personsName = new SortedSet<Person>(new PersonNameComparator());
        var personsAge = new SortedSet<Person>(new PersonAgeComparator());
        var lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            var input = Console.ReadLine().Split(' ');
            var person = new Person(input[0],int.Parse(input[1]));
            personsName.Add(person);
            personsAge.Add(person);
        }
        foreach (var person in personsName)
        {
            Console.WriteLine(person); 
        }
        foreach (var person in personsAge)
        {
            Console.WriteLine(person);
        }
    }
}
