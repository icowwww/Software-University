using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Box<T>
{
    public List<T> list { get; private set; }
    public Box()
    {
        this.list = new List<T>();
    }
    public void Add(T element)
    {
        this.list.Add(element);
    }
    public void Swap(int firstposition, int secondposition)
    {
        T currentelement = list[firstposition];
        list[firstposition] = list[secondposition];
        list[secondposition] = currentelement;
    }
    public override string ToString()
    {
        var sb = new StringBuilder();
        foreach (var item in this.list)
        {
            sb.AppendLine(item.GetType().FullName + ": " + item.ToString());
        }
        return sb.ToString();
    }
}

