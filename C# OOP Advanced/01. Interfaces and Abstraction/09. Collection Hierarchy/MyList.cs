using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MyList : Collection, ICountable
{
    public int Count
    {
        get
        {
            return base.Elements.Count;
        }
    }

    public override int Add(string str)
    {
        base.Elements.Insert(0, str);
        return 0;
    }

    public string Remove()
    {
        string forReturn = base.Elements[0];
        base.Elements.RemoveAt(0);
        return forReturn;
    }
}
