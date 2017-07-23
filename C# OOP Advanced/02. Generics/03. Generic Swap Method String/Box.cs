using System.Collections.Generic;
using System.Text;


public class Box<T>
{
    public List<T> list { get; }
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
        var currentelement = list[firstposition];
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

