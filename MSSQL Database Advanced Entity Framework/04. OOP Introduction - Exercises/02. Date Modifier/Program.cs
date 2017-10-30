using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var date = new DateModifier();
        var dateOne = Console.ReadLine();
        var dateTwo = Console.ReadLine();
        Console.WriteLine(
            date.DateDiff(dateOne, dateTwo));
    }
}
