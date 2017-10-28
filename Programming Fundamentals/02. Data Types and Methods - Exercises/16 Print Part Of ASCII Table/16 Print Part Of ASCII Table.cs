using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Part_Of_ASCII_Table
{
    class Print_Part_Of_ASCII_Table
    {
        static void Main(string[] args)
        {
            int indexStart = int.Parse(Console.ReadLine());
            int indexEnd = int.Parse(Console.ReadLine());

            for (int i = indexStart; i <= indexEnd; i++)
                Console.Write("{0} ", (char)i);
        }
    }
}