using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Citizen : IResident, IPerson
{
    public int Age { get; }

    public string Country { get; }

    public string Name { get; }

    public Citizen(string name,string country, int age)
    {
        this.Age = age;
        this.Name = name;
        this.Country = country;
    }

    string IResident.GetName()
    {
        return $"Mr/Ms/Mrs {this.Name}";
    }
    string IPerson.GetName()
    {
        return this.Name;
    }
}
