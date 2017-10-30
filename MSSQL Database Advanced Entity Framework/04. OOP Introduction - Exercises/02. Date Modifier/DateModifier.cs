using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class DateModifier
{
    public double DateDiff(string firstDate, string secondDate)
    {
        DateTime dateOne =
            DateTime.ParseExact(firstDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        DateTime dateTwo =
            DateTime.ParseExact(secondDate, "yyyy MM dd", CultureInfo.InvariantCulture);
        return Math.Abs((dateTwo - dateOne).TotalDays);
    }
}