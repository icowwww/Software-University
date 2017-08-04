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
        Console.WriteLine(card);
    }
}
