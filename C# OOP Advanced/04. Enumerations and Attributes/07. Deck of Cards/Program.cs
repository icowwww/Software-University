using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        var suits = Enum.GetValues(typeof(Suits));
        var ranks = Enum.GetValues(typeof(CardRanks));

        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                Console.WriteLine($"{rank} of {suit}");
            }
        }
    }
}
