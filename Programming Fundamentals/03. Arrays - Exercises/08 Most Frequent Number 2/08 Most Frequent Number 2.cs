using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Most_Frequent_Number
{
    class Most_Frequent_Number
    {
        static void Main(string[] args)
        {
            int[] sequance = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Dictionary<int, int> counts = new Dictionary<int, int>();
            int maxCount = 0;
            int frequentNumber = 0;
            for (int i = 0; i < sequance.Length; i++)
            {
                if (!counts.ContainsKey(sequance[i]))
                    counts[sequance[i]] = 0;
                counts[sequance[i]]++;
                if (counts[sequance[i]] > maxCount)
                {
                    maxCount = counts[sequance[i]];
                    frequentNumber = sequance[i];
                }
            }
            Console.WriteLine(frequentNumber);
        }
    }
}