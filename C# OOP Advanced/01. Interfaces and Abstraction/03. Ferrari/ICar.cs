using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ICar
{
    string UseBrakes();
    string PushPedal();
    string Name { get; }
    string Car { get; }
    string Model { get; }
}