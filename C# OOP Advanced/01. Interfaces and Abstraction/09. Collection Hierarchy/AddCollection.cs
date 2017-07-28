using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class AddCollection : Collection
{
    public override int Add(string str)
    {
        base.Elements.Add(str);
        return base.Elements.Count - 1;
    }
}
