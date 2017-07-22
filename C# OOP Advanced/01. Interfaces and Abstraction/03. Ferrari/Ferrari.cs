using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Ferrari : ICar
{
    public string Name { get; private set; }
    public string Car { get; private set; }
    public string Model { get; private set; }
    public string UseBrakes()
    {
        return "Brakes!";
    }
    public string PushPedal()
    {
        return "Zadu6avam sA!";
    }
    public Ferrari(string name)
    {
        this.Name = name;
        this.Car = "Ferrari";
        this.Model = "488-Spider";
    }
    public override string ToString()
    {
        return this.Model + "/" + UseBrakes() + "/" + PushPedal() + "/" + this.Name;
    }
}
