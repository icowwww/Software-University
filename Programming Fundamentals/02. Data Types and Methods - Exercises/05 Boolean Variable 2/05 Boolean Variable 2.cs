using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean_Variable
{
    class Boolean_Variable
    {
        static void Main(string[] args)
        {
            // v.2 new output format requirements
            bool boolVariable = Convert.ToBoolean(Console.ReadLine());  // true, false
            if (boolVariable)   Console.WriteLine("Yes");
            else                Console.WriteLine("No");
        }
    }
}