using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_Speed_Units
{
    class Convert_Speed_Units
    {
        static void Main(string[] args)
        {
            float distanceMeters = float.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float speedMSec = (float)distanceMeters 
                            / (seconds + minutes * 60f + hours * 60f * 60f);
            float speedKmH = (float)distanceMeters / 1000f 
                            / (hours + minutes / 60f + seconds / 60f / 60f);
            float speedMPH = (float)distanceMeters / 1609f 
                            / (hours + minutes / 60f + seconds / 60f / 60f);
            Console.WriteLine("{0}", speedMSec);
            Console.WriteLine("{0}", speedKmH);
            Console.WriteLine("{0}", speedMPH);
        }
    }
}
