using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PersonNameComparator: IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        var result = x.Name.Length.CompareTo(y.Name.Length);
        if (result==0)
        {
            result = char.ToLower(x.Name.ToCharArray().First()).CompareTo(char.ToLower(y.Name.ToCharArray().First()));
        }
        return result;
    }
}