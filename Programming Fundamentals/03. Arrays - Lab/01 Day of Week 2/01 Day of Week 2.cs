using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_of_Week
{
    class Day_of_Week
    {
        static void Main(string[] args)
        {
            string[] weekdays = "Monday,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday"
                .Split(',');
            int day = int.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(weekdays[day - 1]);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Day!");
            }
        }
    }
}