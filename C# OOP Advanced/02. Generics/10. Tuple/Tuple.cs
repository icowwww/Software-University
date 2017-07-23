using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Tuple<T1, T2>
{
    private T1 item1;
    private T2 item2;

    public Tuple(T1 Item1, T2 Item2)
    {
        this.item1 = Item1;
        this.item2 = Item2;
    }
    public override string ToString()
    {
        return $"{this.item1} -> {this.item2}";
    }
}