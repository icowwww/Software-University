using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Sorter
{
    public static CustomList<T> Sort<T>(CustomList<T> customList) where T: IComparable<T>
    {
        var array = customList.ToArray();
        Array.Sort(array);
        return new CustomList<T>(array.ToList());
    }
}
