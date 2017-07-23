using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


public class CustomList<T> : ICustomList<T> where T: IComparable<T>
{
    private List<T> objects;
    public CustomList()
    {
        this.objects = new List<T>();
    }
    public void Add(T element)
    {
     this.objects.Add(element);   
    }

    public void Remove(int index)
    {
        this.objects.RemoveAt(index);
    }
    public bool Contains(T element)
    {
        return this.objects.Contains(element);
    }
    public void Swap(int index1, int index2)
    {
        var currentelement = this.objects[index1];
        this.objects[index1] = this.objects[index2];
        this.objects[index2] = currentelement;
    }
    public int CountGreaterThan(T element)
    {
        return this.objects.Count(x => x.CompareTo(element) > 0);
    }
    public T Max()
    {
        return this.objects.Max();
    }
    public T Min()
    {
        return this.objects.Min();
    }
    public string Print()
    {
        var sb = new StringBuilder();
        foreach (var item in this.objects)
        {
            sb.AppendLine(item.ToString());
        }
        return sb.ToString().Trim();
    }
}

