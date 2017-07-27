using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


public class Stack<T>: IEnumerable<T>
{
    private List<T> list;

    public Stack()
    {
        this.list = new List<T>();
    }

    public void Push(IEnumerable<T> elements)
    {
        foreach (var element in elements)
        {
          list.Add(element);  
        }
    }

    public void Pop()
    {
        if (list.Count == 0)
        {
            throw new ArgumentException("No elements");
        }
       list.RemoveAt(list.Count-1); 
    }


    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.list.Count-1; i >= 0; i--)
            yield return this.list[i];
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
