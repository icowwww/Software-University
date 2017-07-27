using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
public class ListyIterator<T> : IEnumerable<T>
{
    private readonly List<T> list;
    private int currentIndex;

    public ListyIterator()
    {
        this.list = new List<T>();
    }

    public ListyIterator(IEnumerable<T> collection)
    {
        this.list = new List<T>(collection);
        this.currentIndex = 0;
    }
    public bool Move()
    {
        if (HasNext())
        {
            this.currentIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        if (currentIndex < this.list.Count-1)
        {
            return true;
        }
        return false;
    }

    public void Print()
    {
        if (this.list.Count==0)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        Console.WriteLine(this.list[this.currentIndex]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for(int i = 0; i < this.list.Count; i++)
            yield return this.list[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
