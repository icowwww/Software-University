using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Smartphone: IDial, IBrowsing
{
    public string Dial(string number)
    {
        return "Calling... " + number;
    }
    public string Browse(string url)
    {
        return "Browsing: " + url+"!";
    }
}
