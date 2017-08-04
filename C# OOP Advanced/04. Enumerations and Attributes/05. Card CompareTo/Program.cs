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
        var card = new Card(CardRank, CardSuit);
        CardRank = Console.ReadLine();
        CardSuit = Console.ReadLine();
        var card2 = new Card(CardRank, CardSuit);
        if (card.CompareTo(card2) >= 1)
        {
            Console.WriteLine(card);
        }
        else
        {
            Console.WriteLine(card2);
        }
    }
}
