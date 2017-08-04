using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var CardRank = Console.ReadLine();
        var CardSuit = Console.ReadLine();
        var power= (int)Enum.Parse(typeof(Suits), CardSuit) + (int)Enum.Parse(typeof(CardRanks), CardRank);
        Console.WriteLine($"Card name: {CardRank} of {CardSuit}; Card power: {power}");
    }
}
