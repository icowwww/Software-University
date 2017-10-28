using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_Name
{
    class Hello_Name
    {
        static void Main(string[] args)
        {
            string name = GetName();
            Console.WriteLine("Hello, {0}!", name);
        }

        static string GetName()
        {
            return Console.ReadLine();
        }
    }
}
