using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Collection : IAddable
{
    private const int MaxCapacity = 100;

    private List<string> collection;

    protected Collection()
    {
        this.collection = new List<string>(MaxCapacity);
    }
    public List<string> Elements
    {
        get
        {
            return this.collection;
        }
    }
    public abstract int Add(string str);
}
