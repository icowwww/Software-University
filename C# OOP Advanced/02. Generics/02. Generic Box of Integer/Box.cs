using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box<T>
{
    public T Value { get; private set; }
    public Box(T value)
    {
        this.Value = value;
    }
    public override string ToString()
    {
        return this.Value.GetType().FullName + ": " +this.Value.ToString();
    }
}