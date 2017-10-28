using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Var_Values
{
    class Exchange_Var_Values
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
            Console.WriteLine("Before:\na = {0}\nb = {1}", a, b);
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After:\na = {0}\nb = {1}", a, b);
        }
    }
}
