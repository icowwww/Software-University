using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IBuyer
{
    string Name { get; }
    void BuyFood();
    int Food { get; }
}