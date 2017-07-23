using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Threeuple<T1, T2, T3>
{
    private T1 item1;
    private T2 item2;
    private T3 item3;

    public Threeuple(T1 Item1, T2 Item2, T3 Item3)
    {
        this.item1 = Item1;
        this.item2 = Item2;
        this.item3 = Item3;
    }
    public override string ToString()
    {
        return $"{this.item1} -> {this.item2} -> {this.item3}";
    }
}